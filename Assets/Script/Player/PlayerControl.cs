using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    public Animator animator;
    private float horizontal;
    [SerializeField] float speed;
    private bool isJump;
    private float vertical;
    private bool crouch;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        crouch = Input.GetKey(KeyCode.LeftControl);
    }
    public void PlayerMovementAnim() => animator.SetFloat("Speed", Mathf.Abs(horizontal));
    public void PlayerMovement()
    {
       Vector3 position = transform.position;
       position.x = position.x+horizontal * speed*Time.deltaTime;
       transform.position =position;
       PlayerMovementAnim();
       Playerflip();
    }
    public void Playerflip()
    {
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    public void PlayerJump()
    {
        isJump = vertical > 0;
        animator.SetBool("Jump",isJump);
     
    }
    public void PlayerCrouch()
    {
        animator.SetBool("Crouch", crouch);
       
    }
   
    
}
