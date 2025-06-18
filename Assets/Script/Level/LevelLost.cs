using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLost : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
           SceneManager.LoadScene(CurrentSceneIndex);
        }
    }
}
