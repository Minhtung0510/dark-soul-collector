using UnityEngine;

namespace DarkSoulCollector.Camera
{
    /// <summary>
    /// Third-person camera (Dark Souls style).
    /// Follows player, orbits with mouse, collision avoidance.
    /// Attach to a separate Camera GameObject, NOT on the player.
    /// </summary>
    public class ThirdPersonCamera : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [Header("Target")]
        [SerializeField] private Transform target;       // Player transform
        [SerializeField] private Vector3 offset = new Vector3(0f, 2f, -5f);

        [Header("Orbital")]
        [SerializeField] private float mouseSensitivity = 3f;
        [SerializeField] private float minPitch = -20f;
        [SerializeField] private float maxPitch = 60f;
        [SerializeField] private float orbitSmoothing = 10f;

        [Header("Collision")]
        [SerializeField] private float collisionRadius = 0.3f;
        [SerializeField] private LayerMask collisionLayers;

        [Header("Lock-On")]
        [SerializeField] private float lockOnRange = 20f;
        [SerializeField] private LayerMask lockOnTargetLayer;

        // ═══════════════════════════════════════════
        //  PRIVATE FIELDS
        // ═══════════════════════════════════════════
        private float _yaw;      // Horizontal rotation
        private float _pitch;    // Vertical rotation
        private Transform _lockOnTarget;
        private bool _isLockedOn;

        // ═══════════════════════════════════════════
        //  PUBLIC PROPERTIES
        // ═══════════════════════════════════════════
        public bool IsLockedOn => _isLockedOn;
        public Transform LockOnTarget => _lockOnTarget;

        // ═══════════════════════════════════════════
        //  UNITY LIFECYCLE
        // ═══════════════════════════════════════════

        private void Start()
        {
            // TODO: Cursor.lockState = CursorLockMode.Locked
            // TODO: Initialize _yaw, _pitch from current rotation
        }

        private void LateUpdate()
        {
            // TODO: If locked on → LockOnUpdate()
            // TODO: Else → FreeLookUpdate()
            // TODO: HandleCollision()
        }

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS
        // ═══════════════════════════════════════════

        /// <summary>
        /// Toggle lock-on to nearest enemy.
        /// </summary>
        public void ToggleLockOn()
        {
            // TODO: If _isLockedOn → release
            // TODO: Else → Physics.OverlapSphere to find nearest enemy
            // TODO: Set _lockOnTarget
        }

        // ═══════════════════════════════════════════
        //  PRIVATE METHODS
        // ═══════════════════════════════════════════

        private void FreeLookUpdate()
        {
            // TODO: Read mouse X/Y → _yaw, _pitch
            // TODO: Clamp _pitch between minPitch and maxPitch
            // TODO: Calculate rotation from _yaw/_pitch
            // TODO: Position = target.position + rotation * offset
            // TODO: LookAt target
        }

        private void LockOnUpdate()
        {
            // TODO: Look at midpoint between player and _lockOnTarget
            // TODO: Keep camera behind player relative to target
        }

        private void HandleCollision()
        {
            // TODO: Raycast from target to desired camera position
            // TODO: If hit → move camera closer to avoid clipping through walls
        }
    }
}
