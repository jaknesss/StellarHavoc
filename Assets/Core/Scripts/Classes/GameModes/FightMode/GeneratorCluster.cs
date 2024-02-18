using Unity.VisualScripting;
using UnityEngine;

public class GeneratorCluster : MonoBehaviour {

    public GameObject kernel;
    public EnemyState kernelState;

    private int genDestroyedCounter = 0;
    private bool kernelDestroyed;

    public int genIndex;
    private GeneratorManager manager;
    
    void Start() {
        kernelDestroyed = false;
        manager = FindAnyObjectByType<GeneratorManager>();
    }

    private void FixedUpdate() {
        if (!kernelDestroyed && kernelState.getCurrHealth() < 0f) {
            kernelDestroyed = true;
            kernel.SetActive(false);
            manager.PlayerDestroyedKernel(genIndex);    
        }
    }

    public void SingleGenDestroyed(GameObject singleGen, GameObject wire) {
        genDestroyedCounter++;
        singleGen.SetActive(false);     
        wire.SetActive(false);          
    }

    public void SetGenIndex(int index) { genIndex = index; }

    public int GetCurrentgenDestroyed() {
        return genDestroyedCounter;
    }
}
