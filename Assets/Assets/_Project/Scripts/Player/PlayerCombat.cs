using UnityEngine;

namespace DarkSoulCollector.Player
{
    /// <summary>
    /// Player combat: melee combo system, heavy attack, skill usage.
    /// Uses 3D Physics.OverlapSphere for hit detection.
    /// </summary>
    public class PlayerCombat : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [Header("Light Attack")]
        [SerializeField] private float lightAttackRange = 2f;
        [SerializeField] private float lightAttackDamage = 10f;
        [SerializeField] private float lightAttackStaminaCost = 10f;
        [SerializeField] private float comboWindow = 0.8f;
        [SerializeField] private int maxComboHits = 3;

        [Header("Heavy Attack")]
        [SerializeField] private float heavyAttackRange = 2.5f;
        [SerializeField] private float heavyAttackDamage = 25f;
        [SerializeField] private float heavyAttackStaminaCost = 25f;
        [SerializeField] private float heavyAttackChargeTime = 0.5f;

        [Header("Hit Detection")]
        [SerializeField] private Transform attackPoint;
        [SerializeField] private LayerMask enemyLayer;

        // ═══════════════════════════════════════════
        //  PRIVATE FIELDS
        // ═══════════════════════════════════════════
        private PlayerStats _stats;
        private PlayerAnimator _animator;
        private int _currentComboIndex;
        private float _lastAttackTime;
        private bool _isAttacking;

        // ═══════════════════════════════════════════
        //  PUBLIC PROPERTIES
        // ═══════════════════════════════════════════
        public bool IsAttacking => _isAttacking;
        public int CurrentCombo => _currentComboIndex;

        // ═══════════════════════════════════════════
        //  UNITY LIFECYCLE
        // ═══════════════════════════════════════════

        private void Awake()
        {
            // TODO: Get PlayerStats, PlayerAnimator references
        }

        private void Update()
        {
            // TODO: Check combo window timeout → reset combo
        }

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS (called by PlayerController)
        // ═══════════════════════════════════════════

        /// <summary>
        /// Light attack — part of combo chain (hit 1 → 2 → 3).
        /// </summary>
        public void LightAttack()
        {
            // TODO: Check stamina via _stats.UseStamina()
            // TODO: Advance combo index (wrap at maxComboHits)
            // TODO: _animator.SetAttack(_currentComboIndex)
            // TODO: PerformHitDetection(lightAttackRange, lightAttackDamage)
            // TODO: _lastAttackTime = Time.time
        }

        /// <summary>
        /// Heavy attack — charged, higher damage, breaks guard.
        /// </summary>
        public void HeavyAttack()
        {
            // TODO: Check stamina
            // TODO: _animator.SetHeavyAttack()
            // TODO: PerformHitDetection(heavyAttackRange, heavyAttackDamage)
        }

        /// <summary>
        /// Activate a soul skill by slot index (0-3).
        /// </summary>
        public void UseSkill(int skillIndex)
        {
            // TODO: Get skill from SoulManager
            // TODO: Check cooldown and mana/stamina
            // TODO: Activate skill
        }

        // ═══════════════════════════════════════════
        //  PRIVATE METHODS
        // ═══════════════════════════════════════════

        private void PerformHitDetection(float range, float damage)
        {
            // TODO: Physics.OverlapSphere(attackPoint.position, range, enemyLayer)
            // TODO: For each hit → GetComponent<IDamageable>()?.TakeDamage(damage)
        }

        private void ResetCombo()
        {
            // TODO: _currentComboIndex = 0
        }

        // Called by Animation Event at the end of attack animation
        public void OnAttackAnimationEnd()
        {
            // TODO: _isAttacking = false
        }
    }
}
