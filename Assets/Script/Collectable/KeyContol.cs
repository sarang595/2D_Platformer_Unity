using UnityEngine;

public class KeyContol : MonoBehaviour
{
    public PlayerControl PlayerControl;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool PlayerHitKey = collision.gameObject.CompareTag("Player");
        if (PlayerHitKey)
        {
            PlayerControl.PickupKey();
            Destroy(gameObject);
        }
    }
}
