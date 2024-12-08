using UnityEngine;
using UnityEngine.EventSystems;

public class CardDropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag;
        if (draggedObject != null && draggedObject.GetComponent<CardDisplay>() != null)
        {
			GameManager.Instance.players[GameManager.Instance.turn].PlayCard(draggedObject.GetComponent<CardDisplay>().card);
			Destroy(draggedObject);
        }
    }
}
