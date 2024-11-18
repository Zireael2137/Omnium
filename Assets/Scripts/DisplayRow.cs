using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRow : MonoBehaviour
{
    private Row row;
	//public RectTransform unitRect;
	public void SetRow(Row row)
    {
        this.row = row;
        //this.UpdateRowDisplay();
    }
	
	//public void UpdateRowDisplay(){
	//	rowRect.anchoredPosition = new Vector2(row.x,row.y);
	//}
	
}
