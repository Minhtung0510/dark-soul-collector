using UnityEngine;

namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Spawns enemies in the arena/area. Supports wave-based spawning.
    /// Uses spawn points placed in scene.
    /// </summary>
    public class EnemySpawner : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [Header("Spawn Config")]
        [SerializeField] private GameObject[] enemyPrefabs;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private int maxEnemies = 10;
        [SerializeField] private float spawnInterval = 3f;

        [Header("Wave Config")]
        [SerializeField] private int enemiesPerWave = 5;
        [SerializeField] private float timeBetweenWaves = 10f;

        // ═══════════════════════════════════════════
        //  PRIVATE FIELDS
        // ═══════════════════════════════════════════
        private int _currentWave;
        private int _activeEnemyCount;

        // ═══════════════════════════════════════════
        //  PUBLIC PROPERTIES
        // ═══════════════════════════════════════════
        public int CurrentWave => _currentWave;
        public int ActiveEnemies => _activeEnemyCount;

        // ═══════════════════════════════════════════
        //  EVENTS
        // ═══════════════════════════════════════════
        public System.Action<int> OnWaveStarted;
        public System.Action<int> OnWaveCompleted;

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS
        // ═══════════════════════════════════════════

        public void StartSpawning()
        {
            // TODO: Start coroutine to spawn waves
        }

        public void SpawnWave()
        {
            // TODO: Spawn enemiesPerWave enemies at random spawnPoints
            // TODO: _currentWave++
            // TODO: OnWaveStarted?.Invoke(_currentWave)
        }

        public void StopSpawning()
        {
            // TODO: Stop all coroutines
        }

        public void OnEnemyDied()
        {
            // TODO: _activeEnemyCount--
            // TODO: If _activeEnemyCount <= 0 → OnWaveCompleted?.Invoke()
        }
    }
}
