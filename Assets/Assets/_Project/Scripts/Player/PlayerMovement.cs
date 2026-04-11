using UnityEngine;

namespace DarkSoulCollector.Player
{
    /// <summary>
    /// 3D Player movement using CharacterController.
    /// Handles: walk, run, dash/dodge roll, gravity.
    /// Movement is relative to camera forward direction (Dark Souls style).
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS (tunable in Inspector)
        // ═══════════════════════════════════════════
        [Header("Movement")]
        [SerializeField] private float walkSpeed = 4f;
        [SerializeField] private float runSpeed = 7f;
        [SerializeField] private float rotationSpeed = 10f;

        [Header("Dash / Dodge Roll")]
        [SerializeField] private float dashSpeed = 15f;
        [SerializeField] private float dashDuration = 0.3f;
        [SerializeField] private float dashCooldown = 1f;
        [SerializeField] private float dashStaminaCost = 20f;

        [Header("Gravity")]
        [SerializeField] private float gravity = -20f;
        [SerializeField] private float groundCheckDistance = 0.3f;
        [SerializeField] private LayerMask groundLayer;

        // ═══════════════════════════════════════════
        //  PRIVATE FIELDS
        // ═══════════════════════════════════════════
        private CharacterController _cc;
        private Transform _cameraTransform;
        private Vector3 _velocity;
        private bool _isGrounded;
        private bool _isDashing;

        // ═══════════════════════════════════════════
        //  PUBLIC PROPERTIES
        // ═══════════════════════════════════════════
        public bool IsGrounded => _isGrounded;
        public bool IsDashing => _isDashing;
        public bool IsMoving => _cc != null && _cc.velocity.magnitude > 0.1f;
        public float CurrentSpeed { get; private set; }

        // ═══════════════════════════════════════════
        //  UNITY LIFECYCLE
        // ═══════════════════════════════════════════

        private void Awake()
        {
            // TODO: GetComponent<CharacterController>()
            // TODO: Cache Camera.main.transform
        }

        private void Update()
        {
            // TODO: CheckGrounded()
            // TODO: ApplyGravity()
        }

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS (called by PlayerController)
        // ═══════════════════════════════════════════

        /// <summary>
        /// Move player relative to camera direction. Rotates player to face movement direction.
        /// </summary>
        /// <param name="input">Raw input from PlayerInputHandler (x = horizontal, z = forward)</param>
        /// <param name="isRunning">True if player is holding run button</param>
        public void Move(Vector3 input, bool isRunning = false)
        {
            // TODO: Convert input to camera-relative direction
            // TODO: CharacterController.Move(direction * speed * Time.deltaTime)
            // TODO: Rotate player to face movement direction (Quaternion.LookRotation)
        }

        /// <summary>
        /// Dash/dodge roll in current movement direction. Costs stamina.
        /// </summary>
        /// <param name="direction">Dash direction (camera-relative)</param>
        public void Dash(Vector3 direction)
        {
            // TODO: Start dash coroutine
            // TODO: Set _isDashing = true for duration
            // TODO: Move at dashSpeed for dashDuration
            // TODO: Check dashCooldown
        }

        // ═══════════════════════════════════════════
        //  PRIVATE METHODS
        // ═══════════════════════════════════════════

        private void CheckGrounded()
        {
            // TODO: SphereCast or CharacterController.isGrounded
        }

        private void ApplyGravity()
        {
            // TODO: If grounded, reset _velocity.y
            // TODO: _velocity.y += gravity * Time.deltaTime
            // TODO: _cc.Move(_velocity * Time.deltaTime)
        }

        /// <summary>
        /// Converts raw input to camera-relative world direction.
        /// </summary>
        private Vector3 GetCameraRelativeDirection(Vector3 input)
        {
            // TODO: Get camera forward/right (flatten Y)
            // TODO: Return (camForward * input.z + camRight * input.x).normalized
            return Vector3.zero;
        }
    }
}
