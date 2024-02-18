using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hudUpdate : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI fps;
    [SerializeField] private TextMeshProUGUI speed;
    [SerializeField] private TextMeshProUGUI throttle;
    [SerializeField] private TextMeshProUGUI objective;
    [SerializeField] private GameObject plane;
    [SerializeField] private PlaneController cont;
    [SerializeField] private GeneratorManager genManager;
    [SerializeField] private CheckpointManager checkManager;
    private Rigidbody rb;

    private float fpsUpdateInterval = 0.5f; 
    private float accum = 0; 
    private int frames = 0;  
    private float timeLeft;  

    private void Awake() {
        Application.targetFrameRate = 60;
        rb = plane.GetComponent<Rigidbody>();
        timeLeft = fpsUpdateInterval;
    }

    private void Update() {
        UpdateHUD();
        UpdateFPS();
    }

    private void UpdateHUD() {
        speed.text = (rb.velocity.magnitude * 3.6f).ToString("F0") + "km/h"; 
        fps.text = "FPS: " + CalculateFPS().ToString("F2");
        if (genManager != null) objective.text = "Generators remaining: " + (4-genManager.GetObjDestroyedCounter()).ToString("F0");
        if (checkManager != null) objective.text = "Checkpoint: " + checkManager.GetCheckpointCurrNum() + "/10";
        throttle.text = cont.getThrottle().ToString("F0");
    }

    private float CalculateFPS() { return 1.0f / Time.deltaTime; }

    private void UpdateFPS() {
        timeLeft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        frames++;
        if (timeLeft <= 0.0f) {
            float fps = accum / frames;
            timeLeft = fpsUpdateInterval;
            accum = 0;
            frames = 0;
        }
    }
}
