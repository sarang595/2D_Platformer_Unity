using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public PlayerControl PlayerControl;
    public PlayerAnimation PlayerAnimation;
    public PlayerInput PlayerInput;
    [SerializeField] public float speed; // Movement Speed
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
        Vector3 position = transform.position;
        if (!PlayerInput.Crouch())
        {
            position.x = position.x + PlayerInput.Horizontal() * speed * Time.deltaTime;
            transform.position = position;
            PlayerAnimation.PlayerMovementAnim();
        }
       Playerflip();
    }
    public void Playerflip()
    {
        Vector3 scale = transform.localScale;
        if (PlayerInput.Horizontal() < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (PlayerInput.Horizontal() > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    public void PlayerJump()
    {
        // Apply force only once when space is first pressed AND jumps are available jump wont work in crouch
        if (PlayerInput.Vertical() > 0 && !hasJumped && jumpCount < maxJumps && !PlayerInput.Crouch())
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
        if (PlayerInput.Vertical() <= 0)
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
