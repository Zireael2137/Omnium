using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CardDisplay : MonoBehaviour
{
	public Card card;
	
	public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI damageText;   
    public TextMeshProUGUI descriptionText;

    public Image healthField;
    public Image damageField;
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
            nameText.fontSize = 15;
        }
        this.UpdateCardDisplay();
    }
    public void UpdateCardDisplay(){
        this.nameText.text = this.card.cardName.ToString();
        this.descriptionText.text = this.card.description;
		this.healthText.text = this.card.health.ToString();
		this.damageText.text = this.card.damage.ToString();

        if (card.cardImage != null)
        {
            cardImage.sprite = card.cardImage;
            cardImage.gameObject.SetActive(true); 
        }
        else
        {
            cardImage.gameObject.SetActive(false); 
        }
    }
}
