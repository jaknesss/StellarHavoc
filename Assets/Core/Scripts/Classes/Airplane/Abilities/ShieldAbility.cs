using System.Collections;
using UnityEngine;

public class ShieldAbility : MonoBehaviour {
    public GameObject shield;
    public EnemyState starshipState;
    public AbilityTimer timer;
    private bool isOnCooldown = false;
    private float shieldDuration = 5f;
    private float shieldCoolDown = 15f;
    
    public void Activate() {
        if (isOnCooldown) return;
        timer.StartTimer(shieldCoolDown);
        StartCoroutine(ActivateShield());
    }

    private IEnumerator ActivateShield() {
        shield.SetActive(true);
        isOnCooldown = true;
        yield return new WaitForSeconds(shieldDuration);
        shield.SetActive(false);
        starshipState.RemoveInvincibility();
        yield return new WaitForSeconds(shieldCoolDown-shieldDuration);
        isOnCooldown = false;
    }
}