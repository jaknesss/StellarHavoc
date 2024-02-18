using UnityEngine;

public class FightModeManager : MonoBehaviour
{
    public GeneratorManager generatorManager;
    public TimerController timerController;
    public GameObject endgamePanel;
    public GameObject gameOverPanel;
    public GameObject destroyerLaser;
    public EnemyState starship;
    public Animator deathRay;
    public AudioManager audioManager;
    
    private bool isGameOver;
    private float maxModeDuration = 300; // == 5 minuti
    

    void Start() {
        audioManager.Play("ThemeSong");
        PlaneController.throttle = 0f;
        timerController.EnableTimerController();
        generatorManager.GenerateAll();
    }

    private void FixedUpdate() {
        float currentTime = timerController.GetCurrentTime();
        if (!isGameOver && ( starship.getCurrHealth() < 0) || (currentTime >= maxModeDuration)) {
            isGameOver = true;
            GameOver();
        }
    }

    public void EndGame() {
        timerController.EndTimer();
        deathRay.SetBool("CloseHatch", true);
    }

    public void GameOver() {
        timerController.EndTimer();
        gameOverPanel.SetActive(true);
    }
}
