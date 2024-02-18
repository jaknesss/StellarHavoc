using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
    [SerializeField] public GameObject[] asteroidPrefabs; 
    public int numberOfAsteroids;                        
    public float xCoord, yCoord, zCoord; 
    private int[] sizes = { 5, 5, 5, 5, 5, 15, 15, 15, 15, 15, 15, 50, 100 }; // sizes ripetute per aumentarne la probabilità di spawn
    
    void Start() { SpawnAsteroids(); }
    void SpawnAsteroids() {
        GameObject asteroidsParent = new GameObject("AsteroidsSpawn");  //Nasconde gli asteroidi nella gerarchia 
        for (int i = 0; i < numberOfAsteroids; i++) {
            Vector3 spawnPosition = new Vector3(Random.Range(-xCoord, xCoord), Random.Range(-yCoord, yCoord), Random.Range(-zCoord, zCoord));
            int randomSize = sizes[Random.Range(0, sizes.Length)]; // Dimensione casuale dell'asteroide
            GameObject newAsteroid = Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], spawnPosition, Quaternion.identity);
            newAsteroid.transform.parent = asteroidsParent.transform;
            newAsteroid.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
            newAsteroid.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(-100000, 100000) / randomSize * 10);
        }
    } 

    /*
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "PVE" ) Destroy(this); 
    }
    */
}



