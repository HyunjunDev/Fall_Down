using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject mainScreen;
    public Text secondSurvivvedUI;
    private GameManager gameManager;
    public static int highscore = 0;
    private int score = 0;
    bool gameOver;

    private void Start()
    {
        gameManager=FindObjectOfType<GameManager>();
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
    }
    public void ReStart()
    {
        if(gameOver)
        {
             SceneManager.LoadScene(1);
        }
    }
    private void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        mainScreen.SetActive(true);
        secondSurvivvedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        score = Mathf.RoundToInt(Time.timeSinceLevelLoad);
        if (score > highscore)
        {
            Debug.Log('1');
            highscore = score;
        }
        gameOver = true;
    }
}
