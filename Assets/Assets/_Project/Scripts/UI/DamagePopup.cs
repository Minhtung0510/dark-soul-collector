using UnityEngine;
using TMPro;

namespace DarkSoulCollector.UI
{
    /// <summary>
    /// Floating damage numbers in 3D world space.
    /// Uses TextMeshPro World Space. Floats up, fades out, auto-destroys.
    /// Billboard: always faces camera.
    /// </summary>
    public class DamagePopup : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [SerializeField] private TextMeshPro textMesh;
        [SerializeField] private float floatSpeed = 2f;
        [SerializeField] private float fadeSpeed = 1f;
        [SerializeField] private float lifetime = 1f;
        [SerializeField] private Color normalColor = Color.white;
        [SerializeField] private Color criticalColor = Color.red;

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS
        // ═══════════════════════════════════════════

        /// <summary>
        /// Initialize damage popup at world position.
        /// </summary>
        public void Setup(float damage, Vector3 position, bool isCritical = false)
        {
            // TODO: transform.position = position
            // TODO: textMesh.text = damage.ToString("F0")
            // TODO: textMesh.color = isCritical ? criticalColor : normalColor
            // TODO: Start float up + fade coroutine
            // TODO: Destroy(gameObject, lifetime)
        }

        private void Update()
        {
            // TODO: Float up (transform.position += Vector3.up * floatSpeed * Time.deltaTime)
            // TODO: Billboard → face camera (transform.LookAt(Camera.main))
            // TODO: Fade out alpha over time
        }
    }
}
