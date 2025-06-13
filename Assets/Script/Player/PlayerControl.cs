using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private PlayerAnimation PlayerAnimation;
    [SerializeField] private PlayerInput PlayerInput;
    [SerializeField] private PlayerMovement PlayerMovement;
   void Update()
    {
        PlayerInput.Readinput();
        
        PlayerAnimation.PlayerJumpAnim();
        PlayerAnimation.PlayerCrouch();
    }
    void FixedUpdate()
    {
        PlayerMovement.CheckGrounded();
        PlayerMovement.PlayerMove();
        PlayerMovement.PlayerJump();
    }

}