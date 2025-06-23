using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string LevelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        levelstatus ls = LevelManager.Instance.getlevelstatus(LevelName);
        switch (ls)
        {
            case levelstatus.locked:
                Debug.Log("locked");
                break;
            case levelstatus.unlocked:
                SceneManager.LoadScene(LevelName);
                break;
            case levelstatus.completed:
                SceneManager.LoadScene(LevelName);
                break;
        }
    }
}
