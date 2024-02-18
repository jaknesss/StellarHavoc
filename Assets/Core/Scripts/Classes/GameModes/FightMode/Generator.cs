using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public EnemyState genState;
    public GameObject wire;
    public GeneratorCluster genCluster;
    public GameObject genBase;
    public Material greenMat;

    public void SingleGenDestroyed() {
        genBase.GetComponent<Renderer>().material = greenMat;
        genCluster.SingleGenDestroyed(gameObject, wire);
    }
}
