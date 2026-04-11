using UnityEngine;
using DarkSoulCollector.Core;

namespace DarkSoulCollector.VFX
{
    /// <summary>
    /// Manages VFX spawning with object pooling.
    /// Slash, explosion, heal, hit effects — all in 3D world space.
    /// Singleton — accessible from anywhere via VFXManager.Instance.
    /// </summary>
    public class VFXManager : Singleton<VFXManager>
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [Header("VFX Prefabs")]
        [SerializeField] private GameObject slashVFX;
        [SerializeField] private GameObject hitVFX;
        [SerializeField] private GameObject explosionVFX;
        [SerializeField] private GameObject healVFX;
        [SerializeField] private GameObject damagePopupPrefab;

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS
        // ═══════════════════════════════════════════

        public void SpawnVFX(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            // TODO: Instantiate or get from ObjectPool
            // TODO: Set position and rotation
        }

        public void SpawnHitEffect(Vector3 position)
        {
            // TODO: SpawnVFX(hitVFX, position, Quaternion.identity)
        }

        public void SpawnSlashEffect(Vector3 position, Quaternion rotation)
        {
            // TODO: SpawnVFX(slashVFX, position, rotation)
        }

        public void SpawnExplosion(Vector3 position)
        {
            // TODO: SpawnVFX(explosionVFX, position, Quaternion.identity)
        }

        public void SpawnDamagePopup(float damage, Vector3 position, bool isCritical = false)
        {
            // TODO: Instantiate damagePopupPrefab
            // TODO: GetComponent<DamagePopup>().Setup(damage, position, isCritical)
        }
    }
}
