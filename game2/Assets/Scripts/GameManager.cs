using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    private int currentEnergy;
    [SerializeField] private int energyThreshold = 4;
    [SerializeField] private GameObject boss;
    private bool bossCalled = false;
    [SerializeField] private GameObject spawnEnemy;
    [SerializeField] private Image energyBar;
    [SerializeField] GameObject gameUi;
    [SerializeField] private CinemachineVirtualCamera cam;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameoverMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject winMenu;

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = 0;
        UpdateEnergyBar();
        boss.SetActive(false);
        MainMenu();
        audioManager.StopAudioGame();
        cam.m_Lens.OrthographicSize = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddEnergy()
    {
        if(bossCalled) return;
        currentEnergy += 1;
        UpdateEnergyBar();
        if(currentEnergy ==  energyThreshold)
        {
            CallBoss();
        }
    }
    private void CallBoss()
    {
        bossCalled = true;
        boss.SetActive(true);
        spawnEnemy.SetActive(false); 
        gameUi.SetActive(false);
        audioManager.PlayBossAudioSource();
        cam.m_Lens.OrthographicSize = 10f;
        
    }
    private void UpdateEnergyBar()
    {
        if(energyBar != null )
        {
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyThreshold);
            energyBar.fillAmount = fillAmount;
        }
    }
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameoverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void GameoverMenu()
    {
        gameoverMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        mainMenu.SetActive(false);
        gameoverMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameoverMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1f;
        audioManager.PlayDefaultAudioSoure();
    }
    public void Resume()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameoverMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void WinMenu()
    {
        winMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameoverMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ClickMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
