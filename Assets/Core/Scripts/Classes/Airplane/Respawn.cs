using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Respawn : MonoBehaviour {
    [SerializeField] public Airplane obj;
    [SerializeField] public Transform respawnPoint;
    private float respX;
    private float respY;
    private float respZ;

    private Transform objTf;
    private bool isPressed;
    
    void Start() {
        objTf = obj.GetComponent<Transform>(); 
        respX = respawnPoint.position.x;
        respY= respawnPoint.position.y;
        respZ = respawnPoint.position.z;
    }

    void Update() {
        if (isPressed) {
            objTf.position = new Vector3(respX, respY, respZ);
            isPressed = false;
        }
    }
    public void setRespawn() { isPressed = true; }
}
