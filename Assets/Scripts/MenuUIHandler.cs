using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI inputField;
    private void Start()
    {
        GameManager.Instance.LoadScore();
        highScoreText.text = "Best Score : " + GameManager.Instance.bestPlayer + " : " + GameManager.Instance.bestScore;
    }

    public void StartNew()
    {
        GameManager.Instance.currentPlayer = inputField.text;
        GameManager.Instance.currentScore = 0;
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

}
