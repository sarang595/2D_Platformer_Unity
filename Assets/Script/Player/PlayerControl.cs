using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    public Animator animator;
    private float speed;
    private bool isJump;
    private float jump;
    private bool crouch;
    void Start()
    {
        
    }

   
    void Update()
    {
        PlayerInput();
        PlayerMovement();
        PlayerJump();
        PlayerCrouch();
    }
    public void PlayerInput()
    {
        speed = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxisRaw("Vertical");
        crouch = Input.GetKey(KeyCode.LeftControl);
    }
    public void PlayerMovement()
    {
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Playerflip();
    }
    public void PlayerJump()
    {
        isJump = jump > 0;
        animator.SetBool("Jump",isJump);
    }
    public void PlayerCrouch()
    {
        animator.SetBool("Crouch", crouch);
    }
    public void Playerflip()
    {
        Vector3 scale = transform.localScale;
            if (speed < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if (speed > 0)
            {
                scale.x = Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
        }
    
}
