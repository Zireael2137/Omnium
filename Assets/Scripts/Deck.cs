using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
    public bool deckCorrect;
    

    public Deck(){
        this.deckCorrect = false;
    }

    public Deck(List<Card> cards){
        this.cards = cards ?? new List<Card>();
        this.deckCorrect = ValidateDeck();
    }

    public void AddCard(Card card){
        this.cards.Add(card);
    }

    public void RemoveCard(Card card){
        this.cards.Remove(card);
    }

    public void ClearDeck(){
        this.cards.Clear();
    }

    public bool ValidateDeck(){
        if(cards.Count != 40) return false;
        int countSpells = 0;
        int countMelees = 0;
        int countRanged = 0;
        foreach(Card card in this.cards){
            if(card.type == CardType.Spell) countSpells++;
            else if (card.type == CardType.Melee) countMelees++;
            else countRanged++;
        }
        if(countSpells == 5 && countMelees == 25 && countRanged == 10) return true;
        else return false;
    }

    public void ShuffleDeck(){
        System.Random rng = new System.Random();
        int n = this.cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = this.cards[k];
            this.cards[k] = this.cards[n];
            this.cards[n] = value;
        }
    }
}
