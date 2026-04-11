namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Simple state machine for enemy AI.
    /// Manages current state transitions: Idle → Patrol → Chase → Attack → Dead.
    /// </summary>
    public class EnemyStateMachine
    {
        // ═══════════════════════════════════════════
        //  FIELDS
        // ═══════════════════════════════════════════
        private IEnemyState _currentState;
        private EnemyBase _owner;

        // ═══════════════════════════════════════════
        //  PROPERTIES
        // ═══════════════════════════════════════════
        public IEnemyState CurrentState => _currentState;
        public EnemyBase Owner => _owner;

        // ═══════════════════════════════════════════
        //  CONSTRUCTOR
        // ═══════════════════════════════════════════

        public EnemyStateMachine(EnemyBase owner)
        {
            // TODO: _owner = owner
        }

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS
        // ═══════════════════════════════════════════

        public void Initialize(IEnemyState startingState)
        {
            // TODO: _currentState = startingState
            // TODO: _currentState.Enter()
        }

        public void ChangeState(IEnemyState newState)
        {
            // TODO: _currentState?.Exit()
            // TODO: _currentState = newState
            // TODO: _currentState.Enter()
        }

        public void Update()
        {
            // TODO: _currentState?.Update()
        }
    }
}
