using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerControl PlayerControl;
    [SerializeField] private PlayerInput PlayerInput;
    [SerializeField] private PlayerMovement PlayerMovement;
    private bool isJump;
    public void PlayerMovementAnim() => animator.SetFloat("Speed", Mathf.Abs(PlayerInput.Horizontal()));
    public void PlayerCrouch() => animator.SetBool("Crouch", PlayerInput.Crouch());
    public void PlayerJumpAnim()
    {
        isJump = PlayerInput.Vertical() > 0;
        animator.SetBool("Jump", isJump);
    }   
}
