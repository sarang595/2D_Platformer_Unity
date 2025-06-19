using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int NextScene = CurrentSceneIndex + 1;
        bool Levelup = other.gameObject.CompareTag("Player") && NextScene < SceneManager.sceneCountInBuildSettings;
        if (Levelup)
        {
            SceneManager.LoadScene(NextScene);
        }
        else
        {
            Debug.Log("All Levels Completed");
        }
    }
}
