using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private PlayerAnimation PlayerAnimation;
    [SerializeField] private PlayerInput PlayerInput;
    [SerializeField] private PlayerMovement PlayerMovement;
    [SerializeField] private ScoreControl scoreControl;
    [SerializeField] private StickHit stickhit;
    int KeypickScore = 10;
    public bool isAlive = true;

   
    void Update()
    {
        PlayerInput.Readinput();
        PlayerAnimation.PlayerJumpAnim();
        PlayerAnimation.PlayerCrouch();
        PlayerAnimation.PlayerAttackAnim();
        stickhit.StickAttack();
       
    }
    void FixedUpdate()
    {
        PlayerMovement.CheckGrounded();
        PlayerMovement.PlayerMove();
        PlayerMovement.PlayerJump();
    }
    public void PickupKey() => scoreControl.IncreaseScore(KeypickScore);
    public void Die() => isAlive = false;
   
}