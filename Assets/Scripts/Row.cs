using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
    int maxCards = 7;
	
	public float x;
	public float y;
	
	public Row(float x, float y){
		this.x = x;
		this.y = y;
	}
	
	public void addCard(Card card){
		if(this.cards.Count < 7) this.cards.Add(card);
	}
	
	public void removeCard(Card card){
		this.cards.Remove(card);
	}
}
