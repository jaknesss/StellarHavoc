using UnityEngine;
using UnityEngine.UI;

public class TrackEnemies : MonoBehaviour {
    public string enemyTag = "Enemy";
    public Transform starship;   // Riferimento all'aeroplano che controlli
    public float povAngle = 65f; // Angolo di visuale dell'aereo
    public float timer = 10f;
    private static GameObject acquiredEnemy; // GameObject acquisito

    public void TrackSingleEnemy() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        if(enemies == null )Debug.Log("Here");
        float maxDistance = Mathf.Infinity;
        acquiredEnemy = null; 
        foreach (GameObject enemy in enemies) {
            Vector3 enemyDir = enemy.transform.position - starship.position;
            float angleStarshipEnemy = Vector3.Angle(starship.forward, enemyDir);
            if (angleStarshipEnemy <= povAngle / 2) {
                float distance = Vector3.Distance(starship.position, enemy.transform.position);
                if (distance < maxDistance) {
                    maxDistance = distance;
                    acquiredEnemy = enemy;
                }
            }
        }
        //Debug.Log(acquiredEnemy.name);
        if (acquiredEnemy != null)  Invoke("ClearAcquiredObject", timer);
    }

    private void ClearAcquiredObject() { acquiredEnemy = null; }

    public static GameObject GetAcquiredEnemy() { return acquiredEnemy; }

    private void OnDrawGizmos() {
        if (starship != null && acquiredEnemy != null) {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(starship.position, acquiredEnemy.transform.position);
        }
    }
}
