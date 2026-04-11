using UnityEngine;

namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Ghost: ranged enemy. Can pass through obstacles, shoots projectiles.
    /// </summary>
    public class GhostEnemy : EnemyBase
    {
        // ═══════════════════════════════════════════
        //  GHOST-SPECIFIC FIELDS
        // ═══════════════════════════════════════════
        [Header("Ghost Specific")]
        [SerializeField] private GameObject ghostProjectilePrefab;
        [SerializeField] private Transform firePoint;
        [SerializeField] private float projectileSpeed = 10f;
        [SerializeField] private float floatHeight = 1.5f;
        [SerializeField] private bool canPhaseThrough = true;

        // ═══════════════════════════════════════════
        //  IMPLEMENTATION
        // ═══════════════════════════════════════════

        public override void TakeDamage(float amount)
        {
            // TODO: currentHealth -= amount
            // TODO: OnHealthChanged?.Invoke()
            // TODO: If currentHealth <= 0 → Die()
        }

        public override void Die()
        {
            // TODO: DropLoot()
            // TODO: Fade out effect
            // TODO: Destroy after delay
        }
    }
}
