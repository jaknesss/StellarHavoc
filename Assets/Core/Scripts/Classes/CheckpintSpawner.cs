using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCheckpoints : MonoBehaviour {
    public GameObject[] checkpointPrefab;
    public float depth;
    private int numberOfCheckpoints = 10;

    void Start() {  SpawnRandomCheckpoints();  }

    void SpawnRandomCheckpoints() {
        Vector3 spawnPosition = Vector3.zero; // Posizione iniziale 
        for (int i = 0; i < numberOfCheckpoints; i++) {
            float randomX = Random.Range(-1000f, 1000f); // Modifica i valori in base alle tue esigenze
            float randomY = Random.Range(50, 1000f); // Modifica i valori in base alle tue esigenze
            spawnPosition.z += depth;
            spawnPosition.x = randomX;
            spawnPosition.y = randomY;
            Instantiate(checkpointPrefab[i % checkpointPrefab.Length], spawnPosition, Quaternion.identity);
        }
    }
}
