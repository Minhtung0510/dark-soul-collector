using UnityEngine;

namespace DarkSoulCollector.Data
{
    /// <summary>
    /// ScriptableObject: item definition (name, description, type, stackable).
    /// </summary>
    [CreateAssetMenu(fileName = "NewItem", menuName = "DarkSoulCollector/Data/Item")]
    public class ItemData : ScriptableObject
    {
        public string itemName;
        public string description;
        public Sprite icon;
        public bool isStackable;
        public int maxStack = 99;
        // TODO: ItemType enum (Consumable, Equipment, Key, Material)
    }
}
