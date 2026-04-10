using UnityEngine;
using DarkSoulCollector.Combat;

namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Abstract base class for all enemies. Contains shared logic.
    /// Concrete enemies (Slime, Skeleton...) inherit from this.
    /// </summary>
    public abstract class EnemyBase : MonoBehaviour, IDamageable
    {
        // TODO: health, stateMachine, detection range, attack range

        public abstract void TakeDamage(float amount);
        public abstract void Die();
    }
}
