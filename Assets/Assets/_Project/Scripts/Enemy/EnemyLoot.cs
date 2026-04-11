using UnityEngine;

namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Handles loot drops when enemy dies.
    /// Drops items, souls, gold at 3D world position.
    /// </summary>
    public class EnemyLoot : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [Header("Loot Table")]
        [SerializeField] private GameObject[] lootPrefabs;
        [SerializeField] [Range(0, 1)] private float dropChance = 0.5f;
        [SerializeField] private int minGold = 5;
        [SerializeField] private int maxGold = 20;
        [SerializeField] private float soulAmount = 10f;

        [Header("Drop Physics")]
        [SerializeField] private float dropForce = 3f;
        [SerializeField] private float dropRadius = 1f;

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS
        // ═══════════════════════════════════════════

        public void DropLoot()
        {
            // TODO: Random.value < dropChance → Instantiate random lootPrefab
            // TODO: Apply small upward/outward force for visual pop
            // TODO: Drop gold (Random.Range(minGold, maxGold))
            // TODO: Grant soul to player (soulAmount)
        }
    }
}
