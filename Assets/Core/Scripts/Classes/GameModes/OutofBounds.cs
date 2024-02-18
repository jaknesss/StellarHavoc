using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBounds : MonoBehaviour {

    public GameObject outOfBoundPanel;
    public EnemyState starship;
    public Transform respawnpoint;
    public float outOfBoundDamage;
    public float outOfBoundDistance;
    private bool isOutofBounds;
    private float distance;

    
    void FixedUpdate() {
        distance = Vector3.Distance(respawnpoint.position, starship.transform.position);
        if (distance >= outOfBoundDistance && starship.getCurrHealth() >= 0) {
            outOfBoundPanel.SetActive(true);
            starship.DoDamage(outOfBoundDamage);
        } else outOfBoundPanel.SetActive(false);
    }

    public bool isStarshipOutOfBound(){ return isOutofBounds; }

}
