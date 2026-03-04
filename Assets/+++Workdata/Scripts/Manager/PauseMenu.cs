using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuContainer;
    public GameObject pauseOptionsMenuContainer;
    
    public static bool isPaused;

    void Awake() 
    {
        pauseMenuContainer.SetActive(false);
        pauseOptionsMenuContainer.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
    
    public void OpenPauseMenu()
    {
        isPaused = !isPaused;
        pauseMenuContainer.SetActive(true);
        Time.timeScale = isPaused ? 0 : 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
     public void OpenPauseOptionsMenu()
    {
        pauseMenuContainer.SetActive(false);
        pauseOptionsMenuContainer.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        pauseOptionsMenuContainer.SetActive(false);
        pauseMenuContainer.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuContainer.SetActive(false);
        Time.timeScale = 1;
    }

   
}
