using UnityEngine;

public class LevelOver : MonoBehaviour
{
     
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("LevelOver");
        }
    }
}
