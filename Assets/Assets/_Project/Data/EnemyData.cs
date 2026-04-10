using UnityEngine;

namespace DarkSoulCollector.Data
{
    /// <summary>
    /// ScriptableObject: enemy configuration (HP, ATK, speed, detection range).
    /// </summary>
    [CreateAssetMenu(fileName = "NewEnemy", menuName = "DarkSoulCollector/Data/Enemy")]
    public class EnemyData : ScriptableObject
    {
        public string enemyName;
        public float maxHealth;
        public float damage;
        public float moveSpeed;
        public float detectionRange;
        public float attackRange;
        public Sprite icon;
        // TODO: loot table reference, soul drop chance
    }
}
