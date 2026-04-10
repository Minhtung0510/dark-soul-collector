namespace DarkSoulCollector.Inventory
{
    /// <summary>
    /// Contract for items that can be used (potions, scrolls, etc).
    /// </summary>
    public interface IUseable
    {
        void Use();
    }
}
