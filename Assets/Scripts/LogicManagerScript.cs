using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using NUnit.Framework;
using UnityEditor;
using Unity.VisualScripting;
public class LogicManagerScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    [SerializeField] private GameObject blackScreen;
    public bool isPaused = false;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Button mainMenu;


    private void Start()
    {
        mainMenu.onClick.AddListener(switchMainMenu);
    }

    public void switchMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("MusicOn", 1);
    }

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScore = playerScore;
        }
        Time.timeScale = 0;
        highScoreText.text = "BEST: " + highScore;
        gameOverScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void resumeGame()
    {
        isPaused = false;
        blackScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void pauseGame()
    {
        isPaused = true;
        blackScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            resumeGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
    }
}
