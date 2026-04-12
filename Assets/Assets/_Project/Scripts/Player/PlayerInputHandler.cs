using UnityEngine;

// ╔═══════════════════════════════════════════════════════════════╗
// ║  DESIGN PATTERN: Component Pattern                           ║
// ║  Vai trò: Chỉ ĐỌC input, không xử lý gì khác.             ║
// ║  Controller sẽ đọc data từ đây rồi truyền cho Movement...  ║
// ╚═══════════════════════════════════════════════════════════════╝

public class PlayerInputHandler : MonoBehaviour
{
    // ═══════════════════════════════════════════
    //  THAY ĐỔI 3D → 2D:
    //  - Vector3(h, 0, v) → Vector2(h, v)
    //    Lý do: Top-down 2D dùng X=ngang, Y=dọc (không cần Z)
    //  - Bỏ jumpPressed (top-down không có nhảy)
    //  - Thêm DashPressed, AttackPressed cho 2D combat
    //  - Thêm LastFacingDirection để track hướng nhìn cho animation
    // ═══════════════════════════════════════════

    public Vector2 MoveInput { get; private set; }

    // LastFacingDirection: lưu hướng cuối cùng player nhìn
    // Dùng cho: animation (biết flip sprite nào), attack (đánh hướng nào)
    // Khởi tạo = Vector2.down → nhân vật mặc định nhìn xuống
    public Vector2 LastFacingDirection { get; private set; } = Vector2.down;

    public bool IsRunning { get; private set; }
    public bool AttackPressed { get; private set; }
    public bool DashPressed { get; private set; }
    public bool InteractPressed { get; private set; }

    void Update()
    {
        // ── Đọc input di chuyển ──
        // GetAxisRaw: trả về -1, 0, 1 (không smoothing)
        // → Phản hồi nhanh hơn GetAxis cho pixel art game
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // THAY ĐỔI: Vector3(h, 0f, v) → Vector2(h, v)
        // 3D: x=ngang, y=0(không dùng), z=sâu
        // 2D: x=ngang, y=dọc (Y thay vai trò Z)
        MoveInput = new Vector2(h, v).normalized;

        // ── Cập nhật hướng nhìn ──
        // Chỉ update khi đang thực sự di chuyển
        // sqrMagnitude > 0.01f = kiểm tra có input không (tối ưu hơn magnitude)
        if (MoveInput.sqrMagnitude > 0.01f)
        {
            LastFacingDirection = MoveInput;
        }

        // ── Đọc action inputs ──
        IsRunning = Input.GetKey(KeyCode.LeftShift);
        AttackPressed = Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.J);
        DashPressed = Input.GetKeyDown(KeyCode.Space);  // Space = dash thay vì jump
        InteractPressed = Input.GetKeyDown(KeyCode.E);
    }
}
