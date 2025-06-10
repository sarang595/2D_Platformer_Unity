using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
   public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }

}
