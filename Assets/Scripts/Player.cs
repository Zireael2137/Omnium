using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player
{
    public Leader leader;
	public List<Card> deck = new List<Card>();
	public List<Card> hand = new List<Card>();
	public List<List<Unit>> rows = new List<List<Unit>>();
	
	public Player(){
		
		this.leader = new Leader(this,"Kangaroo", 30);
		
		this.deck.Add(new Card(this,"Arcymag Imerias", 3, 7, CardType.Ranged));
		this.deck.Add(new Card(this,"Artyleria Wojskowa", 4, 4, CardType.Ranged));
		this.deck.Add(new Card(this,"Kanonierka", 3, 2, CardType.Ranged));
		this.deck.Add(new Card(this,"Narwany Strzelec", 5, 4, CardType.Ranged));
		this.deck.Add(new Card(this,"Strzelec Wyborowy", 1, 5, CardType.Ranged));
		this.deck.Add(new Card(this,"Ukryta Armata", 3, 6, CardType.Ranged));
		this.deck.Add(new Card(this,"Wioskowy Szaman", 3, 3, CardType.Ranged));
		this.deck.Add(new Card(this,"Łucznik Wojskowy", 1, 1, CardType.Ranged));
		
		this.deck.Add(new Card(this,"Doktor Melendez", 5, 6, CardType.Melee));
		this.deck.Add(new Card(this,"Dowódca Broni", 7, 4, CardType.Melee));
		this.deck.Add(new Card(this,"Młody Magik", 2, 3, CardType.Melee));
		this.deck.Add(new Card(this,"Pijany Myśliwy", 1, 7, CardType.Melee));
		this.deck.Add(new Card(this,"Plująca Lama", 3, 5, CardType.Melee));
		this.deck.Add(new Card(this,"Śpiewak Bitewny", 4, 5, CardType.Melee));
		
		this.rows.Add(new List<Unit>());
		this.rows.Add(new List<Unit>());
		
		Shuffle(deck);
		
		
	}
	
	private void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
	
	public void DrawCard(){
		if(this.deck.Count > 0 && this.hand.Count < 8){
			Card tempCard = this.deck[0];
			this.deck.RemoveAt(0);
			this.hand.Add(tempCard);
		}
	}
	
	public void ResetUnitsAttacks(){
		foreach(Unit u in this.rows[0]){
			u.alreadyAttacked = false;
			u.turnsToAttack = 0;
		}
		foreach(Unit u in this.rows[1]){
			u.alreadyAttacked = false;
			u.turnsToAttack = 0;
		}
	}
	
	public void PlayCard(Card card){
		if(card.type == CardType.Melee && this.rows[0].Count < 7){
			this.rows[0].Add(new Unit(card));
			this.hand.Remove(card);
		}
		else if(card.type == CardType.Ranged && this.rows[1].Count < 7){
			this.rows[1].Add(new Unit(card));
			this.hand.Remove(card);
		}
		GameManager.Instance.RefreshHandsAndRows();
		GameManager.Instance.cardPlayedInThisTurn = true;
	}
	public void PlayCard(int cardIndex){
		if(this.hand[cardIndex].type == CardType.Melee && this.rows[0].Count < 7){
			this.rows[0].Add(new Unit(this.hand[cardIndex]));
			this.hand.RemoveAt(cardIndex);
		}
		else if(this.hand[cardIndex].type == CardType.Ranged && this.rows[1].Count < 7){
			this.rows[1].Add(new Unit(this.hand[cardIndex]));
			this.hand.RemoveAt(cardIndex);
		}
		GameManager.Instance.RefreshHandsAndRows();
		GameManager.Instance.cardPlayedInThisTurn = true;
	}
	
	
	
	
}
