using UnityEngine;

namespace DarkSoulCollector.Weapons
{
    /// <summary>
    /// Melee weapon: Sword, Spear, Dagger.
    /// Uses Physics.OverlapSphere for 3D hit detection.
    /// </summary>
    public class MeleeWeapon : WeaponBase
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [Header("Melee")]
        [SerializeField] private Transform hitPoint;
        [SerializeField] private float hitRadius = 1f;
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private int comboMaxHits = 3;

        // ═══════════════════════════════════════════
        //  IMPLEMENTATION
        // ═══════════════════════════════════════════

        public override void Attack()
        {
            // TODO: Physics.OverlapSphere(hitPoint.position, hitRadius, targetLayer)
            // TODO: Foreach hit → IDamageable.TakeDamage(GetDamage())
        }

        public override void HeavyAttack()
        {
            // TODO: Larger radius, more damage, possible AoE
        }

        public override float GetDamage()
        {
            // TODO: return baseDamage (+ modifiers from stats/buffs)
            return baseDamage;
        }
    }
}
