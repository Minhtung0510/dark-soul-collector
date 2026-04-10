namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Enemy stands still. Transitions to Patrol or Chase on detection.
    /// </summary>
    public class EnemyIdleState : IEnemyState
    {
        public void Enter() { }
        public void Update() { }
        public void Exit() { }
    }
}
