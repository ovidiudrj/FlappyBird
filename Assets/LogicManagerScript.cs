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

    [ContextMenu("Increase Score")]

    private void Start()
    {
        mainMenu.onClick.AddListener(switchMainMenu);
    }

    public void switchMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void addScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }

    [ContextMenu("Decrease Score")]
    public void descreaseScore()
    {
        playerScore--;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
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

        highScoreText.text = "Best: " + highScore;
        gameOverScreen.SetActive(true);
        Debug.Log("Game over");
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
