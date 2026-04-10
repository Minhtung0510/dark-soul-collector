using UnityEngine;

namespace DarkSoulCollector.Audio
{
    /// <summary>
    /// ScriptableObject-based sound registry. Maps sound names to AudioClips.
    /// </summary>
    [CreateAssetMenu(fileName = "SoundLibrary", menuName = "DarkSoulCollector/Audio/Sound Library")]
    public class SoundLibrary : ScriptableObject
    {
        // TODO: SoundEntry[] sounds, GetClip(string name)
    }
}
