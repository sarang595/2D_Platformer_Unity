using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    public Animator animator;
    private float horizontal;
    [SerializeField] float speed;
    [SerializeField] float JumpForce;
    [SerializeField] float secondJumpForce; // Different force for second jump
    private bool isJump;
    private float vertical;
    private bool crouch;
    private bool hasJumped = false; // Track if jump has been executed
    private bool isGrounded = false; // Track if player is on ground
    private int jumpCount = 0; // Track number of jumps performed
    private int maxJumps = 2; // Maximum jumps allowed (1 = single jump, 2 = double jump)

    [Header("Ground Detection")]
    [SerializeField] Transform groundCheck; // Empty GameObject positioned at player's feet
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayerMask; // Set this to your ground layer

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerInput();
        CheckGrounded(); // Check if player is grounded
        PlayerMovement();
        PlayerJump();
        PlayerJumpAnim();
        PlayerCrouch();
    }

    public void PlayerInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Jump");
        crouch = Input.GetKey(KeyCode.LeftControl);
    }

    public void PlayerMovementAnim() => animator.SetFloat("Speed", Mathf.Abs(horizontal));

    public void PlayerMovement()
    {
        Vector3 position = transform.position;
        if (!crouch)
        {
            position.x = position.x + horizontal * speed * Time.deltaTime;
            transform.position = position;
            PlayerMovementAnim();
            Playerflip();
        }
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

    public void PlayerJumpAnim()
    {
        isJump = vertical > 0;
        animator.SetBool("Jump", isJump);
    }

    public void PlayerJump()
    {
        // Apply force only once when space is first pressed AND jumps are available jump wont work in crouch
        if (vertical > 0 && !hasJumped && jumpCount < maxJumps && !crouch)
        {
            float currentJumpForce;
            if (jumpCount == 0)
            {
                currentJumpForce = JumpForce; // First jump uses normal jump force
            }
            else
            {
                currentJumpForce = secondJumpForce; // Second jump uses different force
            }

            rb.AddForce(new Vector2(0, currentJumpForce), ForceMode2D.Impulse);
            hasJumped = true;
            jumpCount++; // Increment jump counter
        }

        // Reset jump flag when space key is released
        if (vertical <= 0)
        {
            hasJumped = false;
        }
    }

    public void CheckGrounded()
    {
        // Check if there's ground within the specified radius
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayerMask);

        // Reset jump count when grounded
        if (isGrounded)
        {
            jumpCount = 0;
        }
    }

    public void PlayerCrouch()
    {
        animator.SetBool("Crouch", crouch);
    }
}