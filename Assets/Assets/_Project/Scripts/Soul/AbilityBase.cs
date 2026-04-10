using UnityEngine;

namespace DarkSoulCollector.Soul
{
    /// <summary>
    /// Abstract base class for abilities. Defines cooldown and activation.
    /// </summary>
    public abstract class AbilityBase : MonoBehaviour
    {
        // TODO: cooldown, isReady, Activate(), OnCooldown()
        public abstract void Activate();
    }
}
