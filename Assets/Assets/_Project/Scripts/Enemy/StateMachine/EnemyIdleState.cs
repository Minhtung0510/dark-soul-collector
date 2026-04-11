namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Idle state: enemy stands still, checks for player in detection range.
    /// Transitions to: Patrol (after wait time) or Chase (if player detected).
    /// </summary>
    public class EnemyIdleState : IEnemyState
    {
        private readonly EnemyBase _enemy;
        private readonly EnemyStateMachine _stateMachine;
        private float _idleTimer;

        public EnemyIdleState(EnemyBase enemy, EnemyStateMachine stateMachine)
        {
            _enemy = enemy;
            _stateMachine = stateMachine;
        }

        public void Enter()  { /* TODO: Reset timer, play idle animation */ }
        public void Update() { /* TODO: Check player range → Chase, or timer → Patrol */ }
        public void Exit()   { /* TODO: Cleanup */ }
    }
}
