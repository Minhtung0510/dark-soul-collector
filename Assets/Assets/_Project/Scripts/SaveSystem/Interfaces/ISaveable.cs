namespace DarkSoulCollector.SaveSystem
{
    /// <summary>
    /// Contract for objects that can save/load their state.
    /// </summary>
    public interface ISaveable
    {
        object SaveState();
        void LoadState(object state);
    }
}
