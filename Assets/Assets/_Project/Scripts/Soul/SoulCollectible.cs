using UnityEngine;

namespace DarkSoulCollector.Soul
{
    /// <summary>
    /// Pickup object in 3D world. Grants a soul when player enters trigger.
    /// Uses OnTriggerEnter (3D) instead of OnTriggerEnter2D.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class SoulCollectible : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [SerializeField] private int soulValue = 10;
        [SerializeField] private GameObject pickupVFX;
        [SerializeField] private AudioClip pickupSound;

        [Header("Bob Animation")]
        [SerializeField] private float bobSpeed = 2f;
        [SerializeField] private float bobHeight = 0.3f;

        // ═══════════════════════════════════════════
        //  PRIVATE FIELDS
        // ═══════════════════════════════════════════
        private Vector3 _startPosition;

        // ═══════════════════════════════════════════
        //  UNITY LIFECYCLE
        // ═══════════════════════════════════════════

        private void Start()
        {
            // TODO: _startPosition = transform.position
        }

        private void Update()
        {
            // TODO: Bob up and down (sin wave animation)
            // TODO: Rotate slowly for visual appeal
        }

        // ═══════════════════════════════════════════
        //  3D COLLISION
        // ═══════════════════════════════════════════

        private void OnTriggerEnter(Collider other)
        {
            // TODO: Check if other is Player (tag or layer)
            // TODO: other.GetComponent<SoulManager>()?.CollectSoul(soulValue)
            // TODO: Spawn pickupVFX, play pickupSound
            // TODO: Destroy(gameObject)
        }
    }
}
