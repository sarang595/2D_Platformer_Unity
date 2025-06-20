using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLost : MonoBehaviour
{
    [SerializeField] private PlayerControl PlayerControl;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerControl.TakeDamage(100);
            PlayerControl.Die();
          
        }
    }
    public void ReloadScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex);
    }
}
