using UnityEngine;

namespace DarkSoulCollector.Weapons
{
    /// <summary>
    /// Ranged weapon: spawns 3D projectiles. Bow, Crossbow, etc.
    /// </summary>
    public class RangedWeapon : WeaponBase
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [Header("Ranged")]
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform firePoint;
        [SerializeField] private float projectileSpeed = 20f;

        // ═══════════════════════════════════════════
        //  IMPLEMENTATION
        // ═══════════════════════════════════════════

        public override void Attack()
        {
            // TODO: Instantiate projectilePrefab at firePoint
            // TODO: Set projectile direction (forward) and speed
        }

        public override void HeavyAttack()
        {
            // TODO: Charged shot — more damage, maybe piercing
        }

        public override float GetDamage()
        {
            // TODO: return baseDamage
            return baseDamage;
        }
    }
}
