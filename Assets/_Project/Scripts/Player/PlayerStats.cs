using UnityEngine;

namespace IdleSoulSurvivor.Player
{
    /// <summary>
    /// Player stats: ATK, DEF, HP, AGI, SPD, LUCK.
    /// DPS = ATK × SPD × (1 + crit).
    /// AGI → auto-dodge chance (max 40%).
    /// LUCK → crit chance + rare drop rate.
    /// Stats are modified by: gear, research, buffs.
    /// </summary>
    public class PlayerStats : MonoBehaviour
    {
    }
}
