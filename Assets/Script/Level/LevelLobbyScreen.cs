using UnityEngine;
using UnityEngine.UI;

public class LevelLobbyScreen : MonoBehaviour
{
    [SerializeField] private GameObject levelLobbyObject;
    private void Start()
    {
        levelLobbyObject.SetActive(false);
    }
    public void displaylevellobby()
    {
        SoundManager.Instance.Play(SoundManager.MusicType.ButtonClick);
        Debug.Log("GG");
        levelLobbyObject.SetActive(true);
      
    }
    
    public void closelevellobby()
    {
        SoundManager.Instance.Play(SoundManager.MusicType.ButtonClick);
        levelLobbyObject.SetActive(false);
    }
    

}
