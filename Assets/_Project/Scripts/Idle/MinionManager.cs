using UnityEngine;

namespace IdleSoulSurvivor.Idle
{
    /// <summary>
    /// Manages Soul Minions that auto-farm offline.
    /// Tiers: T1 Ghost(10/h), T2 Wraith(35/h), T3 Phantom(100/h), T4 Revenant(350/h).
    /// 5 levels per minion (+50%/level).
    /// Merge: 3× same tier Lv.5 → 1× next tier Lv.1.
    /// 5 slots (2 free, 3 unlock with gems).
    /// </summary>
    public class MinionManager : MonoBehaviour
    {
    }
}
