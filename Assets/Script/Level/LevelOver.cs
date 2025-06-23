using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOver : MonoBehaviour
{
    public LevelChangeScreen levelchangescreen;
    int NextScene;
    void LoadNextLevel()
    {
       
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int NextScene = CurrentSceneIndex + 1;

        string fullPath = SceneUtility.GetScenePathByBuildIndex(NextScene);
        string nextSceneName = System.IO.Path.GetFileNameWithoutExtension(fullPath);

        Debug.Log("Next Scene Name: " + nextSceneName);

        LevelManager.Instance.setlevelstatus(nextSceneName, levelstatus.unlocked);
        SceneManager.LoadScene(NextScene);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
       
        bool Levelup = other.gameObject.CompareTag("Player") && NextScene < SceneManager.sceneCountInBuildSettings;
        if (Levelup)
        {
            levelchangescreen.displayloading();
            Invoke(nameof(LoadNextLevel), 0.5f);
        }
        else
        {
            Debug.Log("All Levels Completed");
        }
    }
}