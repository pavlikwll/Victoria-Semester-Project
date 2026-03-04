using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverContainer;

    private bool _isPaused;
    
    public void GameOverScreen()
    {
        print("Game Over Fuck You");
        _isPaused = !_isPaused;
        gameOverContainer.SetActive(true);
        Time.timeScale = _isPaused ? 0 : 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //öffnet den GameOverScreen
    }

  
   public void RestartScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //sucht die aktive Szene raus, um sie zu restarten
        
        gameOverContainer.SetActive(false);
        Time.timeScale = 1;
        // Startet Scene Neu und Aktiviert GameTime
    }


}