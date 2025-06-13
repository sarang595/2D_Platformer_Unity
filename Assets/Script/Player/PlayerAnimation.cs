using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public PlayerControl PlayerControl;
    public PlayerInput PlayerInput;
    public PlayerMovement PlayerMovement;
    private bool isJump;
    public void PlayerMovementAnim() => animator.SetFloat("Speed", Mathf.Abs(PlayerInput.Horizontal()));
    public void PlayerJumpAnim()
    {
        isJump = PlayerInput.Vertical() > 0;
        animator.SetBool("Jump", isJump);
    }
    public void PlayerCrouch()
    {
        animator.SetBool("Crouch", PlayerInput.Crouch());
    }
}
