using UnityEngine;

namespace DarkSoulCollector.Data
{
    /// <summary>
    /// ScriptableObject: ability configuration (cooldown, damage, cost, VFX).
    /// </summary>
    [CreateAssetMenu(fileName = "NewAbility", menuName = "DarkSoulCollector/Data/Ability")]
    public class AbilityData : ScriptableObject
    {
        public string abilityName;
        public string description;
        public float cooldown;
        public float damage;
        public float staminaCost;
        public Sprite icon;
        // TODO: ability type enum, VFX prefab, SFX clip
    }
}
