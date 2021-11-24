using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text bestScoreTxt = null;
    public void Start()
    {
        bestScoreTxt.text = PlayerPrefs.GetInt("BEST", 0).ToString();
        Application.targetFrameRate = 60;
        Load();
    }
    public void Load()
    {
        if (PlayerPrefs.GetInt("BEST", 0) < GameOver.highscore)
        {
            PlayerPrefs.SetInt("BEST", GameOver.highscore);
            bestScoreTxt.text = GameOver.highscore.ToString();
        }
    }
}
