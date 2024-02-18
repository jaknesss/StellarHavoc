using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour {
    public FightModeManager fightModeManager;
    public GameObject generatorPrefab;
    public Transform[] gensSpawnpoints;
    public GameObject[] mothershipLights;
    public GameObject[] enemyStarships;
    public FlareAbility flare;
    public Material greenMat;
    public Arrow dirArrow;

    private List<GameObject> generators;
    private bool isFinished;
    private int objectiveDestroyedCounter = 0;

    private void FixedUpdate() {
        if(objectiveDestroyedCounter <= 3) dirArrow.UpdateTarget(enemyStarships[objectiveDestroyedCounter].transform);
    }

    public void GenerateAll() {
        generators = new List<GameObject>();
        SpawnGenerators();
    }

    void SpawnGenerators() {
        for (int i = 0; i < gensSpawnpoints.Length; i++) {
            Vector3 spawnPosition = new Vector3(gensSpawnpoints[i].position.x, gensSpawnpoints[i].position.y, gensSpawnpoints[i].position.z);
            GameObject newGenerator = Instantiate(generatorPrefab, spawnPosition, Quaternion.identity);
            generators.Add(newGenerator);
            generators.ToArray()[i].GetComponent<GeneratorCluster>().SetGenIndex(i);
        }
    }

    public void PlayerDestroyedKernel(int index) {
        objectiveDestroyedCounter++;
        if(objectiveDestroyedCounter <= 3) enemyStarships[objectiveDestroyedCounter].SetActive(true);                               //Spawna la nuova EnemyStarship
        flare.ResetEnemyStarshipTarget();                                                         //La Flare Ability perde il target della precedente EnmeyStarship       
        if(objectiveDestroyedCounter <= 3) flare.SetEnemyStarship(enemyStarships[objectiveDestroyedCounter].GetComponent<PVEEnemy>());
        mothershipLights[index].GetComponent<Renderer>().material = greenMat;                     //il materiale della luce della Mothership viene cambiato al Verde
        if (generators.ToArray().Length == objectiveDestroyedCounter) fightModeManager.EndGame(); //+1 perchè objectiveDestroyedCounter parte da 0
    }
    public bool isFightFinished() { return isFinished; }

    public GameObject GetFlareAbilityTarget() {
        return enemyStarships[objectiveDestroyedCounter];
    }

    public int GetObjDestroyedCounter() { return objectiveDestroyedCounter; }
}
