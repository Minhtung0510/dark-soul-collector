using UnityEngine;

namespace IdleSoulSurvivor.Core
{
    /// <summary>
    /// Manages game time, offline time calculation, and speed multiplier (x1/x2/x4/x8).
    /// Calculates elapsed offline time for idle rewards.
    /// </summary>
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
        }
    }
}
