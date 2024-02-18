using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;   //serve per far scomparire la scena del menu
    public void MenuButton() {
        SceneManager.LoadScene("Menu");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ResumeButton() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void PauseButton() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void QuitButton() { Application.Quit(); }

    


}
