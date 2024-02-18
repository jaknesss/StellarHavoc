using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class EnemyState : MonoBehaviour {
    public ParticleSystem explosionPrefab;
    public MeshDestroy meshDestroy;
    public LifebarManager lifebar;
    public GameObject obj;
    public Generator singleGen;
    public float maxLifePoint;
    public float currLifePoint;
    public bool isDestroyable;
    public bool isInvincible;

    private bool isExploded;
    private bool isSingleGenDestroyed;

    private void Start() { currLifePoint = maxLifePoint; }
    public float getCurrHealth() { return currLifePoint; }
    public float getMaxHealth() { return maxLifePoint; }
    public void DoDamage(float damage) {
        if (isInvincible) return;
        currLifePoint -= damage;
        if(lifebar != null) lifebar.TakeDamage(damage);
        if (currLifePoint < 0f) {
            if (!isExploded && explosionPrefab != null) {
                Explode();
                isExploded = true;
            }
            if (!isSingleGenDestroyed && singleGen != null) {
                singleGen.SingleGenDestroyed();
                isSingleGenDestroyed = true;
            }
            obj.SetActive(false);
            if (isDestroyable) meshDestroy.DestroyMesh();
        }
    }
    private void Explode() {
        ParticleSystem explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explosionInstance.Play();
        Destroy(explosionInstance.gameObject, explosionInstance.main.duration);
    }

    public void SetCurrLifePoints(int value) {
        currLifePoint = value;
    }
    public void SetInvincibility() {
        isInvincible = true;
    }
    public void RemoveInvincibility()
    {
        isInvincible = false;
    }
}



