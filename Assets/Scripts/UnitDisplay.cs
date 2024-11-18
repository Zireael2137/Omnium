using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UnitDisplay : MonoBehaviour
{

    private Card card;
	
	public RectTransform unitRect;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI damageText;
    //public TextMeshProUGUI useCostText;

    //public Image useCostField;

    public Image cardUnitImage;

    
    public void SetCard(Card card)
    {
        this.card = card;
        this.UpdateCardDisplay();
    }

    public void UpdateCardDisplay(){
        
        this.healthText.text = this.card.health.ToString();
        this.damageText.text = this.card.damage.ToString();
        
        if (card.cardUnitImage != null)
        {
            cardUnitImage.sprite = card.cardUnitImage;
            cardUnitImage.gameObject.SetActive(true); 
        }
        else
        {
            cardUnitImage.gameObject.SetActive(false); 
        }
		unitRect.anchoredPosition = new Vector2(card.unitX,card.unitY);
    }
    
    
}
