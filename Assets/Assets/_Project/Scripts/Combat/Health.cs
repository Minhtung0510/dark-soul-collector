using UnityEngine;

namespace DarkSoulCollector.Combat
{
    /// <summary>
    /// Reusable health component. Attach to Player, Enemy, or destructibles.
    /// </summary>
    public class Health : MonoBehaviour, IDamageable
    {
        // TODO: maxHealth, currentHealth, OnHealthChanged event

        public void TakeDamage(float amount)
        {
            // TODO: Reduce HP, check death, invoke event
        }

        public void Die()
        {
            // TODO: Death logic, invoke OnDeath event
        }
    }
}
