using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject canvasMenu;   //serve per far scomparire la scena del menu
    public void PlayRaceMode() {
        SceneManager.LoadScene("RaceMode");
        canvasMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void PlayFightMode() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        canvasMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }


    public void QuitGame() {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #elif UNITY_STANDALONE
            Application.Quit();
    #elif UNITY_ANDROID
            System.Diagnostics.Process.GetCurrentProcess().Kill();
    #endif
    }

}

