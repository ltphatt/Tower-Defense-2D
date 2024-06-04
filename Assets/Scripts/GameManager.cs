using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject gamePlayCanvas;
    [SerializeField] private GameObject gameVictoryCanvas;
    [SerializeField] private float sceneLoadDelay = 1f;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;

        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        Debug.Log("Reseting score...");
        scoreKeeper.ResetScore();

        Debug.Log("Loading game...");
        StartCoroutine(WaitAndLoad("Level 1", sceneLoadDelay));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);

        Time.timeScale = 1;
    }

    public void SelectLevel()
    {
        // TODO: Add select menu screen
        Debug.Log("Select Level ...");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void OpenSettingsMenu()
    {
        // TODO: Add settings menu
        Debug.Log("Opening Settings Menu...");
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        gamePlayCanvas.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Victory()
    {
        gameVictoryCanvas.SetActive(true);
        gamePlayCanvas.SetActive(false);
        Time.timeScale = 0f;
    }

    public void LoadNextLevel()
    {
        int currentScenceIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScenceIndex + 1);
    }
}
