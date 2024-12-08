using UnityEngine;
using UnityEngine.EventSystems;

public class UnitDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
	
    private void Awake()
    {	
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
		if(!GetComponent<UnitDisplay>().unit.isMovable) return;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
		if(!GetComponent<UnitDisplay>().unit.isMovable) return;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
		if(!GetComponent<UnitDisplay>().unit.isMovable) return;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
		GameObject target = eventData.pointerCurrentRaycast.gameObject;
		UnitDropHandler dropHandler = target.GetComponent<UnitDropHandler>();
		if(dropHandler == null) GameManager.Instance.RefreshHandsAndRows();
    }
}
