using System;
using UnityEngine;

namespace DarkSoulCollector.Player
{
    /// <summary>
    /// Player stats: HP, Stamina, ATK, DEF, Speed.
    /// Fires events when stats change — UI subscribes to these.
    /// </summary>
    public class PlayerStats : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [Header("Health")]
        [SerializeField] private float maxHealth = 100f;

        [Header("Stamina")]
        [SerializeField] private float maxStamina = 100f;
        [SerializeField] private float staminaRegenRate = 15f;
        [SerializeField] private float staminaRegenDelay = 1f;

        [Header("Combat Stats")]
        [SerializeField] private float baseAttack = 10f;
        [SerializeField] private float baseDefense = 5f;
        [SerializeField] private float moveSpeed = 5f;

        [Header("Level")]
        [SerializeField] private int level = 1;
        [SerializeField] private float experience = 0f;
        [SerializeField] private float experienceToNextLevel = 100f;

        // ═══════════════════════════════════════════
        //  PROPERTIES
        // ═══════════════════════════════════════════
        public float CurrentHealth { get; private set; }
        public float MaxHealth => maxHealth;
        public float CurrentStamina { get; private set; }
        public float MaxStamina => maxStamina;
        public float Attack => baseAttack;
        public float Defense => baseDefense;
        public float MoveSpeed => moveSpeed;
        public int Level => level;
        public float Experience => experience;

        // ═══════════════════════════════════════════
        //  EVENTS (UI subscribes to these)
        // ═══════════════════════════════════════════
        public event Action<float, float> OnHealthChanged;   // (current, max)
        public event Action<float, float> OnStaminaChanged;  // (current, max)
        public event Action OnDeath;
        public event Action<int> OnLevelUp;                  // (newLevel)
        public event Action<float> OnExperienceGained;       // (amount)

        // ═══════════════════════════════════════════
        //  UNITY LIFECYCLE
        // ═══════════════════════════════════════════

        private void Awake()
        {
            // TODO: Initialize CurrentHealth = maxHealth
            // TODO: Initialize CurrentStamina = maxStamina
        }

        private void Update()
        {
            // TODO: RegenerateStamina() — regen over time after delay
        }

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS
        // ═══════════════════════════════════════════

        public void TakeDamage(float rawDamage)
        {
            // TODO: float finalDamage = rawDamage - baseDefense (min 1)
            // TODO: CurrentHealth -= finalDamage
            // TODO: Clamp to 0
            // TODO: OnHealthChanged?.Invoke(CurrentHealth, maxHealth)
            // TODO: If CurrentHealth <= 0 → OnDeath?.Invoke()
        }

        public void Heal(float amount)
        {
            // TODO: CurrentHealth += amount, clamp to maxHealth
            // TODO: OnHealthChanged?.Invoke()
        }

        public bool UseStamina(float amount)
        {
            // TODO: If CurrentStamina < amount → return false
            // TODO: CurrentStamina -= amount
            // TODO: OnStaminaChanged?.Invoke()
            // TODO: return true
            return false;
        }

        public void AddExperience(float amount)
        {
            // TODO: experience += amount
            // TODO: OnExperienceGained?.Invoke(amount)
            // TODO: Check level up → OnLevelUp?.Invoke()
        }

        private void RegenerateStamina()
        {
            // TODO: After staminaRegenDelay, regen staminaRegenRate per second
            // TODO: Clamp to maxStamina
            // TODO: OnStaminaChanged?.Invoke()
        }

        private void LevelUp()
        {
            // TODO: level++, increase stats, reset experience
        }
    }
}
