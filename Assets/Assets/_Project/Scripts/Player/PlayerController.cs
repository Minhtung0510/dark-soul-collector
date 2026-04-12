using UnityEngine;

// ╔═══════════════════════════════════════════════════════════════╗
// ║  DESIGN PATTERN: Component Pattern — "Controller"            ║
// ║  Vai trò: BỘ NÃO — đọc input từ InputHandler,             ║
// ║           rồi ra lệnh cho Movement (và sau này Combat, Anim)║
// ║                                                               ║
// ║  THAY ĐỔI 3D → 2D:                                         ║
// ║  - Bỏ RequireComponent(CharacterController)                  ║
// ║  - Thêm RequireComponent(Rigidbody2D)                        ║
// ║  - Bỏ Jump → thay bằng Dash                                 ║
// ╚═══════════════════════════════════════════════════════════════╝

[RequireComponent(typeof(PlayerInputHandler))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody2D))]        // THAY ĐỔI: CharacterController → Rigidbody2D
public class PlayerController : MonoBehaviour
{
    // Component references — Controller giữ ref đến các component khác
    private PlayerInputHandler _input;
    private PlayerMovement _movement;

    void Awake()
    {
        _input = GetComponent<PlayerInputHandler>();
        _movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // 1. Di chuyển: đọc input → truyền cho movement
        // THAY ĐỔI: _Input.moveInput (Vector3) → _input.MoveInput (Vector2)
        _movement.Move(_input.MoveInput, _input.IsRunning);

        // 2. Dash (thay thế Jump)
        // THAY ĐỔI: if(jumpPressed) Jump() → if(DashPressed) Dash()
        if (_input.DashPressed)
        {
            _movement.Dash(_input.LastFacingDirection);
        }

        // TODO: Khi bạn code PlayerCombat → thêm attack logic ở đây
        // TODO: Khi bạn code PlayerAnimator → thêm animation update ở đây
    }
}
