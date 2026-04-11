using UnityEngine;
using DarkSoulCollector.Combat;

namespace DarkSoulCollector.Weapons
{
    /// <summary>
    /// 3D Projectile behavior: moves forward, hits targets, auto-destroys.
    /// Uses OnTriggerEnter (3D) instead of OnTriggerEnter2D.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Projectile : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [SerializeField] private float speed = 15f;
        [SerializeField] private float damage = 10f;
        [SerializeField] private float lifetime = 5f;
        [SerializeField] private LayerMask targetLayer;

        // ═══════════════════════════════════════════
        //  PRIVATE FIELDS
        // ═══════════════════════════════════════════
        private Rigidbody _rb;
        private Vector3 _direction;

        // ═══════════════════════════════════════════
        //  UNITY LIFECYCLE
        // ═══════════════════════════════════════════

        private void Awake()
        {
            // TODO: _rb = GetComponent<Rigidbody>()
            // TODO: _rb.useGravity = false
        }

        private void Start()
        {
            // TODO: _rb.velocity = _direction * speed
            // TODO: Destroy(gameObject, lifetime)
        }

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS
        // ═══════════════════════════════════════════

        public void Initialize(Vector3 direction, float damageAmount)
        {
            // TODO: _direction = direction.normalized
            // TODO: damage = damageAmount
        }

        // ═══════════════════════════════════════════
        //  3D COLLISION
        // ═══════════════════════════════════════════

        private void OnTriggerEnter(Collider other)
        {
            // TODO: other.GetComponent<IDamageable>()?.TakeDamage(damage)
            // TODO: Spawn hit VFX
            // TODO: Destroy(gameObject)
        }
    }
}
