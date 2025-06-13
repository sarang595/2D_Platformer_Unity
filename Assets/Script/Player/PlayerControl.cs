using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    public PlayerAnimation PlayerAnimation;
    public PlayerInput PlayerInput;
    public PlayerMovement PlayerMovement;
   void Update()
    {
        PlayerInput.Readinput();
        PlayerMovement. CheckGrounded(); 
        PlayerMovement.PlayerMove();
        PlayerMovement.PlayerJump();
        PlayerAnimation.PlayerJumpAnim();
        PlayerAnimation.PlayerCrouch();
    }
  
}