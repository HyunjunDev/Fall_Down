using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour
{
    private GameOver gameOver;
    public void LoadMain()
    {
        SceneManager.LoadScene(1);
    }
}
