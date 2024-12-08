using UnityEngine;
using UnityEngine.EventSystems;

public class UnitDropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = eventData.pointerDrag;
		GameObject droppedOn = eventData.pointerCurrentRaycast.gameObject;
		GameObject target = droppedOn.transform.parent?.parent?.gameObject;
        if (draggedObject != null && draggedObject.GetComponent<UnitDisplay>() != null)
        {
			if(draggedObject.GetComponent<UnitDisplay>() != null && draggedObject.GetComponent<UnitDisplay>().unit.isMovable == false) return;
			if(target.GetComponent<LeaderDisplay>() != null){
				GameManager.Instance.Attack(draggedObject.GetComponent<UnitDisplay>().unit, target.GetComponent<LeaderDisplay>().leader);
			}
			else if(target.GetComponent<UnitDisplay>() != null){
				GameManager.Instance.Attack(draggedObject.GetComponent<UnitDisplay>().unit, target.GetComponent<UnitDisplay>().unit);
			}
        }
    }
}
