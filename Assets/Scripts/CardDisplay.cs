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
	public TextMeshProUGUI playCostText;

    public Image healthField;
    public Image damageField;
    public Image cardImage;
	public Image descriptionField;
	
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
		this.playCostText.text = this.card.playCost.ToString();

        if (card.cardImage != null)
        {
            cardImage.sprite = card.cardImage;
            cardImage.gameObject.SetActive(true); 
        }
        else
        {
            cardImage.gameObject.SetActive(false); 
        }
		
		if(card.rarity == CardRarity.Normal) this.descriptionField.color = FromRGB(60, 66, 82);
		else if(card.rarity == CardRarity.Rare) this.descriptionField.color = FromRGB(39, 73, 190);
		else if(card.rarity == CardRarity.Epic) this.descriptionField.color = FromRGB(102, 3, 69);
		else if(card.rarity == CardRarity.Legendary) this.descriptionField.color = FromRGB(205, 105, 40);
		else this.descriptionField.color = FromRGB(118, 0, 5);
    }
	
	private Color FromRGB(int r, int g, int b, float a = 1f)
	{
		return new Color(r / 255f, g / 255f, b / 255f, a);
	}
}
