using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float gameSpeed = 5f;
    [SerializeField] private float speedIncrease = 0.15f;
    [SerializeField] private TextMeshProUGUI scoreText;
    private float score = 0;
    [SerializeField] private GameObject scoreTextObject;
    [SerializeField] private GameObject gameStart;
    [SerializeField] private GameObject gameover;
    private bool isGameover = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public float GetGameSpeed()
    {
        return gameSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        HandleStartGameInput();
        if (isGameover)
        {
            UpdateGameSpeed();
            UpdateScore();
        }
    }
    private void UpdateGameSpeed()
    {
        gameSpeed += Time.deltaTime * speedIncrease;
    }
    private void UpdateScore()
    {
        score += Time.deltaTime * 10;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }
    private void StartGame()
    {
        Time.timeScale = 0f;
        scoreTextObject.SetActive(false);
        gameStart.SetActive(true);
        gameover.SetActive(false);
    }
    private void HandleStartGameInput()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1f;
            scoreTextObject.SetActive(true);
            gameStart.SetActive(false);
        }
    }
    public void Gameover()
    {
        isGameover = true;
        gameover.SetActive(true);
        Time.timeScale = 0f;
        StartCoroutine(ReloadScene());
    }
    private IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
