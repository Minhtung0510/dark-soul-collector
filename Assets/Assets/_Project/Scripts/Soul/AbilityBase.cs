using System;
using UnityEngine;

namespace DarkSoulCollector.Soul
{
    /// <summary>
    /// Abstract base class for all soul abilities.
    /// Defines cooldown, mana cost, and activation interface.
    /// </summary>
    public abstract class AbilityBase : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [Header("Ability Info")]
        [SerializeField] protected string abilityName = "Ability";
        [SerializeField] [TextArea] protected string description;
        [SerializeField] protected Sprite icon;

        [Header("Cost & Cooldown")]
        [SerializeField] protected float cooldownTime = 5f;
        [SerializeField] protected float staminaCost = 20f;

        [Header("VFX")]
        [SerializeField] protected GameObject vfxPrefab;

        // ═══════════════════════════════════════════
        //  PRIVATE FIELDS
        // ═══════════════════════════════════════════
        protected float _lastActivationTime = -999f;

        // ═══════════════════════════════════════════
        //  PUBLIC PROPERTIES
        // ═══════════════════════════════════════════
        public string AbilityName => abilityName;
        public string Description => description;
        public Sprite Icon => icon;
        public float CooldownTime => cooldownTime;
        public float StaminaCost => staminaCost;
        public bool IsReady => Time.time >= _lastActivationTime + cooldownTime;
        public float CooldownRemaining => Mathf.Max(0, (_lastActivationTime + cooldownTime) - Time.time);

        // ═══════════════════════════════════════════
        //  EVENTS
        // ═══════════════════════════════════════════
        public event Action OnActivated;
        public event Action OnCooldownComplete;

        // ═══════════════════════════════════════════
        //  ABSTRACT METHODS
        // ═══════════════════════════════════════════

        /// <summary>
        /// Execute the ability effect. Override in each concrete ability.
        /// </summary>
        public abstract void Activate();

        // ═══════════════════════════════════════════
        //  PROTECTED HELPERS
        // ═══════════════════════════════════════════

        protected bool TryActivate()
        {
            // TODO: Check IsReady
            // TODO: Check stamina via PlayerStats
            // TODO: _lastActivationTime = Time.time
            // TODO: OnActivated?.Invoke()
            // TODO: return true
            return false;
        }

        protected void SpawnVFX(Vector3 position)
        {
            // TODO: If vfxPrefab != null → Instantiate at position
        }
    }
}
