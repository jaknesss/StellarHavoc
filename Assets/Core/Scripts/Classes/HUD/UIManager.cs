using UnityEngine;

public class UIManager : MonoBehaviour {
    public DraggableUI[] elementsToDrag; // Array degli elementi UI trascinabili 
    
    public void ToggleEditMode() {
        bool isActive = !elementsToDrag[0].GetEditModeState(); 
        foreach (DraggableUI element in elementsToDrag)
            element.SetEditMode(isActive);
    }
    public void DisableEditMode() {
        foreach (DraggableUI element in elementsToDrag)
            element.SetEditMode(false); // Disattiva la modalità di modifica per tutti gli elementi
    }

    public void SavePositions() {
        for (int i = 0; i < elementsToDrag.Length; i++) {
            Vector2 position = elementsToDrag[i].GetComponent<RectTransform>().anchoredPosition;
            PlayerPrefs.SetFloat("Element_" + i + "_PosX", position.x);
            PlayerPrefs.SetFloat("Element_" + i + "_PosY", position.y);
        }
        PlayerPrefs.Save();
    }

    public DraggableUI[] getElementsToDrag() { return elementsToDrag; }
}

