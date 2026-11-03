using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button musicOnButton;
    [SerializeField] private Button musicOffButton;

    private void Start()
    {
        Time.timeScale = 1;
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
        musicOffButton.onClick.AddListener(PlayMusic);
        musicOnButton.onClick.AddListener(StopMusic);

        if (GameSettings.MusicOn)
        {
            musicOnButton.gameObject.SetActive(true);
        }
        else
        {
            musicOffButton.gameObject.SetActive(true);
        }
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void StopMusic()
    {
        GameSettings.MusicOn = false;
        musicOnButton.gameObject.SetActive(false);
        musicOffButton.gameObject.SetActive(true);
    }

    private void PlayMusic()
    {
        GameSettings.MusicOn = true;
        musicOnButton.gameObject.SetActive(true);
        musicOffButton.gameObject.SetActive(false);
    }
}
