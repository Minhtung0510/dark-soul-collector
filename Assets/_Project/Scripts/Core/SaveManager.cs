using UnityEngine;

namespace IdleSoulSurvivor.Core
{
    /// <summary>
    /// Handles save/load game data using JSON serialization.
    /// Manages player progress, inventory, minions, research, buildings.
    /// </summary>
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
        }
    }
}
