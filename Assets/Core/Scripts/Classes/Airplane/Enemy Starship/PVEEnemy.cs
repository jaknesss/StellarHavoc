using System;
using UnityEngine;

public class PVEEnemy : MonoBehaviour {

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Airplane target;
    [SerializeField] private PlaneController targetContr;
    [SerializeField] private PlaneController myContr;
    [SerializeField] private GameObject explosionPrefab;

    [SerializeField] private float rotateSpeed = 95;

    [SerializeField] private float maxDistancePredict = 100;
    [SerializeField] private float minDistancePredict = 5;
    [SerializeField] private float maxTimePrediction = 5;
    private Vector3 standardPrediction, deviatedPrediction;

    [SerializeField] private float deviationAmount = 50;
    [SerializeField] private float deviationSpeed = 2;

    private float minimumShootingDistance = 500f;
    public Airplane CurrTarget;

    private void Start() {
        CurrTarget = target;
    }

    public void LoseTarget() { target = null; }
    public void RegainTarget() { target = CurrTarget; }
    private void FixedUpdate() {
        if (target == null) return;
        float leadTimePercentage = Mathf.InverseLerp(minDistancePredict, maxDistancePredict, Vector3.Distance(transform.position, target.transform.position));
        PredictMovement(leadTimePercentage);
        AddDeviation(leadTimePercentage);
        Rotate();
        rb.AddForce(targetContr.getForce1() / 100f);
        rb.AddForce(targetContr.getForce2() / 100f);
        float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);
        if (distanceToPlayer < minimumShootingDistance) myContr.FireGuns();
    }

    private void PredictMovement(float leadTimePercentage)
    {
        float predictionTime = Mathf.Lerp(0, maxTimePrediction, leadTimePercentage);
        standardPrediction = target.GetComponent<Rigidbody>().position + target.GetComponent<Rigidbody>().velocity * predictionTime;
    }

    private void AddDeviation(float leadTimePercentage)
    {
        Vector3 deviation = new Vector3(Mathf.Cos(Time.time * deviationSpeed), 0, 0);
        Vector3 predictionOffset = transform.TransformDirection(deviation) * deviationAmount * leadTimePercentage;
        deviatedPrediction = standardPrediction + predictionOffset;
    }

    private void Rotate()
    {
        Vector3 heading = deviatedPrediction - transform.position;
        Quaternion rotation = Quaternion.LookRotation(heading);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, standardPrediction);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(standardPrediction, deviatedPrediction);
    }
}
