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
	public Image camouflageImage;

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
		
		if(unit.constComponents.Contains(ConstComponent.Camouflage)) camouflageImage.color = FromRGB(87, 87, 87, 0.8f);
		else camouflageImage.color = FromRGB(87, 87, 87, 0.0f);
    }
	
	
	private Color FromRGB(int r, int g, int b, float a = 1f)
	{
		return new Color(r / 255f, g / 255f, b / 255f, a);
	}
}
