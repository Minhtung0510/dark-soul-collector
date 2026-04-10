using UnityEngine;
using System.Collections.Generic;

namespace DarkSoulCollector.Data
{
    /// <summary>
    /// ScriptableObject: dialogue tree data for NPCs.
    /// </summary>
    [CreateAssetMenu(fileName = "NewDialogue", menuName = "DarkSoulCollector/Data/Dialogue")]
    public class DialogueDataSO : ScriptableObject
    {
        public string speakerName;
        // TODO: List<DialogueLine> lines, branching support
    }
}
