namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Dead state: enemy death sequence — play animation, drop loot, destroy.
    /// Terminal state — no transitions out.
    /// </summary>
    public class EnemyDeadState : IEnemyState
    {
        private readonly EnemyBase _enemy;
        private readonly EnemyStateMachine _stateMachine;

        public EnemyDeadState(EnemyBase enemy, EnemyStateMachine stateMachine)
        {
            _enemy = enemy;
            _stateMachine = stateMachine;
        }

        public void Enter()  { /* TODO: Disable agent, play death anim, drop loot, Destroy after delay */ }
        public void Update() { /* TODO: Nothing — terminal state */ }
        public void Exit()   { /* TODO: Nothing */ }
    }
}
