using UnityEngine;

namespace IdleSoulSurvivor.Idle
{
    /// <summary>
    /// Calculates offline rewards when player returns.
    /// Formula: Souls = Σ(minion.base × levelMult × shrineMult × researchMult) × hours × 0.3
    /// Diminishing: 1-4h=100%, 5-6h=70%, 7-8h=50%. Cap by Warehouse level.
    /// Watch ad = ×2.
    /// </summary>
    public class OfflineManager : MonoBehaviour
    {
    }
}
