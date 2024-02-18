using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareAbility : MonoBehaviour {
    public AbilityTimer timer;
    public Airplane starship;

    public PVEEnemy enemyStarship;
    private float flareDuration = 8f;
    public float flareCoolDown = 15f;
    private bool isOnCooldown = false;
    private Material[] originalMaterials;
    public Material cloakMaterial;

    void Start() {
        originalMaterials = starship.GetComponentInChildren<MeshRenderer>().materials;
    }


    /*private void FixedUpdate() {
        if (enemyStarship == null) return;
    }
    */
    public void Activate() {
        if (enemyStarship == null) return;
        if (isOnCooldown) return;
        timer.StartTimer(flareCoolDown);
        StartCoroutine(ActivateFlare());
    }

    private IEnumerator ActivateFlare() {
        Material[] currentMaterials = starship.GetComponentInChildren<MeshRenderer>().materials;
        currentMaterials[0] = cloakMaterial;
        starship.GetComponentInChildren<MeshRenderer>().materials = currentMaterials;
        enemyStarship.LoseTarget();
        isOnCooldown = true;
        yield return new WaitForSeconds(flareDuration);
        starship.GetComponentInChildren<MeshRenderer>().materials = originalMaterials;
        enemyStarship.RegainTarget();
        yield return new WaitForSeconds(flareCoolDown - flareDuration);
        isOnCooldown = false;
    }

    public void SetEnemyStarship(PVEEnemy enemy) {
        enemyStarship = enemy;
    }

    public void ResetEnemyStarshipTarget() {
        enemyStarship = null;
    }

}
