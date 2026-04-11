using UnityEngine;

namespace DarkSoulCollector.Weapons
{
    /// <summary>
    /// Abstract base class for all 3D weapons.
    /// Uses ScriptableObject for weapon data (damage, range, speed, type).
    /// </summary>
    public abstract class WeaponBase : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [Header("Weapon Data")]
        [SerializeField] protected string weaponName = "Weapon";
        [SerializeField] protected float baseDamage = 10f;
        [SerializeField] protected float attackSpeed = 1f;
        [SerializeField] protected float range = 2f;
        [SerializeField] protected float staminaCost = 10f;

        // ═══════════════════════════════════════════
        //  PUBLIC PROPERTIES
        // ═══════════════════════════════════════════
        public string WeaponName => weaponName;
        public float BaseDamage => baseDamage;
        public float AttackSpeed => attackSpeed;
        public float Range => range;

        // ═══════════════════════════════════════════
        //  ABSTRACT METHODS (implement in MeleeWeapon / RangedWeapon)
        // ═══════════════════════════════════════════
        public abstract void Attack();
        public abstract void HeavyAttack();
        public abstract float GetDamage();
    }
}
