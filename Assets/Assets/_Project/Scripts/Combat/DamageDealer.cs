using UnityEngine;

namespace DarkSoulCollector.Combat
{
    /// <summary>
    /// Component attached to weapon hitboxes. Deals damage on 3D trigger collision.
    /// Uses OnTriggerEnter (3D) instead of OnTriggerEnter2D.
    /// </summary>
    public class DamageDealer : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [SerializeField] private float damage = 10f;
        [SerializeField] private float knockbackForce = 5f;

        // ═══════════════════════════════════════════
        //  PUBLIC PROPERTIES
        // ═══════════════════════════════════════════
        public float Damage { get => damage; set => damage = value; }

        // ═══════════════════════════════════════════
        //  3D COLLISION
        // ═══════════════════════════════════════════

        private void OnTriggerEnter(Collider other)
        {
            // TODO: other.GetComponent<IDamageable>()?.TakeDamage(damage)
            // TODO: Apply knockback if IKnockbackable
        }
    }
}
