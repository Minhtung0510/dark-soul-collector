using UnityEngine;

namespace DarkSoulCollector.VFX
{
    /// <summary>
    /// Auto-destroys (or returns to pool) a GameObject after set time.
    /// Attach to any VFX prefab (particles, flashes, etc.)
    /// </summary>
    public class DestroyAfterTime : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [SerializeField] private float lifetime = 2f;
        [SerializeField] private bool usePool = false;

        // ═══════════════════════════════════════════
        //  UNITY LIFECYCLE
        // ═══════════════════════════════════════════

        private void Start()
        {
            // TODO: If usePool → return to ObjectPool after lifetime
            // TODO: Else → Destroy(gameObject, lifetime)
        }
    }
}
