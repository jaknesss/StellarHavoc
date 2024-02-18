using UnityEngine;

public class Checkpoint : MonoBehaviour {


    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            FindAnyObjectByType<AudioManager>().Play("ShieldDestroyed");
            FindObjectOfType<CheckpointManager>().PlayerReachedCheckpoint(this.transform);
            GetComponent<Collider>().enabled = false;
        }
    }
}
