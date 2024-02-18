using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {

    private List<GameObject> checkpoints;
    public GameObject checkpointPrefab;
    public Arrow arrowHUD;
    public Transform player;
    private GameObject nextCheckpoint;
    private GameObject previousCheckpoint;

    public float xCoord, yCoord, zCoord;
    public int numberOfCheckpoints;
    public int currCheckpointIndex = 0;


    //Rende lo spawn gestibile da ModeManager
    public void GenerateAll() {
        checkpoints = new List<GameObject>();
        SpawnCheckpoints();
    }


    void SpawnCheckpoints() {
        for (int i = 0; i < numberOfCheckpoints; i++) {
            Vector3 spawnPosition = new Vector3(Random.Range(-xCoord, xCoord),
                                                Random.Range(-yCoord, yCoord),
                                                Random.Range(-zCoord, zCoord));
            GameObject newCheckpoint = Instantiate(checkpointPrefab, spawnPosition, Random.rotation);
            checkpoints.Add(newCheckpoint);
        }
        nextCheckpoint = checkpoints.ToArray()[currCheckpointIndex];
        FindAnyObjectByType<ModeManager>().addCheckpointTime();
        ChangeColor(nextCheckpoint);
        arrowHUD.UpdateTarget(nextCheckpoint.transform);
    }

    public void PlayerReachedCheckpoint(Transform checkpointReached){
        
        nextCheckpoint.gameObject.SetActive(false);
        if (nextCheckpoint.transform == checkpointReached){
            FindAnyObjectByType<ModeManager>().addCheckpointTime();
            currCheckpointIndex++;
        }
        if (currCheckpointIndex == numberOfCheckpoints) {
            FindAnyObjectByType<ModeManager>().EndGame();
            arrowHUD.gameObject.SetActive(false);
            return;
        }
        nextCheckpoint = checkpoints.ToArray()[currCheckpointIndex];
        arrowHUD.UpdateTarget(nextCheckpoint.transform);
        ChangeColor(nextCheckpoint);
    }


    public int GetCheckpointNumber() { return numberOfCheckpoints; }
    public int GetCheckpointCurrNum() { return currCheckpointIndex; }

    public GameObject GetPreviusCheckpoint() { return previousCheckpoint; }

    private void ChangeColor(GameObject checkpoint)
    {
        nextCheckpoint.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f,
                                                              nextCheckpoint.GetComponent<SpriteRenderer>().color.a);
    }

}
