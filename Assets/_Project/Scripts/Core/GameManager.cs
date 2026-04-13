using UnityEngine;

namespace IdleSoulSurvivor.Core
{
    /// <summary>
    /// Central game manager - handles game states, initialization, and scene transitions.
    /// Singleton pattern. Persists across scenes.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
