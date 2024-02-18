using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour {
    [SerializeField] public TextMeshProUGUI timerText;
    [SerializeField] public TextMeshProUGUI reducedTimerText;
    public float timeIncreaseRate = 1f;    // Tasso di aumento del timer per secondo

    private float currentTime;
    private bool isCountingUp;

    public void EnableTimerController() {
        ResetTimer();
        StartTimer();
    }

    void FixedUpdate() {
        if (isCountingUp) {
            currentTime += Time.deltaTime * timeIncreaseRate;
            UpdateTimerText();
        }
    }

    public void StartTimer()
    {
        isCountingUp = true;
    }

    public void ResetTimer()
    {
        currentTime = 0f;
        UpdateTimerText();
    }

    // Viene chiamato dall'esterno
    public void EndTimer() {
        isCountingUp = false;
    }

    public void ReduceTimer(float reduceAmount) {
        StartCoroutine(ShowReducedTimer(reduceAmount));
    }

    private System.Collections.IEnumerator ShowReducedTimer(float reduceAmount) {
        reducedTimerText.gameObject.SetActive(true);
        reducedTimerText.text = string.Format("-" + reduceAmount + ".00s");
        currentTime -= reduceAmount;
        currentTime = Mathf.Max(0f, currentTime);
        UpdateTimerText();
        yield return new WaitForSeconds(3f);
        reducedTimerText.gameObject.SetActive(false);
    }

    private void UpdateTimerText() {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public float GetCurrentTime() { return currentTime; }
}
