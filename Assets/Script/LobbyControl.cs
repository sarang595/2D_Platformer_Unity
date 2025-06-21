using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyControl : MonoBehaviour
{
    int NextScene;
    public void LoadNextLevel()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        NextScene = CurrentSceneIndex + 1;
        SceneManager.LoadScene(NextScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Lobby()
    {
        SceneManager.LoadScene(0);
    }
}
