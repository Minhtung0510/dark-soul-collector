using UnityEngine;

namespace DarkSoulCollector.Weapons
{
    /// <summary>
    /// Manages the currently equipped weapon on the player.
    /// Handles weapon swap, attachment to hand bone, and weapon reference.
    /// </summary>
    public class WeaponHolder : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [SerializeField] private Transform weaponSocket;  // Hand bone transform
        [SerializeField] private WeaponBase startingWeapon;

        // ═══════════════════════════════════════════
        //  PRIVATE FIELDS
        // ═══════════════════════════════════════════
        private WeaponBase _currentWeapon;

        // ═══════════════════════════════════════════
        //  PUBLIC PROPERTIES
        // ═══════════════════════════════════════════
        public WeaponBase CurrentWeapon => _currentWeapon;
        public bool HasWeapon => _currentWeapon != null;

        // ═══════════════════════════════════════════
        //  UNITY LIFECYCLE
        // ═══════════════════════════════════════════

        private void Start()
        {
            // TODO: If startingWeapon != null → EquipWeapon(startingWeapon)
        }

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS
        // ═══════════════════════════════════════════

        public void EquipWeapon(WeaponBase weapon)
        {
            // TODO: Unequip current weapon
            // TODO: Instantiate new weapon as child of weaponSocket
            // TODO: _currentWeapon = instantiated weapon
        }

        public void UnequipWeapon()
        {
            // TODO: Destroy _currentWeapon gameObject
            // TODO: _currentWeapon = null
        }

        public void SwapWeapon(WeaponBase newWeapon)
        {
            // TODO: UnequipWeapon() → EquipWeapon(newWeapon)
        }
    }
}
