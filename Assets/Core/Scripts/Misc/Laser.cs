using UnityEngine;

public class Laser : MonoBehaviour {

    public EnemyState starship;
    private float laserDamage = 10;


    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != "Player") return;
        starship.DoDamage(laserDamage);
    }
}
