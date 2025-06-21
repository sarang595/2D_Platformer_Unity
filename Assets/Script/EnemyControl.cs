using System.Collections;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public Animator EnemyAnimation;
    [SerializeField] private PlayerAnimation PlayerAnimation;
    [SerializeField] private PlayerControl playerControl;
    [SerializeField] private ScoreControl scoreControl;
    Vector3 PosA;
    Vector3 PosB;
    Vector3 TargetPos;
    [SerializeField] float Distance = 5f;
    [SerializeField] float PatrollSpeed = 5f;
    private bool facingRight = true;
    private bool CanPatrol = true;
    private float originalScaleX; // Store the original scale
    private float cooldownDamage = 0.5f;
    private float lastDamge = -Mathf.Infinity;
    bool isPlayerhitEnemy = false;
    public bool EnemyAlive = true;
    [SerializeField] private int EnemyPower = 5;

    private bool IsPlayer(GameObject obj) => obj.CompareTag("Player");

    public void Start()
    {
        EnemyPos();
    }

    public void Update()
    {
        PlayerAttacked();
        CheckEnemyAnim();
        CheckPatroll();
    }
   public void EnemyDieAnim()
    {
        EnemyAlive = false;
        if(!EnemyAlive)
        {
            EnemyAnimation.SetBool("isDeath", true);
            StartCoroutine(DestoryEnemy());
        }
    }
    private IEnumerator DestoryEnemy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsPlayer(collision.gameObject))
        {
            isPlayerhitEnemy = true;
           
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (IsPlayer(collision.gameObject))
        {
            isPlayerhitEnemy = true;
           
        }
    }
    void PlayerAttacked()
    {
        if (isPlayerhitEnemy)
        {
            DamagePlayer();
        }
    }
    private void DamagePlayer()
    {
        if (Time.time - lastDamge >= cooldownDamage)
        {
            CanPatrol = false;
            EnemyAnimation.SetBool("IsPlayerHit", true);
            playerControl.TakeDamage(EnemyPower);
            lastDamge = Time.time;
        }
          
    }

   

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (IsPlayer(collision.gameObject))
        {
            isPlayerhitEnemy = false;
            EnemyAnimation.SetBool("IsPlayerHit", false);
            if (playerControl.isAlive)
            {
                CanPatrol = true;
            }
        }
    }

    private void CheckEnemyAnim()
    {
        if (!playerControl.isAlive)
        {
            EnemyAnimation.SetBool("IsPlayerHit", false);
            CanPatrol = false;
        }
    }

    private void EnemyPos()
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

    private void CheckPatroll()
    {
        if (CanPatrol)
        {
            EnemyPatroll();
        }
    }

    private void EnemyPatroll()
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