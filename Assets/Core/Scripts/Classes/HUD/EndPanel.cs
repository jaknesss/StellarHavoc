using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject EndGame;   
    public TextMeshProUGUI scoreboard;
    public TextMeshProUGUI totalTime;

    
    public void StopTime() {
        Time.timeScale = 0f;
    }

    public void ResumeTime(){
        Time.timeScale = 1f;
    }
    public void MenuButton() {
        SceneManager.LoadScene("Menu");
        EndGame.SetActive(false);
    }

    public void RetryButton() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        EndGame.SetActive(false);
    }

    public void makeScoreboard() {
        List<float> times = FindObjectOfType<ModeManager>().GetCheckpointTimes();
        List<string> formattedTimes = new List<string>();
        for (int i = 0; i < FindObjectOfType<CheckpointManager>().GetCheckpointNumber(); i++) {
            int minuti = Mathf.FloorToInt(times.ToArray()[i] / 60f);
            int secondi = Mathf.FloorToInt(times.ToArray()[i] % 60f);
            totalTime.text = minuti +":"+ secondi;
            totalTime.color = Color.green;
            string formattedTime = string.Format("["+(i+1)+"] = {0:00}:{1:00}", minuti, secondi);
            formattedTimes.Add(formattedTime);
        }
        string scoreboardText = string.Join("\n", formattedTimes);
        scoreboard.text = scoreboardText;
    }

    public void QuitButton() { Application.Quit(); }


}
