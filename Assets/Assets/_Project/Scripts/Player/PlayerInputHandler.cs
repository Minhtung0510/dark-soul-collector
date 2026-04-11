using UnityEngine;

namespace DarkSoulCollector.Player
{
    /// <summary>
    /// Handles all player input. Reads WASD, Mouse, Attack, Dash, Interact.
    /// Other scripts read from this — single source of truth for input.
    /// </summary>
    public class PlayerInputHandler : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  PUBLIC PROPERTIES (read by other scripts)
        // ═══════════════════════════════════════════
        public Vector3 MovementInput { get; private set; }
        public Vector2 MouseDelta { get; private set; }
        public bool AttackPressed { get; private set; }
        public bool HeavyAttackPressed { get; private set; }
        public bool DashPressed { get; private set; }
        public bool InteractPressed { get; private set; }
        public bool LockOnPressed { get; private set; }
        public bool PausePressed { get; private set; }

        // Skill slots (1-4)
        public bool Skill1Pressed { get; private set; }
        public bool Skill2Pressed { get; private set; }
        public bool Skill3Pressed { get; private set; }
        public bool Skill4Pressed { get; private set; }

        // ═══════════════════════════════════════════
        //  UNITY LIFECYCLE
        // ═══════════════════════════════════════════

        private void Update()
        {
            // TODO: Read WASD → MovementInput (Vector3, xz plane)
            // TODO: Read Mouse X/Y delta → MouseDelta
            // TODO: Read Left Click → AttackPressed (GetButtonDown)
            // TODO: Read Right Click → HeavyAttackPressed
            // TODO: Read Space → DashPressed (GetButtonDown)
            // TODO: Read E → InteractPressed (GetButtonDown)
            // TODO: Read Q → LockOnPressed (GetButtonDown)
            // TODO: Read Escape → PausePressed (GetButtonDown)
            // TODO: Read 1,2,3,4 → Skill slots (GetButtonDown)
        }

        private void LateUpdate()
        {
            // TODO: Reset one-frame inputs (AttackPressed, DashPressed, etc.)
            // Tip: GetButtonDown only fires one frame, but if you cache it
            //       you may need to reset manually here
        }
    }
}
