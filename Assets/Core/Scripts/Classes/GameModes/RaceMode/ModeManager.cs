using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour {
    public CheckpointManager checkpointManager;
    public TimerController timerController;
    public GameObject endgamePanel;
    public GameObject gameOverPanel;
    public EnemyState starship;
    public List<float> checkpointTimes;
    public float lastCheckpointTime;


    // Start is called before the first frame update

    private void Awake() {
        FindAnyObjectByType<AudioManager>().Play("ThemeSong");
    }
    void Start() {
        PlaneController.throttle = 0f;
        timerController.EnableTimerController();
        checkpointManager.GenerateAll();
        checkpointTimes = new List<float>();
    }

    private void FixedUpdate() {
        if (starship.getCurrHealth() <= 0) GameOver();
    }

    public void EndGame() {
        timerController.EndTimer();
        endgamePanel.SetActive(true);
        lastCheckpointTime = checkpointTimes.ToArray()[checkpointTimes.Count-1];
        endgamePanel.GetComponent<EndPanel>().makeScoreboard();
    }

    public void GameOver() {
        timerController.EndTimer();
        gameOverPanel.SetActive(true);
    }


    public void addCheckpointTime() {
        checkpointTimes.Add(timerController.GetCurrentTime());
    }

    public float GetLastCheckpointTime() { return lastCheckpointTime;  }

    public List<float> GetCheckpointTimes() { return checkpointTimes; }

}
