using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.SocialPlatforms.Impl;
public class ScoreControl : MonoBehaviour
{

    public TextMeshProUGUI ScoreText;
    private int Score;
   
    void Start()
    {
        RefreshUI();
    }
    
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
   

    private void RefreshUI()
    {
        if (ScoreText != null)
        {
            ScoreText.text = "Score: " + Score;
        }
        else
        {
            Debug.LogWarning("Score text is not assigned!");
        }
    }
}
