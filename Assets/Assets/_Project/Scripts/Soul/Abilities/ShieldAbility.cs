using UnityEngine;

namespace DarkSoulCollector.Soul
{
    /// <summary>
    /// Shield: temporary invincibility with damage reflection.
    /// Shows a 3D shield VFX around the player.
    /// </summary>
    public class ShieldAbility : AbilityBase
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [Header("Shield")]
        [SerializeField] private float shieldDuration = 3f;
        [SerializeField] private float damageReflectionPercent = 0.3f;
        [SerializeField] private GameObject shieldVFXPrefab;

        // ═══════════════════════════════════════════
        //  PRIVATE FIELDS
        // ═══════════════════════════════════════════
        private GameObject _activeShieldVFX;
        private bool _isShieldActive;

        // ═══════════════════════════════════════════
        //  PUBLIC PROPERTIES
        // ═══════════════════════════════════════════
        public bool IsShieldActive => _isShieldActive;

        // ═══════════════════════════════════════════
        //  IMPLEMENTATION
        // ═══════════════════════════════════════════

        public override void Activate()
        {
            // TODO: if (!TryActivate()) return
            // TODO: _isShieldActive = true
            // TODO: Instantiate shieldVFXPrefab as child of player
            // TODO: Start coroutine → deactivate after shieldDuration
        }

        private void DeactivateShield()
        {
            // TODO: _isShieldActive = false
            // TODO: Destroy _activeShieldVFX
        }
    }
}
