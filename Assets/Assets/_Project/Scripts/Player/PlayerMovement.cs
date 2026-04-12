using UnityEngine;

// ╔═══════════════════════════════════════════════════════════════╗
// ║  DESIGN PATTERN: Component Pattern                           ║
// ║  Vai trò: CHỈ xử lý di chuyển. Không biết về input/anim.  ║
// ║                                                               ║
// ║  THAY ĐỔI LỚN NHẤT: CharacterController → Rigidbody2D     ║
// ║  - CharacterController: component 3D, có gravity, isGrounded║
// ║  - Rigidbody2D: component 2D, dùng cho physics 2D          ║
// ║  - Top-down: gravityScale = 0 (không rơi)                   ║
// ║  - Bỏ hoàn toàn Jump() và gravity logic                     ║
// ╚═══════════════════════════════════════════════════════════════╝

[RequireComponent(typeof(Rigidbody2D))] // THAY ĐỔI: CharacterController → Rigidbody2D
public class PlayerMovement : MonoBehaviour
{
    // ═══════════════════════════════════════════
    //  SERIALIZED FIELDS
    //  [SerializeField] = chỉnh được trong Inspector
    //  private = code khác không truy cập được
    // ═══════════════════════════════════════════
    [Header("Tốc Độ")]
    [SerializeField] private float baseSpeed = 5f;
    [SerializeField] private float runMultiplier = 1.5f;

    [Header("Dash")]
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.15f;
    [SerializeField] private float dashCooldown = 1f;

    // ═══════════════════════════════════════════
    //  PRIVATE FIELDS
    //  THAY ĐỔI: CharacterController _cc → Rigidbody2D _rb
    //  THAY ĐỔI: Vector3 _velocity → Vector2 _moveVelocity
    //  BỎ: gravity, jumpHeight (top-down không cần)
    // ═══════════════════════════════════════════
    private Rigidbody2D _rb;
    private Vector2 _moveVelocity;

    // Dash state
    private bool _isDashing;
    private float _dashTimer;
    private float _dashCooldownTimer;
    private Vector2 _dashDirection;

    // ═══════════════════════════════════════════
    //  PUBLIC PROPERTIES (chỉ đọc từ bên ngoài)
    //  Pattern: Encapsulation — giấu implementation, chỉ expose data cần thiết
    // ═══════════════════════════════════════════
    public bool IsDashing => _isDashing;
    public bool IsMoving => _moveVelocity.sqrMagnitude > 0.01f;

    // ═══════════════════════════════════════════
    //  EVENTS (Observer Pattern)
    //  Ai muốn biết player dash → đăng ký nghe event này
    //  VD: VFX system nghe OnDashStarted → spawn trail effect
    // ═══════════════════════════════════════════
    public System.Action OnDashStarted;
    public System.Action OnDashEnded;

    // ═══════════════════════════════════════════
    //  UNITY LIFECYCLE
    // ═══════════════════════════════════════════

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        // ── SETUP CHO 2D TOP-DOWN ──
        // gravityScale = 0: Camera nhìn từ trên xuống → không có trọng lực
        // (Nếu làm 2D platformer thì để gravityScale = 1)
        _rb.gravityScale = 0f;

        // freezeRotation: Không cho physics xoay sprite khi va chạm
        // (Nếu không set → sprite xoay lung tung khi đụng tường)
        _rb.freezeRotation = true;

        // Continuous: Check va chạm liên tục, tránh xuyên tường khi di chuyển nhanh
        _rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    // ── TẠI SAO DÙNG FixedUpdate() CHỨ KHÔNG PHẢI Update()? ──
    // Update(): chạy mỗi frame, tốc độ thay đổi tuỳ FPS (60fps ≠ 30fps)
    // FixedUpdate(): chạy đều đặn 50 lần/giây, phù hợp cho physics
    // QUY TẮC: Mọi thao tác với Rigidbody/Rigidbody2D → FixedUpdate()
    void FixedUpdate()
    {
        if (_isDashing)
        {
            // Dash: di chuyển với tốc độ cao theo hướng dash
            _rb.linearVelocity = _dashDirection * dashSpeed;
            return; // Không cho movement bình thường override dash
        }

        // Di chuyển bình thường
        // THAY ĐỔI: _cc.Move(direction * speed * deltaTime) → _rb.linearVelocity = velocity
        // CharacterController.Move() di chuyển trực tiếp
        // Rigidbody2D.linearVelocity: set vận tốc, physics engine tự di chuyển
        _rb.linearVelocity = _moveVelocity;
    }

    void Update()
    {
        // Timer xử lý trong Update() (không phải physics)
        if (_isDashing)
        {
            _dashTimer -= Time.deltaTime;
            if (_dashTimer <= 0f)
            {
                _isDashing = false;
                OnDashEnded?.Invoke(); // Observer: thông báo dash kết thúc
            }
        }

        if (_dashCooldownTimer > 0f)
        {
            _dashCooldownTimer -= Time.deltaTime;
        }
    }

    // ═══════════════════════════════════════════
    //  PUBLIC METHODS
    //  Được gọi bởi PlayerController (Component Pattern)
    // ═══════════════════════════════════════════

    /// <summary>
    /// THAY ĐỔI: Move(Vector3, bool) → Move(Vector2, bool)
    /// BỎ: Quaternion.LookRotation (xoay model 3D)
    ///     → 2D không xoay model, PlayerAnimator sẽ flip sprite thay thế
    /// </summary>
    public void Move(Vector2 direction, bool isRunning)
    {
        if (_isDashing) return; // Đang dash → không cho di chuyển thường

        float finalSpeed = baseSpeed * (isRunning ? runMultiplier : 1f);
        _moveVelocity = direction * finalSpeed;

        // KHÔNG CÒN: Quaternion.LookRotation → transform.rotation
        // 2D: Hướng nhìn do PlayerAnimator xử lý (flipX sprite)
    }

    /// <summary>
    /// THAY THẾ cho Jump(): Top-down không nhảy, thay bằng Dash
    /// Dash = lao nhanh theo hướng đang nhìn, dùng để né đòn
    /// </summary>
    public void Dash(Vector2 facingDirection)
    {
        // Guard: không dash nếu đang dash hoặc chưa hết cooldown
        if (_isDashing || _dashCooldownTimer > 0f) return;

        _isDashing = true;
        _dashTimer = dashDuration;
        _dashCooldownTimer = dashCooldown;
        _dashDirection = facingDirection.normalized;

        OnDashStarted?.Invoke(); // Observer: thông báo bắt đầu dash
    }
}
