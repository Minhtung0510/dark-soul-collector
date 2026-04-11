using UnityEngine;

namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Skeleton: medium enemy. Sword attack, patrol behavior, guard stance.
    /// </summary>
    public class SkeletonEnemy : EnemyBase
    {
        // ═══════════════════════════════════════════
        //  SKELETON-SPECIFIC FIELDS
        // ═══════════════════════════════════════════
        [Header("Skeleton Specific")]
        [SerializeField] private bool canBlock = true;
        [SerializeField] [Range(0, 1)] private float blockChance = 0.3f;
        [SerializeField] private float blockDamageReduction = 0.5f;

        // ═══════════════════════════════════════════
        //  IMPLEMENTATION
        // ═══════════════════════════════════════════

        public override void TakeDamage(float amount)
        {
            // TODO: Check if blocking → reduce damage
            // TODO: currentHealth -= finalDamage
            // TODO: OnHealthChanged?.Invoke()
            // TODO: If currentHealth <= 0 → Die()
        }

        public override void Die()
        {
            // TODO: DropLoot()
            // TODO: Play death animation (collapse into pile of bones)
            // TODO: Destroy after delay
        }
    }
}
