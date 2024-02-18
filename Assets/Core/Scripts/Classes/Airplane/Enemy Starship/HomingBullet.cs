using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : MonoBehaviour {
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _rotateSpeed = 95;

    private GameObject _target;

   
    private void FixedUpdate() {
        _target = TrackEnemies.GetAcquiredEnemy();
        if (_target == null) return;
        Vector3 targetPosition = _target.transform.position;
        _rb.velocity = _rb.transform.forward;
        RotateTowardsTarget(targetPosition); 
    }
        
    private void RotateTowardsTarget(Vector3 targetPosition) {
        Vector3 direction = targetPosition - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        _rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, _rotateSpeed * Time.deltaTime));
    }
}






