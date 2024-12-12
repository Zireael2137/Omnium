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
	public int hastePoints;
	public int maxHastePoints;
	public int turnCounter = 1;
	
	public Player(){
		
		this.leader = new Leader(this,"Kangaroo", 30);
		
		this.CreateAndAddCards();
		
		this.rows.Add(new List<Unit>());
		this.rows.Add(new List<Unit>());
		
		this.hastePoints = 3;
		this.maxHastePoints = 3;
		
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
		if(card.playCost <= this.hastePoints){
			if(card.type == CardType.Melee && this.rows[0].Count < 7){
				this.rows[0].Add(new Unit(card));
				this.hastePoints -= card.playCost;
				this.hand.Remove(card);
			}
			else if(card.type == CardType.Ranged && this.rows[1].Count < 7){
				this.rows[1].Add(new Unit(card));
				this.hastePoints -= card.playCost;
				this.hand.Remove(card);
			}
			GameManager.Instance.RefreshHandsAndRows();
			GameManager.Instance.cardPlayedInThisTurn = true;
		}
		else{
			GameManager.Instance.RefreshHandsAndRows();
		}
	}
	public void PlayCard(int cardIndex){
		if(this.hand[cardIndex].playCost <= this.hastePoints){
			if(this.hand[cardIndex].type == CardType.Melee && this.rows[0].Count < 7){
				this.rows[0].Add(new Unit(this.hand[cardIndex]));
				this.hastePoints -= this.hand[cardIndex].playCost;
				this.hand.RemoveAt(cardIndex);
			}
			else if(this.hand[cardIndex].type == CardType.Ranged && this.rows[1].Count < 7){
				this.rows[1].Add(new Unit(this.hand[cardIndex]));
				this.hastePoints -= this.hand[cardIndex].playCost;
				this.hand.RemoveAt(cardIndex);
			}
			GameManager.Instance.RefreshHandsAndRows();
			GameManager.Instance.cardPlayedInThisTurn = true;
		}
		else{
			GameManager.Instance.RefreshHandsAndRows();
		}
	}
	
	public void RefreshHastePoints(){
		if(this.maxHastePoints < 15) this.maxHastePoints += 2;
		this.hastePoints = this.maxHastePoints;
	}
	
	private void CreateAndAddCards(){
		
		/*
		this.deck.Add(new Card(this,"Łaska Uzdrowienia", 2, 0, 0, CardType.Spell, CardRarity.Normal, null));
		this.deck.Add(new Card(this,"Brawura", 3, 0, 0, CardType.Spell, CardRarity.Normal, null));
		this.deck.Add(new Card(this,"Ślepy Płomień", 4, 0, 0, CardType.Spell, CardRarity.Rare, null));
		this.deck.Add(new Card(this,"Wzmocnienie", 6, 0, 0, CardType.Spell, CardRarity.Rare, null));
		this.deck.Add(new Card(this,"Potępienie", 8, 0, 0, CardType.Spell, CardRarity.Epic, null));
		*/
		
		this.deck.Add(new Card(this,"Łucznik Wojskowy", 1, 2, 1, CardType.Melee, CardRarity.Normal, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Młody Magik", 1, 3, 1, CardType.Ranged, CardRarity.Normal, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Narwany Strzelec", 1, 2, 1, CardType.Ranged, CardRarity.Normal, new List<ConstComponent>{ConstComponent.Agility}));
		this.deck.Add(new Card(this,"Doktor Melendez", 2, 1, 3, CardType.Ranged, CardRarity.Normal, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Plująca Lama", 2, 3, 3, CardType.Ranged, CardRarity.Normal, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Pijany Myśliwy", 3, 5, 2, CardType.Ranged, CardRarity.Normal, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Dowódca Broni", 4, 1, 3, CardType.Ranged, CardRarity.Rare, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Arcymag Imerias", 3, 2, 6, CardType.Ranged, CardRarity.Rare, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Wioskowy Szaman", 4, 1, 5, CardType.Ranged, CardRarity.Rare, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Strzelec Wyborowy", 4, 2, 3, CardType.Ranged, CardRarity.Rare, new List<ConstComponent>{}));
		//this.deck.Add(new Card(this,"Procarz", 5, 5, 5, CardType.Ranged, CardRarity.Rare, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Ukryta Armata", 5, 4, 3, CardType.Ranged, CardRarity.Rare, new List<ConstComponent>{ConstComponent.Camouflage}));
		this.deck.Add(new Card(this,"Kanonierka", 4, 2, 4, CardType.Ranged, CardRarity.Epic, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Artyleria Wojskowa", 6, 4, 5, CardType.Ranged, CardRarity.Epic, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Śpiewak Bitewny", 8, 3, 3, CardType.Ranged, CardRarity.Epic, new List<ConstComponent>{}));

		/*
		this.deck.Add(new Card(this,"Kapłan Wiernych", 1, 1, 2, CardType.Melee, CardRarity.Normal, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Bot Obronny", 1, 1, 6, CardType.Melee, CardRarity.Normal, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Szeregowy", 1, 1, 1, CardType.Melee, CardRarity.Normal, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Pies Bojowy", 2, 2, 2, CardType.Melee, CardRarity.Normal, new List<ConstComponent>{ConstComponent.Agility}));
		this.deck.Add(new Card(this,"Kalmar", 2, 2, 4, CardType.Melee, CardRarity.Normal, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Samozwańczy Tarczownik", 3, 2, 6, CardType.Melee, CardRarity.Normal, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Nożownik", 3, 4, 1, CardType.Melee, CardRarity.Normal, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Wojownik Dusz", 4, 3, 4, CardType.Melee, CardRarity.Normal, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Drzewiec Nadziei", 4, 4, 5, CardType.Melee, CardRarity.Normal, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Starszy Kapłan", 3, 4, 4, CardType.Melee, CardRarity.Rare, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Wyszkolona Skrytobójczyni", 3, 4, 2, CardType.Melee, CardRarity.Rare, new List<ConstComponent>{ConstComponent.Camouflage}));
		this.deck.Add(new Card(this,"Niezdecydowany Wojownik", 4, 3, 3, CardType.Melee, CardRarity.Rare, new List<ConstComponent>{ConstComponent.Camouflage, ConstComponent.Agility}));
		this.deck.Add(new Card(this,"Wielki Wąż", 4, 5, 5, CardType.Melee, CardRarity.Rare, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Prorok Cieni", 5, 10, 7, CardType.Melee, CardRarity.Rare, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Bibliotekarka", 5, 1, 2, CardType.Melee, CardRarity.Rare, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Lokalny Żebrak", 6, 2, 4, CardType.Melee, CardRarity.Rare, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Mnich Zakonu", 5, 3, 7, CardType.Melee, CardRarity.Epic, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Skalny Golem", 6, 8, 8, CardType.Melee, CardRarity.Epic, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Poszukiwacz Skarbów", 7, 4, 4, CardType.Melee, CardRarity.Epic, new List<ConstComponent>{}));
		this.deck.Add(new Card(this,"Śmiercionośca", 8, 4, 6, CardType.Melee, CardRarity.Legendary, new List<ConstComponent>{}));
		
		*/
		
	}
	
	
}
