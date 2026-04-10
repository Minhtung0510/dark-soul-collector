using UnityEngine;

namespace DarkSoulCollector.Combat
{
    /// <summary>
    /// Contract for entities that can be knocked back.
    /// </summary>
    public interface IKnockbackable
    {
        void ApplyKnockback(Vector2 direction, float force);
    }
}
