using UnityEngine;

namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Patrol state: enemy wanders to random NavMesh points.
    /// Transitions to: Chase (if player detected) or Idle (reached waypoint).
    /// </summary>
    public class EnemyPatrolState : IEnemyState
    {
        private readonly EnemyBase _enemy;
        private readonly EnemyStateMachine _stateMachine;
        private Vector3 _targetPoint;

        public EnemyPatrolState(EnemyBase enemy, EnemyStateMachine stateMachine)
        {
            _enemy = enemy;
            _stateMachine = stateMachine;
        }

        public void Enter()  { /* TODO: Pick random point on NavMesh, agent.SetDestination() */ }
        public void Update() { /* TODO: Check arrived → Idle, check player range → Chase */ }
        public void Exit()   { /* TODO: Stop agent */ }
    }
}
