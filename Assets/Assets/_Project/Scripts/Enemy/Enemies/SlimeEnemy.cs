using UnityEngine;

namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Slime: basic melee enemy. Low HP, slow, simple attack.
    /// First enemy player encounters — easy to defeat.
    /// </summary>
    public class SlimeEnemy : EnemyBase
    {
        // ═══════════════════════════════════════════
        //  SLIME-SPECIFIC FIELDS
        // ═══════════════════════════════════════════
        [Header("Slime Specific")]
        [SerializeField] private float jumpAttackForce = 5f;
        [SerializeField] private bool splitOnDeath = false;
        [SerializeField] private GameObject smallSlimePrefab;

        // ═══════════════════════════════════════════
        //  IMPLEMENTATION
        // ═══════════════════════════════════════════

        public override void TakeDamage(float amount)
        {
            // TODO: currentHealth -= amount
            // TODO: OnHealthChanged?.Invoke()
            // TODO: Play hit animation, HitFlash
            // TODO: If currentHealth <= 0 → Die()
        }

        public override void Die()
        {
            // TODO: If splitOnDeath → spawn 2 smaller slimes
            // TODO: DropLoot()
            // TODO: Play death animation
            // TODO: Destroy after delay
        }
    }
}
