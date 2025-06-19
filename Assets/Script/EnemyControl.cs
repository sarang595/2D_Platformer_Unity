using System.Collections;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Animator EnemyAnimation;
    [SerializeField] private PlayerAnimation PlayerAnimation;
    [SerializeField] private PlayerControl playerControl;
    Vector3 PosA;
    Vector3 PosB;
    Vector3 TargetPos;
    [SerializeField] float Distance = 5f;
    [SerializeField] float PatrollSpeed = 5f;
    private bool facingRight = true;
    private bool CanPatrol = true;
    private float originalScaleX; // Store the original scale

    private bool IsPlayer(GameObject obj) => obj.CompareTag("Player");

    public void Start()
    {
      

        EnemyPos();
    }

    public void Update()
    {
        CheckEnemyAnim();
        CheckPatroll();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsPlayer(collision.gameObject))
        {
            CanPatrol = false;
            EnemyAnimation.SetBool("IsPlayerHit", true);
            StartCoroutine(DelayPlayerDeath());
        }
    }

    private IEnumerator DelayPlayerDeath()
    {
        yield return new WaitForSeconds(0.5f);
        playerControl.Die();
        PlayerAnimation.PlayerDieAnim();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (IsPlayer(collision.gameObject))
        {
            EnemyAnimation.SetBool("IsPlayerHit", false);
            if (playerControl.isAlive)
            {
                CanPatrol = true;
            }
        }
    }

    public void CheckEnemyAnim()
    {
        if (!playerControl.isAlive)
        {
            EnemyAnimation.SetBool("IsPlayerHit", false);
            CanPatrol = false;
        }
    }

    public void EnemyPos()
    {
        // Store the original scale at start (handles negative values in inspector)
        originalScaleX = Mathf.Abs(transform.localScale.x);

        // Determine initial facing direction based on inspector scale
        facingRight = transform.localScale.x > 0;
        PosA = transform.position;
        // Move based on the sign of the X scale
        if (transform.localScale.x > 0)
        {
            // Positive scale - move right
            PosB = PosA + Vector3.right * Distance;
        }
        else
        {
            // Negative scale - move left
            PosB = PosA + Vector3.left * Distance;
        }
        TargetPos = PosB;
    }

    public void CheckPatroll()
    {
        if (CanPatrol)
        {
            EnemyPatroll();
        }
    }

    public void EnemyPatroll()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPos, PatrollSpeed * Time.deltaTime);
        if (transform.position == TargetPos)
        {
            if (TargetPos == PosA)
            {
                TargetPos = PosB;
                EnemyFlip(); // Always flip when changing direction
            }
            else if (TargetPos == PosB)
            {
                TargetPos = PosA;
                EnemyFlip(); // Always flip when changing direction
            }
        }
    }

    void EnemyFlip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        // Use the original scale magnitude but flip the direction
        if (facingRight)
        {
            scale.x = originalScaleX;
        }
        else
        {
            scale.x = -originalScaleX;
        }
        transform.localScale = scale;
    }
}