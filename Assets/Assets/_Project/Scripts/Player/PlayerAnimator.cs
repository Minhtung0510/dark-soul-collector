using UnityEngine;

namespace DarkSoulCollector.Player
{
    /// <summary>
    /// Wrapper for 3D Animator. Controls animation parameters for
    /// movement blend tree, attacks, dash, death.
    /// Animator Controller should have: Speed (float), IsGrounded (bool),
    /// Attack (trigger), HeavyAttack (trigger), ComboIndex (int),
    /// Dash (trigger), Death (trigger), IsAlive (bool).
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        // ═══════════════════════════════════════════
        //  ANIMATOR PARAMETER HASHES (cached for performance)
        // ═══════════════════════════════════════════
        private static readonly int HashSpeed = Animator.StringToHash("Speed");
        private static readonly int HashIsGrounded = Animator.StringToHash("IsGrounded");
        private static readonly int HashAttack = Animator.StringToHash("Attack");
        private static readonly int HashHeavyAttack = Animator.StringToHash("HeavyAttack");
        private static readonly int HashComboIndex = Animator.StringToHash("ComboIndex");
        private static readonly int HashDash = Animator.StringToHash("Dash");
        private static readonly int HashDeath = Animator.StringToHash("Death");
        private static readonly int HashIsAlive = Animator.StringToHash("IsAlive");

        // ═══════════════════════════════════════════
        //  PRIVATE FIELDS
        // ═══════════════════════════════════════════
        private Animator _animator;

        // ═══════════════════════════════════════════
        //  UNITY LIFECYCLE
        // ═══════════════════════════════════════════

        private void Awake()
        {
            // TODO: _animator = GetComponent<Animator>()
        }

        // ═══════════════════════════════════════════
        //  PUBLIC METHODS (called by PlayerController)
        // ═══════════════════════════════════════════

        public void SetSpeed(float speed)
        {
            // TODO: _animator.SetFloat(HashSpeed, speed)
        }

        public void SetGrounded(bool isGrounded)
        {
            // TODO: _animator.SetBool(HashIsGrounded, isGrounded)
        }

        public void SetAttack(int comboIndex)
        {
            // TODO: _animator.SetInteger(HashComboIndex, comboIndex)
            // TODO: _animator.SetTrigger(HashAttack)
        }

        public void SetHeavyAttack()
        {
            // TODO: _animator.SetTrigger(HashHeavyAttack)
        }

        public void SetDash()
        {
            // TODO: _animator.SetTrigger(HashDash)
        }

        public void SetDeath()
        {
            // TODO: _animator.SetBool(HashIsAlive, false)
            // TODO: _animator.SetTrigger(HashDeath)
        }
    }
}
