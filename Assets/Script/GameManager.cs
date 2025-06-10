using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
  
    public Button Scene1;
    public Button Scene2;
    public Button Scene3;
    void Start()
    {
       
        AddListener();
    }



    private void AddListener()
    {
        Scene1.onClick.AddListener(LoadScene1);
        Scene2.onClick.AddListener(LoadScene2);
        Scene3.onClick.AddListener(LoadScene3);
    }
    private void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }
    private void LoadScene2()
    {
        SceneManager.LoadScene(2);
    }
    private void LoadScene3()
    {
        SceneManager.LoadScene(3);
    }
    
}
