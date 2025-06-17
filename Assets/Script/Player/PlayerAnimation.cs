using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerControl PlayerControl;
    [SerializeField] private PlayerInput PlayerInput;
    [SerializeField] private PlayerMovement PlayerMovement;
    private bool isJump;
    public void PlayerMovementAnim() => animator.SetFloat("Speed", Mathf.Abs(PlayerInput.Horizontal()));
    public void PlayerCrouch()
    {
        bool Playergrounded = PlayerMovement.IsGrounded();
        if (Playergrounded)
        {
            animator.SetBool("Crouch", PlayerInput.Crouch());
        }
    }
    public void PlayerJumpAnim()
    {
       

        bool isInAir = !PlayerMovement.IsGrounded();
        float verticalVelocity = PlayerMovement.GetVerticalVelocity();

        animator.SetBool("Jump", isInAir);
        animator.SetBool("JumpUp", isInAir && verticalVelocity > 0.1f);
        animator.SetBool("JumpDown", isInAir && verticalVelocity < -0.1f);
    }   
}
