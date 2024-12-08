using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UnitDisplay : MonoBehaviour
{
	public Unit unit;
	
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI damageText;

    public Image unitImage;
	
    public void SetUnit(Unit unit)
    {
        this.unit = unit;
        this.UpdateUnitDisplay();
    }

    public void UpdateUnitDisplay(){
        
        this.healthText.text = this.unit.health.ToString();
        this.damageText.text = this.unit.damage.ToString();
        
        if (unit.unitImage != null)
        {
            unitImage.sprite = unit.unitImage;
            unitImage.gameObject.SetActive(true); 
        }
        else
        {
            unitImage.gameObject.SetActive(false); 
        }
    }
}
