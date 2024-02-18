using UnityEngine;

public class Arrow : MonoBehaviour {
    public Transform target;
    void Update() {
        if (target == null) return;
        Vector3 dirToTarget = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(dirToTarget);
        transform.rotation = lookRotation;
    }
    public void UpdateTarget(Transform newTarget) {
        target = newTarget;
    }
}
