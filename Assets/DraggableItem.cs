using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public Canvas canvas;              // Reference to the main Canvas
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;   // CanvasGroup for controlling interactivity

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        // Optional: make item semi-transparent while dragging
        canvasGroup.alpha = 0.6f;
        // Disable raycast so drop targets can detect pointer
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData) {
        // Move the object with the pointer
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        // Restore full opacity
        canvasGroup.alpha = 1f;
        // Re-enable raycast blocking (so item will register pointer events again)
        canvasGroup.blocksRaycasts = true;
    }
}
