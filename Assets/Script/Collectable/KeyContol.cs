using UnityEngine;

public class KeyContol : MonoBehaviour
{
    public PlayerControl PlayerControl;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerControl.PickupKey();
            Destroy(gameObject);
        }
    }
}
