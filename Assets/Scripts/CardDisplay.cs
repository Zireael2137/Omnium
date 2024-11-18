using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardDisplay : MonoBehaviour
{

    private Card card;
	
	public RectTransform cardRect;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI playCostText;
    public TextMeshProUGUI useCostText;
    public TextMeshProUGUI descriptionText;

    public Image healthField;
    public Image damageField;
    public Image useCostField;

    public Image cardImage;

    
    public void SetCard(Card card)
    {
        this.card = card;
        if (card.cardName.Length > 14)
        {
            nameText.fontSize = 12;
        }
        else
        {
            nameText.fontSize = 18;
        }
        this.UpdateCardDisplay();
    }

    public void UpdateCardDisplay(){
        this.nameText.text = this.card.cardName.ToString();
        this.playCostText.text = this.card.playCost.ToString();
        this.descriptionText.text = this.card.description;

        if(this.card.type != CardType.Spell){
            this.healthText.text = this.card.health.ToString();
            this.damageText.text = this.card.damage.ToString();
        } else{
            this.damageField.gameObject.SetActive(false);
            this.healthField.gameObject.SetActive(false);
        }
        if(this.card.useCost > 0){
            this.useCostText.text = this.card.useCost.ToString();
        } else {
            this.useCostField.gameObject.SetActive(false);
        }

        if (card.cardImage != null)
        {
            cardImage.sprite = card.cardImage;
            cardImage.gameObject.SetActive(true); 
        }
        else
        {
            cardImage.gameObject.SetActive(false); 
        }
		
		cardRect.anchoredPosition = new Vector2(card.x,card.y);
    }
	
    
    
}
