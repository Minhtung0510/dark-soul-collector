namespace DarkSoulCollector.Enemy
{
    /// <summary>
    /// Interface for enemy AI states. Each state handles Enter/Update/Exit.
    /// </summary>
    public interface IEnemyState
    {
        void Enter();
        void Update();
        void Exit();
    }
}
