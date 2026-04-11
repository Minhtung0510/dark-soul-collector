namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Chase state: enemy pursues player using NavMeshAgent.
    /// Transitions to: Attack (in attack range) or Idle (lost player).
    /// </summary>
    public class EnemyChaseState : IEnemyState
    {
        private readonly EnemyBase _enemy;
        private readonly EnemyStateMachine _stateMachine;

        public EnemyChaseState(EnemyBase enemy, EnemyStateMachine stateMachine)
        {
            _enemy = enemy;
            _stateMachine = stateMachine;
        }

        public void Enter()  { /* TODO: agent.SetDestination(player), play run anim */ }
        public void Update() { /* TODO: Update destination, check attack range → Attack, check lost → Idle */ }
        public void Exit()   { /* TODO: Stop agent */ }
    }
}
