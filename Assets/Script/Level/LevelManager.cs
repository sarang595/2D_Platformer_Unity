using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance {  get { return instance; } }
    public string Level1;
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings; i++)
        {
            string path = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(path);

            if (!PlayerPrefs.HasKey(sceneName))
            {
                if (sceneName == Level1)
                    setlevelstatus(sceneName, levelstatus.unlocked);
                else
                    setlevelstatus(sceneName, levelstatus.locked);
            }
        }
    }
    private void Start()
    {
        if(getlevelstatus(Level1) == levelstatus.locked)
        {
            setlevelstatus(Level1, levelstatus.unlocked);
        }
    }
    public levelstatus getlevelstatus(string level)
    {
        levelstatus ls= (levelstatus)PlayerPrefs.GetInt(level,0);
        return ls;
    }
    public void setlevelstatus(string level, levelstatus ls)
    {
        PlayerPrefs.SetInt(level, (int)ls);
    }
   
}
