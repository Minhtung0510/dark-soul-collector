using UnityEngine;

namespace DarkSoulCollector.Combat
{
    /// <summary>
    /// Handles 3D knockback using CharacterController or Rigidbody.
    /// </summary>
    public class KnockbackHandler : MonoBehaviour, IKnockbackable
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [SerializeField] private float knockbackDuration = 0.2f;
        [SerializeField] private float knockbackDecay = 5f;

        // ═══════════════════════════════════════════
        //  PRIVATE FIELDS
        // ═══════════════════════════════════════════
        private CharacterController _cc;
        private Vector3 _knockbackVelocity;
        private bool _isKnockedBack;

        // ═══════════════════════════════════════════
        //  PUBLIC PROPERTIES
        // ═══════════════════════════════════════════
        public bool IsKnockedBack => _isKnockedBack;

        // ═══════════════════════════════════════════
        //  UNITY LIFECYCLE
        // ═══════════════════════════════════════════

        private void Awake()
        {
            // TODO: _cc = GetComponent<CharacterController>()
        }

        private void Update()
        {
            // TODO: If _isKnockedBack → apply _knockbackVelocity via _cc.Move()
            // TODO: Decay _knockbackVelocity over time
            // TODO: When magnitude < threshold → _isKnockedBack = false
        }

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS
        // ═══════════════════════════════════════════

        public void ApplyKnockback(Vector3 direction, float force)
        {
            // TODO: _knockbackVelocity = direction.normalized * force
            // TODO: _isKnockedBack = true
        }
    }
}
