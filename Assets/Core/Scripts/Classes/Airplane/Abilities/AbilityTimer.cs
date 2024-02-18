using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AbilityTimer : MonoBehaviour {
    public Image timerImage;

    public void StartTimer(float abilityDuration) {
        StartCoroutine(UpdateCooldown(abilityDuration));
    }

    private IEnumerator UpdateCooldown(float abilityDuration) {
        float remainingDuration = abilityDuration;
        float startTime = Time.time;
        while (remainingDuration > 0) { 
            float elapsed = Time.time - startTime;
            float normalizedTime = Mathf.Clamp01(elapsed / abilityDuration);
            timerImage.fillAmount = 1 - normalizedTime;
            remainingDuration = abilityDuration - elapsed;
            yield return null; // Wait for the next frame
        }
        timerImage.fillAmount = 0; // Assicurati che fillAmount sia esattamente 0 alla fine
    }
}
