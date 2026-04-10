using UnityEngine;

namespace DarkSoulCollector.Data
{
    /// <summary>
    /// ScriptableObject: soul data (name, ability granted, moral value).
    /// </summary>
    [CreateAssetMenu(fileName = "NewSoul", menuName = "DarkSoulCollector/Data/Soul")]
    public class SoulData : ScriptableObject
    {
        public string soulName;
        public string description;
        public Sprite icon;
        public int moralValue;
        // TODO: abilityData reference, visual effect prefab
    }
}
