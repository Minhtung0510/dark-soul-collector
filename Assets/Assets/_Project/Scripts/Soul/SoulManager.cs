using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkSoulCollector.Soul
{
    /// <summary>
    /// Manages collected souls and unlocked abilities.
    /// Central manager for the soul/skill system.
    /// </summary>
    public class SoulManager : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [Header("Ability Slots")]
        [SerializeField] private int maxAbilitySlots = 4;

        // ═══════════════════════════════════════════
        //  PRIVATE FIELDS
        // ═══════════════════════════════════════════
        private List<AbilityBase> _unlockedAbilities = new List<AbilityBase>();
        private AbilityBase[] _equippedAbilities;  // Fixed size = maxAbilitySlots
        private int _soulCount;

        // ═══════════════════════════════════════════
        //  PUBLIC PROPERTIES
        // ═══════════════════════════════════════════
        public int SoulCount => _soulCount;
        public IReadOnlyList<AbilityBase> UnlockedAbilities => _unlockedAbilities;
        public AbilityBase[] EquippedAbilities => _equippedAbilities;

        // ═══════════════════════════════════════════
        //  EVENTS
        // ═══════════════════════════════════════════
        public event Action<int> OnSoulCountChanged;
        public event Action<AbilityBase> OnAbilityUnlocked;

        // ═══════════════════════════════════════════
        //  UNITY LIFECYCLE
        // ═══════════════════════════════════════════

        private void Awake()
        {
            // TODO: _equippedAbilities = new AbilityBase[maxAbilitySlots]
        }

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS
        // ═══════════════════════════════════════════

        public void CollectSoul(int amount)
        {
            // TODO: _soulCount += amount
            // TODO: OnSoulCountChanged?.Invoke(_soulCount)
        }

        public void UnlockAbility(AbilityBase ability)
        {
            // TODO: Add to _unlockedAbilities
            // TODO: OnAbilityUnlocked?.Invoke(ability)
        }

        public void EquipAbility(AbilityBase ability, int slotIndex)
        {
            // TODO: Validate slotIndex
            // TODO: _equippedAbilities[slotIndex] = ability
        }

        public void UseAbility(int slotIndex)
        {
            // TODO: _equippedAbilities[slotIndex]?.Activate()
        }
    }
}
