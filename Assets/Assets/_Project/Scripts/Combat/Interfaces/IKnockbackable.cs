using UnityEngine;

namespace DarkSoulCollector.Combat
{
    /// <summary>
    /// Contract for entities that can be knocked back.
    /// Uses Vector3 for 3D knockback direction.
    /// </summary>
    public interface IKnockbackable
    {
        void ApplyKnockback(Vector3 direction, float force);
    }
}
