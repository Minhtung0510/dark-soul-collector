using UnityEngine;

namespace DarkSoulCollector.Weapons
{
    /// <summary>
    /// Abstract base class for all weapons. Defines attack interface.
    /// </summary>
    public abstract class WeaponBase : MonoBehaviour
    {
        // TODO: weaponData (ScriptableObject), Attack(), GetDamage()
        public abstract void Attack();
    }
}
