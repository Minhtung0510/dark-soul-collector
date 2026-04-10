using UnityEngine;

namespace DarkSoulCollector.Combat
{
    /// <summary>
    /// Handles knockback physics using Rigidbody2D.
    /// </summary>
    public class KnockbackHandler : MonoBehaviour, IKnockbackable
    {
        public void ApplyKnockback(Vector2 direction, float force)
        {
            // TODO: Apply force via Rigidbody2D
        }
    }
}
