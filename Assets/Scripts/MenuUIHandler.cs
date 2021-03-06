using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
        PlayerManager.Instance.LoadHighScore();
        bestScoreText.text = "HighScore : " + PlayerManager.Instance.highScorePlayerName + " (" + PlayerManager.Instance.highScore + ")";
    }

    public void StartNew()
    {
        PlayerManager.Instance.playerName = playerNameText.text.ToString();

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

    public void ResetHighscore()
    {
        PlayerManager.Instance.highScorePlayerName = null;
        PlayerManager.Instance.highScore = 0;
        PlayerManager.Instance.SaveHighScore();
    }
}
