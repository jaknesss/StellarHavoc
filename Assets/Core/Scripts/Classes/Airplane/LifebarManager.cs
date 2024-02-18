using TMPro;
using UnityEngine;
using UnityEngine.UI;
    

public class LifebarManager : MonoBehaviour {
    
    public EnemyState objState;
    public TextMeshProUGUI lifePoints;
    public Image lifeBarImage;
    private float maxLifepoints;
    private float currLifepoints;


    private void Start() {
        if (objState == null) return;
        SetUpLifebarValues();
    }

    private void FixedUpdate() {
        lifePoints.text = currLifepoints.ToString("F0");
    }
    public void TakeDamage(float damage) {
        if (objState == null) return;
        currLifepoints -= damage;
        lifeBarImage.fillAmount = currLifepoints / maxLifepoints;
        if (lifeBarImage.fillAmount < 0.25f) lifeBarImage.color = new Color(1f, 0.5f, 0f); // Orange Color
    }

    private void SetUpLifebarValues() {
        maxLifepoints = objState.getMaxHealth();
        currLifepoints = maxLifepoints;
    }
}