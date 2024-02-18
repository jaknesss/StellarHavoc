using UnityEngine;

public class Bullet : MonoBehaviour {
    public ParticleSystem explosionPrefab;
    public float life;
    public float bulletSpeed;
    public float damage;
    private bool isShooterAnEnemy;
    private EnemyState enemyHitOnCollsion;
    public bool itExplodes;
    public float getBulletSpeed() { return this.bulletSpeed; }

    
    private void Awake() { Destroy(gameObject, life); }

    private void OnCollisionEnter(Collision collision) {
        if (itExplodes) Explode();
        if (collision.gameObject.tag == "Shield") return;
        if (!isShooterAnEnemy && collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player") {
            EnemyState enemy = collision.gameObject.GetComponent<EnemyState>();
            enemy.DoDamage(damage);
            if (enemy.getCurrHealth() == 0) enemy.DoDamage(1);   //peggior script mai visto
        }
        Destroy(gameObject);  
    }
    private void Explode() {
        ParticleSystem explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explosionInstance.Play();
        Destroy(explosionInstance.gameObject, explosionInstance.main.duration);
    }

    // Funzioni pre implementare la EnemyLifbar (BONANIMA)

    public void SetIsShooterEnemy(bool value) {
        isShooterAnEnemy = value;
    }
    public EnemyState GetEnemyOnCollision() {
        return enemyHitOnCollsion;
    }
    private void SetEnemyOnCollsion(EnemyState enemy) {
        enemyHitOnCollsion = enemy;
    }
}
