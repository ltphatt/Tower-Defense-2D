using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool isPauseGame = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameplay;
    void Update()
    {
        // Khi người chơi ấn nút ESC ở bàn phím
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        isPauseGame = false;
        pauseMenu.SetActive(false);
        gameplay.SetActive(true);
        Time.timeScale = 1f;    // Khôi phục time trong game
    }

    public void Pause()
    {
        isPauseGame = true;
        pauseMenu.SetActive(true);
        gameplay.SetActive(false);
        Time.timeScale = 0f; // Dừng time trong game
    }

    public void TogglePauseButton()
    {
        if (isPauseGame == false)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene("Level selection");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
