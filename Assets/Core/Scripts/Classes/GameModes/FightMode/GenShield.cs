using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenShield : MonoBehaviour {
    
    private bool isDestroyed;
    public GeneratorCluster genCluster;
    
    void FixedUpdate() {
        if (!isDestroyed && genCluster.GetCurrentgenDestroyed() >= 3) {
            FindAnyObjectByType<AudioManager>().Play("ShieldDestroyed");
            gameObject.SetActive(false);
            isDestroyed = true;
        }

    }
}
