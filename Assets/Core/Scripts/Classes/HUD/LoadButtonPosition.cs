using UnityEngine;

public class LoadButtonPosition : MonoBehaviour {

    public UIManager UI;
    public DefaulUIPosition defaultUIP;
    private DraggableUI[] elementsToDrag; // Array degli elementi UI trascinabili
    private DraggableUI[] standardPostElementsToDrag; // Array degli elementi UI trascinabili
    private bool isFirstTime = true; // Flag per verificare se è la prima volta che il giocatore apre il gioco

    void Start() {
        elementsToDrag = UI.getElementsToDrag();
        isFirstTime = PlayerPrefs.GetInt("IsFirstTime", 1) == 1;
        if (isFirstTime) SetDefaultPositions();
        else LoadPositions();
    }
    void SetFirstTime(bool value) {
        isFirstTime = value;
        PlayerPrefs.SetInt("IsFirstTime", isFirstTime ? 1 : 0); // Salva isFirstTime
        PlayerPrefs.Save();
    }

    public void LoadPositions() {
        for (int i = 0; i < elementsToDrag.Length; i++) {
            float posX = PlayerPrefs.GetFloat("Element_" + i + "_PosX", 0);
            float posY = PlayerPrefs.GetFloat("Element_" + i + "_PosY", 0);
            Vector2 newPosition = new Vector2(posX, posY);
            elementsToDrag[i].GetComponent<RectTransform>().anchoredPosition = newPosition;
        }
    }

    void SetDefaultPositions() {
        standardPostElementsToDrag = defaultUIP.getStandardPos(); 
        for (int i = 0; i < standardPostElementsToDrag.Length; i++) {
            float defaultPosX = standardPostElementsToDrag[i].GetComponent<Transform>().position.x;
            float defaultPosY = standardPostElementsToDrag[i].GetComponent<Transform>().position.y;
            PlayerPrefs.SetFloat("Element_" + i + "_PosX", defaultPosX);
            PlayerPrefs.SetFloat("Element_" + i + "_PosY", defaultPosY);
        }
        SetFirstTime(false);
        PlayerPrefs.Save();
    }
}    