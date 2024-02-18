using UnityEngine;

public class Gun : MonoBehaviour {

    public AudioManager audioManager;
    public Bullet bullet;
    public Transform[] bulletSpawnPoints;
    public float fireRate;
    public bool isEnemy;
    public bool automaticFire;
    
    private float nextFireTime;

    private void FixedUpdate() {
        if (automaticFire) Fire(bulletSpawnPoints);
    }
    public void Fire(Transform[] SpawnPoints) {
        if (Time.time >= nextFireTime)
            for (int i = 0; i < SpawnPoints.Length; i++) {
                ShootBulletFromSpawnPoint(SpawnPoints[i]);            
                nextFireTime = Time.time + 1f / fireRate;
            }
    }
    private void ShootBulletFromSpawnPoint(Transform spawnPoint) {
        Bullet newBullet = Instantiate(this.bullet.GetComponent<Bullet>(), spawnPoint.position, spawnPoint.rotation);
        newBullet.SetIsShooterEnemy(isEnemy);
        Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = spawnPoint.forward * newBullet.getBulletSpeed();
    }
   
    public float getFireRate() { return fireRate; }
    public Bullet getBullet() { return bullet; }
    public Transform[] getBulletSpawnPoints() { return bulletSpawnPoints; }

    public EnemyState GetEnemyStateFromBullet() {
        Debug.Log(bullet.GetEnemyOnCollision());
        return bullet.GetEnemyOnCollision();
    }
}
