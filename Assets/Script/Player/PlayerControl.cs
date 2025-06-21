using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private PlayerAnimation PlayerAnimation;
    [SerializeField] private PlayerInput PlayerInput;
    [SerializeField] private PlayerMovement PlayerMovement;
    [SerializeField] private ScoreControl scoreControl;
    [SerializeField] private StickHit stickhit;
    [SerializeField] private LevelLost levellost;
    [SerializeField] private GameOverDisplay gameoverdisplay;
    int KeypickScore = 10;
    public  int playerhealth = 100;
    public bool isAlive = true;

     void Start()
    {
        scoreControl.RefreshUI();
    }
    void Update()
    {
        PlayerInput.Readinput();
        PlayerAnimation.PlayerJumpAnim();
        PlayerAnimation.PlayerCrouch();
        PlayerAnimation.PlayerAttackAnim();
        stickhit.PlayerAttack();
       
    }
    void FixedUpdate()
    {
        PlayerMovement.CheckGrounded();
        PlayerMovement.PlayerMove();
        PlayerMovement.PlayerJump();
    }
    public void PickupKey() => scoreControl.IncreaseScore(KeypickScore);
    public int PlayerHealth()
    {

        return playerhealth;
    } 
    public void TakeDamage(int Damage)
    {
        if(!isAlive)
        {
            return;
        }
        playerhealth -= Damage;
       
        if (playerhealth <= 0)
        {
            playerhealth = 0;
            //scoreControl.RefreshUI();
            Die();
            return;
        }
        scoreControl.RefreshUI();
       
    }
    public void Die()
    {
               
            isAlive = false;
            PlayerAnimation.PlayerDieAnim();
            Invoke(nameof(callRestartScreen), 1.5f);
              
    }
    private void callRestartScreen()
    {
        gameoverdisplay.displayegameover();
       // levellost.ReloadScene();
    }
   
}