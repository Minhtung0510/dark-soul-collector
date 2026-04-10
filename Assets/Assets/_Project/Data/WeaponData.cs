using UnityEngine;

namespace DarkSoulCollector.Data
{
    /// <summary>
    /// ScriptableObject: weapon stats (name, damage, speed, range, sprite).
    /// </summary>
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "DarkSoulCollector/Data/Weapon")]
    public class WeaponData : ScriptableObject
    {
        public string weaponName;
        public float damage;
        public float attackSpeed;
        public float range;
        public Sprite icon;
        // TODO: weapon type enum, combo data, special effects
    }
}
