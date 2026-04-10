namespace DarkSoulCollector.NPC
{
    /// <summary>
    /// Contract for objects the player can interact with (E key).
    /// </summary>
    public interface IInteractable
    {
        void Interact();
        string GetInteractPrompt();
    }
}
