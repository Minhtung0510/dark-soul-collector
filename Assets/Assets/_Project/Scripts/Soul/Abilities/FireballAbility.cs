using UnityEngine;

namespace DarkSoulCollector.Soul
{
    /// <summary>
    /// Fireball: ranged AoE ability. Spawns 3D projectile that explodes on impact.
    /// </summary>
    public class FireballAbility : AbilityBase
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [Header("Fireball")]
        [SerializeField] private GameObject fireballPrefab;
        [SerializeField] private Transform castPoint;
        [SerializeField] private float fireballSpeed = 15f;
        [SerializeField] private float fireballDamage = 30f;
        [SerializeField] private float explosionRadius = 3f;

        // ═══════════════════════════════════════════
        //  IMPLEMENTATION
        // ═══════════════════════════════════════════

        public override void Activate()
        {
            // TODO: if (!TryActivate()) return
            // TODO: Instantiate fireballPrefab at castPoint
            // TODO: Set direction (player forward) and speed
            // TODO: SpawnVFX(castPoint.position)
        }
    }
}
