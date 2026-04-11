using UnityEngine;

namespace DarkSoulCollector.Player
{
    /// <summary>
    /// Main player orchestrator. Connects Input → Movement, Combat, Stats, Animator.
    /// This is the "brain" that reads input and delegates to each subsystem.
    /// </summary>
    [RequireComponent(typeof(PlayerInputHandler))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerCombat))]
    [RequireComponent(typeof(PlayerStats))]
    [RequireComponent(typeof(PlayerAnimator))]
    public class PlayerController : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  COMPONENT REFERENCES
        // ═══════════════════════════════════════════
        private PlayerInputHandler _input;
        private PlayerMovement _movement;
        private PlayerCombat _combat;
        private PlayerStats _stats;
        private PlayerAnimator _animator;

        // ═══════════════════════════════════════════
        //  STATE
        // ═══════════════════════════════════════════
        public bool IsAlive { get; private set; } = true;
        public bool CanAct => IsAlive && !_movement.IsDashing && !_combat.IsAttacking;

        // ═══════════════════════════════════════════
        //  UNITY LIFECYCLE
        // ═══════════════════════════════════════════

        private void Awake()
        {
            // TODO: GetComponent all references
        }

        private void Update()
        {
            // TODO: If !IsAlive → return

            // TODO: HandleMovement()
            // TODO: HandleCombat()
            // TODO: HandleInteraction()
            // TODO: HandleSkills()
            // TODO: UpdateAnimator()
        }

        // ═══════════════════════════════════════════
        //  PRIVATE METHODS
        // ═══════════════════════════════════════════

        private void HandleMovement()
        {
            // TODO: Read _input.MovementInput → _movement.Move()
            // TODO: If _input.DashPressed → _movement.Dash()
        }

        private void HandleCombat()
        {
            // TODO: If _input.AttackPressed → _combat.LightAttack()
            // TODO: If _input.HeavyAttackPressed → _combat.HeavyAttack()
        }

        private void HandleInteraction()
        {
            // TODO: If _input.InteractPressed → Physics.SphereCast for IInteractable
        }

        private void HandleSkills()
        {
            // TODO: If _input.Skill1Pressed → _combat.UseSkill(0)
            // TODO: Repeat for Skill2-4
        }

        private void UpdateAnimator()
        {
            // TODO: _animator.SetSpeed(_movement.CurrentSpeed)
            // TODO: _animator.SetGrounded(_movement.IsGrounded)
        }

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS
        // ═══════════════════════════════════════════

        public void OnDeath()
        {
            // TODO: IsAlive = false
            // TODO: _animator.SetDeath()
            // TODO: Disable input, trigger Game Over UI
        }
    }
}
