using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGameOver == true)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void GameOver()
    {
        isGameOver = true;
    }

}
