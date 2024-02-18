using UnityEngine;
using UnityEngine.UI;

public class SwitchWeapon : MonoBehaviour {
    public GameObject primaryWeaponCircle; 
    public GameObject secondaryWeaponCircle; 
    public GameObject RPGpointer; 
    private bool isPrimary = true; 

    public void OnSwitchButtonClicked() {
        isPrimary = !isPrimary; // Inverti lo stato quando il pulsante viene premuto
        if (isPrimary) {
            primaryWeaponCircle.SetActive(true);
            secondaryWeaponCircle.SetActive(false);
            RPGpointer.SetActive(false);
        }else{
            secondaryWeaponCircle.SetActive(true);
            RPGpointer.SetActive(true);
        }
    }
}
