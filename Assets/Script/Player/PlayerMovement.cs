using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private PlayerControl PlayerControl;
    [SerializeField] private PlayerAnimation PlayerAnimation;
    [SerializeField] private PlayerInput PlayerInput;
    [SerializeField] float speed; // Movement Speed
    [SerializeField] float JumpForce;
    [SerializeField] float secondJumpForce; // Different force for second jump
    private bool hasJumped = false; // Track if jump has been executed
    private bool isGrounded = false; // Track if player is on ground
    private int jumpCount = 0; // Track number of jumps performed
    private int maxJumps = 2; // Maximum jumps allowed (1 = single jump, 2 = double jump)

    [Header("Ground Detection")]
    [SerializeField] Transform groundCheck; // Empty GameObject positioned at player's feet
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayerMask; // Set this to your ground layer
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void PlayerMove()
    {
        bool IsCrouched = !PlayerInput.Crouch();
       if (IsCrouched)
        {
            rb.linearVelocity = new Vector2(PlayerInput.Horizontal() * speed, rb.linearVelocity.y);
            PlayerAnimation.PlayerMovementAnim();
        }
       PlayerFlip();
    }
    public void PlayerFlip()
    {
        bool MoveRight = (PlayerInput.Horizontal() < 0);
        bool MoveLeft = (PlayerInput.Horizontal() > 0);
        Vector3 scale = transform.localScale;
        if (MoveRight)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (MoveLeft)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    public void PlayerJump()
    {
        bool CanJump = PlayerInput.Vertical() > 0 && !hasJumped && jumpCount < maxJumps && !PlayerInput.Crouch();
        bool ResetJump = PlayerInput.Vertical() <= 0;
        // Apply force only once when space is first pressed AND jumps are available jump wont work in crouch
        if (CanJump)
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

            rb.AddForce(Vector2.up* currentJumpForce, ForceMode2D.Impulse);
            hasJumped = true;
            jumpCount++; // Increment jump counter
        }

        // Reset jump flag when space key is released
        if (ResetJump)
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

}
