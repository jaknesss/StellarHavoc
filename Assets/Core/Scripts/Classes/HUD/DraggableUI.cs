using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUI : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {
    private RectTransform rectTransform;
    private Canvas canvas;
    private bool isDragging;
    private bool isEditModeActive = false; // Variabile per indicare se la modalità di modifica è attiva
    private Button buttonComponent;
    private EventTrigger eventTriggerComponent;

    void Start() {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        buttonComponent = GetComponent<Button>();
        eventTriggerComponent = GetComponent<EventTrigger>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (isEditModeActive) isDragging = true;
    }

    public void OnDrag(PointerEventData eventData) {
        if (isEditModeActive && isDragging) {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localPoint);
            rectTransform.localPosition = localPoint;
        }
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (isEditModeActive) isDragging = false;
    }
    public void SetEditMode(bool isActive) {
        isEditModeActive = isActive;
        if (buttonComponent != null) buttonComponent.interactable = !isActive;
        if (eventTriggerComponent != null) eventTriggerComponent.enabled = !isActive;
    }
    public bool GetEditModeState() { return isEditModeActive; }
}
