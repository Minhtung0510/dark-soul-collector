using UnityEngine;

namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Boss: multi-phase boss with unique attack patterns.
    /// Has a health bar shown in UI, multiple attack phases.
    /// </summary>
    public class BossEnemy : EnemyBase
    {
        // ═══════════════════════════════════════════
        //  BOSS-SPECIFIC FIELDS
        // ═══════════════════════════════════════════
        [Header("Boss Specific")]
        [SerializeField] private string bossName = "Dark Lord";
        [SerializeField] private int totalPhases = 2;
        [SerializeField] private float phase2HealthThreshold = 0.5f;  // 50% HP

        [Header("Phase 2 Buffs")]
        [SerializeField] private float phase2DamageMultiplier = 1.5f;
        [SerializeField] private float phase2SpeedMultiplier = 1.3f;
        [SerializeField] private GameObject phase2VFX;

        // ═══════════════════════════════════════════
        //  PRIVATE FIELDS
        // ═══════════════════════════════════════════
        private int _currentPhase = 1;

        // ═══════════════════════════════════════════
        //  PUBLIC PROPERTIES
        // ═══════════════════════════════════════════
        public string BossName => bossName;
        public int CurrentPhase => _currentPhase;

        // ═══════════════════════════════════════════
        //  EVENTS
        // ═══════════════════════════════════════════
        public System.Action<int> OnPhaseChanged;
        public System.Action OnBossDefeated;

        // ═══════════════════════════════════════════
        //  IMPLEMENTATION
        // ═══════════════════════════════════════════

        public override void TakeDamage(float amount)
        {
            // TODO: currentHealth -= amount
            // TODO: OnHealthChanged?.Invoke()
            // TODO: Check phase transition (HP < threshold → Phase 2)
            // TODO: If currentHealth <= 0 → Die()
        }

        public override void Die()
        {
            // TODO: OnBossDefeated?.Invoke()
            // TODO: Dramatic death sequence
            // TODO: DropLoot() (guaranteed rare drops)
            // TODO: Destroy after delay
        }

        private void TransitionToPhase2()
        {
            // TODO: _currentPhase = 2
            // TODO: Increase damage and speed
            // TODO: Spawn phase2VFX
            // TODO: OnPhaseChanged?.Invoke(2)
        }
    }
}
