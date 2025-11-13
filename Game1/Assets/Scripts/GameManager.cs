using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameoverUi;
    private bool isGameover = false;
    [SerializeField] private GameObject gamewinUI;
    private bool isGamewin = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        gameoverUi.SetActive(false);
        gamewinUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int points)
    {
        if(!isGameover && !isGamewin)
        {
            score += points;
            UpdateScore();
        }
    }
    private void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void Gameover()
    {
        isGameover = true;
        score = 0;
        Time.timeScale = 0;
        gameoverUi.SetActive(true);
    }
    public void GameWin()
    {
        isGamewin = true;
        Time.timeScale = 0;
        gamewinUI.SetActive(true);
    }
    public void Replay()
    {
        isGameover = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public bool IsGameover()
    {
        return isGameover;
    }
    public bool IsGameWin()
    {
        return isGamewin;
    }
    public void GotoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
