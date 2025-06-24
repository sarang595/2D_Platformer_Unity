using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    
    public SoundType[] SoundTypes;
    public AudioSource BgMusic;
    public AudioSource EfxMusic;
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
    }
    private void Start()
    {
        PlayBGMusic(SoundManager.MusicType.BackgroundMusic);
    }
    public  void PlayBGMusic (MusicType type)
    {
        AudioClip clip = getSoundClip(type);
        if (clip != null)
        {
            BgMusic.clip = clip;
            BgMusic.Play();
        }
    }
    public void Play (MusicType type)
    {
        AudioClip clip = getSoundClip(type);
        if (clip != null)
        {
            EfxMusic.PlayOneShot(clip);
        }
    }
    private AudioClip getSoundClip(MusicType type)
    {
        SoundType item = Array.Find(SoundTypes, item => item.music == type);
        if (item != null)
        return item.clip;
        return null;

       
    }
    public enum MusicType { BackgroundMusic,ButtonClick, PlayerMove,PlayerDeath, EnemyDeath}
    [Serializable]
    public class SoundType
    {
        public MusicType music;
        public AudioClip clip;
    }
        

}
