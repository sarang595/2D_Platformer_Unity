using UnityEngine;
using System.Collections;

public class StickHit : MonoBehaviour
{
    public PlayerInput PlayerInput;
    public PlayerControl PlayerControl;
    private Collider2D stickCollider;
    private bool isAttacking = false;

    private void Awake()
    {
        stickCollider = GetComponent<Collider2D>();
        stickCollider.enabled = false;
    }

   
    public void StickAttack()
    {
        bool CanAttack = PlayerInput.Attack() && !PlayerInput.Crouch() && !isAttacking && PlayerControl.isAlive;

        if (CanAttack)
        {
           
            StartCoroutine(EnableHitboxAfterDelay(0.5f, 0.5f));
        }
    }
    private IEnumerator EnableHitboxAfterDelay(float delay, float duration)
    {
        isAttacking = true;

        yield return new WaitForSeconds(delay); // Wait 2 seconds

        stickCollider.enabled = true;
       

        yield return new WaitForSeconds(duration); // Active for 0.2 seconds

        stickCollider.enabled = false;
      

        isAttacking = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
           
            Destroy(other.gameObject);
        }
    }
}
