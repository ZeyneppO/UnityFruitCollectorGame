using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ScoreText;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public int maxHearts;
    public int currentLives = 3;
    public Text replayText;
    public Text gameOverText;

    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxHearts;
        UpdateHearts();
       
        ScoreText.text = "Score: ";
       
        replayText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void UpdateHearts()
    {
        //Debug.Log("Current Lives: " + currentLives);
        
        for (int i = 0; i < maxHearts; i++)
        {
            if (i < currentLives)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }

        if (currentLives == 0)
        {
            GameOverSequence();
        }
    }
    public void UpdateScore(int playerScore)
    {
        ScoreText.text = "Score: " + playerScore.ToString();
    }

    public void GameOverSequence()
    {
        gameManager.GameOver();   
        replayText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);       
    }
  
}
