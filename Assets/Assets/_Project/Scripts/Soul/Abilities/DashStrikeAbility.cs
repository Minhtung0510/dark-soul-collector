using UnityEngine;

namespace DarkSoulCollector.Soul
{
    /// <summary>
    /// Dash Strike: dash forward in 3D space, dealing damage to all enemies in path.
    /// Uses Physics.SphereCast or OverlapCapsule along dash path.
    /// </summary>
    public class DashStrikeAbility : AbilityBase
    {
        // ═══════════════════════════════════════════
        //  SERIALIZED FIELDS
        // ═══════════════════════════════════════════
        [Header("Dash Strike")]
        [SerializeField] private float dashDistance = 8f;
        [SerializeField] private float dashSpeed = 25f;
        [SerializeField] private float damage = 20f;
        [SerializeField] private float hitRadius = 1.5f;
        [SerializeField] private LayerMask enemyLayer;

        // ═══════════════════════════════════════════
        //  IMPLEMENTATION
        // ═══════════════════════════════════════════

        public override void Activate()
        {
            // TODO: if (!TryActivate()) return
            // TODO: Start dash coroutine (move player forward dashDistance)
            // TODO: OverlapSphere along path → damage all enemies hit
            // TODO: SpawnVFX trail along dash path
        }
    }
}
