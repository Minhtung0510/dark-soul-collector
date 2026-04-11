namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Attack state: enemy attacks player when in range.
    /// Transitions to: Chase (player moved away) or Dead (killed).
    /// </summary>
    public class EnemyAttackState : IEnemyState
    {
        private readonly EnemyBase _enemy;
        private readonly EnemyStateMachine _stateMachine;
        private float _attackTimer;

        public EnemyAttackState(EnemyBase enemy, EnemyStateMachine stateMachine)
        {
            _enemy = enemy;
            _stateMachine = stateMachine;
        }

        public void Enter()  { /* TODO: Stop agent, face player, play attack anim */ }
        public void Update() { /* TODO: Attack cooldown, deal damage, check range → Chase */ }
        public void Exit()   { /* TODO: Reset timer */ }
    }
}
