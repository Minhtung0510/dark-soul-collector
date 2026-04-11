using UnityEngine;

namespace DarkSoulCollector.Combat
{
    /// <summary>
    /// Visual feedback when entity takes damage.
    /// For 3D: uses Renderer.material color flash instead of SpriteRenderer.
    /// </summary>
    public class HitFlash : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [SerializeField] private Color flashColor = Color.red;
        [SerializeField] private float flashDuration = 0.1f;

        // ═══════════════════════════════════════════
        //  PRIVATE FIELDS
        // ═══════════════════════════════════════════
        private Renderer _renderer;
        private Color _originalColor;

        // ═══════════════════════════════════════════
        //  UNITY LIFECYCLE
        // ═══════════════════════════════════════════

        private void Awake()
        {
            // TODO: _renderer = GetComponentInChildren<Renderer>()
            // TODO: _originalColor = _renderer.material.color
        }

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS
        // ═══════════════════════════════════════════

        public void Flash()
        {
            // TODO: StartCoroutine(FlashRoutine())
        }

        private System.Collections.IEnumerator FlashRoutine()
        {
            // TODO: Set material color to flashColor
            // TODO: yield return new WaitForSeconds(flashDuration)
            // TODO: Reset to _originalColor
            yield break;
        }
    }
}
