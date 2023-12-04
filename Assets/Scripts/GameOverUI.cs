using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text scoreTxt;

    void Start()
    {
        scoreTxt.text = GameController.score.ToString();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
