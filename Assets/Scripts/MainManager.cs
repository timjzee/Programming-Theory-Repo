using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public bool gameOver;
    [SerializeField] GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over!");
        gameOverScreen.SetActive(true);
        if (GameManager.Instance.currentScore > GameManager.Instance.bestScore)
        {
            GameManager.Instance.bestScore = GameManager.Instance.currentScore;
            GameManager.Instance.bestPlayer = GameManager.Instance.currentPlayer;
            GameManager.Instance.SaveScore();
        }
    }
}
