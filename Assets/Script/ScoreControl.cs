using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.SocialPlatforms.Impl;
public class ScoreControl : MonoBehaviour
{
    [SerializeField] private PlayerControl playerControl;
    public TextMeshProUGUI ScoreText;
   // public TextMeshProUGUI PlayerhealthText;
    private int Score;
   
   
    
    public void IncreaseScore(int IncrementValue)
    {
        Score += IncrementValue;
       
        RefreshUI();
    }
  
    public void ResetScore()
    {
        Score = 0;
        RefreshUI();
    }
   //public void UpdateHealth(int health)
   // {
   //     PlayerhealthText.text = "Health: " + health;
   // }

    public void RefreshUI()
    {
        
        
        ScoreText.text = "Score: " + Score;
        //UpdateHealth(playerControl.PlayerHealth());
           
       
    }
}
