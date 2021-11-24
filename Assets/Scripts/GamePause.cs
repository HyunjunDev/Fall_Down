using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    public GameObject gamePauseScreen;
    bool pauseActive = false;
    public GameObject player;
    public GameOver gameOver;
    public void pauseBtn()
    {
        if (pauseActive)
        {
            Time.timeScale = 0;
            gamePauseScreen.SetActive(true);
            player.SetActive(false);
            pauseActive = false;
        }
        else
        {
            Time.timeScale = 1;
            gamePauseScreen.SetActive(false);
            player.SetActive(true);
            pauseActive = true;
        }
    }
    public void LoadStart()
    {
        Time.timeScale = 1;
        pauseActive = true;
        SceneManager.LoadScene(0);
    }
}
