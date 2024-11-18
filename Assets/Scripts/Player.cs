using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerId;
    public string playerName;

    public Fraction fraction;
    public Deck deck;
    public Row meleeRow;
    public Row rangedRow;
    public Hand hand;

    public int baseHealth;
    public int health;
    public int baseHaste;
    public int haste;

    public bool cardPlayed;
    public bool heroPowerUsed;    
	
	public Player(){
		this.meleeRow = new Row(0,0);
		this.rangedRow = new Row(0,0);
	}

}
