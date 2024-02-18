using System.Collections;
using UnityEngine;

public class BoostAbility : MonoBehaviour {

    [SerializeField] public Airplane plane;
    public AbilityTimer timer;
    private Rigidbody rb;
    private bool isOnCooldown = false;
    private float tempSpeedBoost = 200f;
    private float boostDuration = 2.5f;
    public float boostCoolDown = 10f;

    private void Start() {
        rb = plane.GetComponent<Rigidbody>();
    }


    //Il boost non ADESSO non va
    public void Activate() {
        if (isOnCooldown) return;
        timer.StartTimer(boostCoolDown);
        StartCoroutine(ActivateBoost());
    }

    private IEnumerator ActivateBoost() {
        isOnCooldown = true;
        yield return StartCoroutine(ApplyBoost());
        yield return new WaitForSeconds(boostCoolDown-boostDuration);
        isOnCooldown = false;
    }

    private IEnumerator ApplyBoost() {
        PlaneController.throttle += tempSpeedBoost;
        rb.AddForce(transform.forward * plane.getMaxThrust() * PlaneController.throttle);
        yield return new WaitForSeconds(boostDuration);
        PlaneController.throttle -= tempSpeedBoost;
        rb.AddForce(transform.forward * plane.getMaxThrust() * PlaneController.throttle);
    } 

}
