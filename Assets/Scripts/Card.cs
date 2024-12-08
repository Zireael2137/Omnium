using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CardType
{
    Melee,
    Ranged
}

public class Card
{
    public int health;
	public int damage;
	public string cardName;
	public string description = "";
	public CardType type;
	public Sprite cardImage;
    public string imageSourcePath;
	public Player player;
	
	public Card(Player player, string name, int damage, int health, CardType type){
		this.player = player;
		this.cardName = name;
		this.damage = damage;
		this.health = health;
		this.type = type;
		this.imageSourcePath = GenerateImageSourcePath();
        this.cardImage = Resources.Load<Sprite>(this.imageSourcePath);
	}
	
	private string GenerateImageSourcePath(){
        string sourcePath;
        sourcePath = "Images/Cards/"+this.cardName.Replace(" ", "").ToLower();
        return sourcePath;
    }
}
