using UnityEngine;

namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Ghost: ranged enemy. Passes through walls, shoots projectiles.
    /// </summary>
    public class GhostEnemy : EnemyBase
    {
        public override void TakeDamage(float amount) { }
        public override void Die() { }
    }
}
