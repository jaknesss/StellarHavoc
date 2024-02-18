using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailFadììeIn : MonoBehaviour
{
    [SerializeField] public Airplane plane;
    [SerializeField] public GameObject trail;
    [SerializeField] float tresholdSpeedFadeIn;

    private Rigidbody rb;
    private TrailRenderer tr;
    private float widthMult;
    private void Start() {
        rb = plane.GetComponent<Rigidbody>();
        tr = trail.GetComponent<TrailRenderer>();
    }

    public void setTrailWidth(float sliderValue) { widthMult = sliderValue * 2 / 100; }

    private void Update() {
        if (rb.velocity.magnitude * 3.6f > tresholdSpeedFadeIn) tr.startWidth = widthMult;    
    }
}
