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
        SoundManager.Instance.Play(SoundManager.MusicType.ButtonClick);
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    public void Lobby()
    {
        SoundManager.Instance.Play(SoundManager.MusicType.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
