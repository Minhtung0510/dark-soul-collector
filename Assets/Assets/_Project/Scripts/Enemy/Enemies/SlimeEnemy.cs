using UnityEngine;

namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Slime: basic melee enemy. Low HP, slow, simple attack.
    /// </summary>
    public class SlimeEnemy : EnemyBase
    {
        public override void TakeDamage(float amount) { }
        public override void Die() { }
    }
}
