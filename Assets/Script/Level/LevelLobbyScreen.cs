using UnityEngine;
using UnityEngine.UI;

public class LevelLobbyScreen : MonoBehaviour
{
    [SerializeField] private GameObject levelLobbyObject;
    private void Start()
    {
        closelevellobby();
    }
    public void displaylevellobby()
    {
        
      levelLobbyObject.SetActive(true);
    }
    
    public void closelevellobby()
    {
        levelLobbyObject.SetActive(false);
    }
    

}
