namespace DarkSoulCollector.Inventory
{
    /// <summary>
    /// Contract for items that can be picked up from the world.
    /// </summary>
    public interface ICollectible
    {
        void Collect();
    }
}
