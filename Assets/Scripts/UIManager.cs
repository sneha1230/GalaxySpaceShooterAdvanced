using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] livesImages;
    public Image displayLivesImage;
    public int score;
    public Text scoreText;
    public GameObject gameOverScreen;
    public void UpdateLives(int currentLives)
    {
        displayLivesImage.sprite = livesImages[currentLives];
    }
    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score :" + score;
    }
    public void ShowGameOverScreen()
    {
        // To show game over screen
        gameOverScreen.SetActive(true);
    }
    public void HideGameOverScreen()
    {
        //to hide game over screen
        gameOverScreen.SetActive(false);
    }
}
