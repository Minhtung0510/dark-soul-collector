using UnityEngine;
using UnityEngine.AI;
using DarkSoulCollector.Combat;

namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Abstract base class for all 3D enemies.
    /// Uses NavMeshAgent for pathfinding, state machine for AI.
    /// Concrete enemies (Slime, Skeleton, Boss...) inherit from this.
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class EnemyBase : MonoBehaviour, IDamageable
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [Header("Stats")]
        [SerializeField] protected float maxHealth = 50f;
        [SerializeField] protected float attackDamage = 10f;
        [SerializeField] protected float attackRange = 2f;
        [SerializeField] protected float attackCooldown = 1.5f;

        [Header("Detection")]
        [SerializeField] protected float detectionRange = 10f;
        [SerializeField] protected float loseTargetRange = 15f;
        [SerializeField] protected LayerMask playerLayer;

        [Header("Patrol")]
        [SerializeField] protected float patrolRadius = 8f;
        [SerializeField] protected float patrolWaitTime = 2f;

        [Header("Loot")]
        [SerializeField] protected float experienceReward = 25f;
        [SerializeField] protected GameObject[] lootPrefabs;
        [SerializeField] [Range(0, 1)] protected float lootDropChance = 0.5f;

        // ═══════════════════════════════════════════
        //  PROTECTED FIELDS (accessible by child classes)
        // ═══════════════════════════════════════════
        protected NavMeshAgent agent;
        protected Animator animator;
        protected EnemyStateMachine stateMachine;
        protected Transform playerTransform;
        protected float currentHealth;

        // ═══════════════════════════════════════════
        //  PUBLIC PROPERTIES
        // ═══════════════════════════════════════════
        public float CurrentHealth => currentHealth;
        public float MaxHealth => maxHealth;
        public bool IsAlive => currentHealth > 0;
        public float DetectionRange => detectionRange;
        public float AttackRange => attackRange;
        public float AttackDamage => attackDamage;
        public Transform PlayerTransform => playerTransform;
        public NavMeshAgent Agent => agent;
        public Animator Animator => animator;

        // ═══════════════════════════════════════════
        //  EVENTS
        // ═══════════════════════════════════════════
        public System.Action<float, float> OnHealthChanged;  // (current, max)
        public System.Action OnDied;

        // ═══════════════════════════════════════════
        //  UNITY LIFECYCLE
        // ═══════════════════════════════════════════

        protected virtual void Awake()
        {
            // TODO: agent = GetComponent<NavMeshAgent>()
            // TODO: animator = GetComponentInChildren<Animator>()
            // TODO: Initialize stateMachine
            // TODO: currentHealth = maxHealth
        }

        protected virtual void Start()
        {
            // TODO: Find player reference (GameObject.FindWithTag("Player"))
            // TODO: Set initial state to Idle
        }

        protected virtual void Update()
        {
            // TODO: stateMachine.Update()
            // TODO: Check if player is in detection range
        }

        // ═══════════════════════════════════════════
        //  IDamageable IMPLEMENTATION
        // ═══════════════════════════════════════════

        public abstract void TakeDamage(float amount);
        public abstract void Die();

        // ═══════════════════════════════════════════
        //  HELPER METHODS
        // ═══════════════════════════════════════════

        public bool IsPlayerInRange(float range)
        {
            // TODO: Check Vector3.Distance to playerTransform
            return false;
        }

        protected void DropLoot()
        {
            // TODO: RNG check lootDropChance
            // TODO: Instantiate random loot from lootPrefabs at position
        }

        // ═══════════════════════════════════════════
        //  GIZMOS (debug visualization)
        // ═══════════════════════════════════════════

        protected virtual void OnDrawGizmosSelected()
        {
            // TODO: Draw detection range (yellow sphere)
            // TODO: Draw attack range (red sphere)
        }
    }
}
