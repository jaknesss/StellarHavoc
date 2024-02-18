using UnityEngine;


public class Turret : MonoBehaviour {
    public GameObject turret;
    public Gun gun;
    public Transform target;
    public EnemyState turretState;
    public float rotationSpeed;
    private float minDistance = 800;

    void Update() {
        if (target == null) return;
        if (turretState.getCurrHealth() < 0f) Destroy(turret);
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget <= minDistance) gun.Fire(gun.getBulletSpawnPoints());        

    }




}
