using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private void Start()
    {
        LoadHighScore();
        UpdateHighScore();
    }

    private void Update()
    {
        UpdateCurrentScore();
    }

    void UpdateCurrentScore()
    {
        GameManager.gameManager.menuText[7].text = "Score: " + GameManager.gameManager.score.ToString();
        if (GameManager.gameManager.score > GameManager.gameManager.highScore)
        {
            GameManager.gameManager.highScore = GameManager.gameManager.score;
            PlayerPrefs.SetInt("highScore", GameManager.gameManager.highScore);
          
        }
    }

    void LoadHighScore()
    {
        GameManager.gameManager.highScore = PlayerPrefs.GetInt("highScore", 0); // Load high score from PlayerPrefs
    }

    void UpdateHighScore()
    {
        GameManager.gameManager.menuText[8].text = "High Score: " + GameManager.gameManager.highScore.ToString();
    }
}
