using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [Header("UI References")]
    public GameObject pauseMenuPanel;

    [Header("Scene Names")]
    public string mainMenuSceneName = "MainMenu"; // Replace with your exact Main Menu scene name

    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }
    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f; // Freezes game physics and movement
        Cursor.visible = true; // Ensures mouse cursor is visible for UI selection
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f; // Unfreezes game
        isPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Must reset time scale before reloading!
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f; // Must reset time scale before changing scenes!
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
