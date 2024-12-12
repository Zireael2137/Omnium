using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CardType
{
    Melee,
    Ranged
}

public enum CardRarity
{
    Normal,
	Rare,
	Epic,
	Legendary,
	Omnium
}

public enum ConstComponent
{
	Agility,
	Camouflage,
	Kamikaze,
	Devotion
}

public class Card
{
    public int health;
	public int damage;
	public int playCost;
	public string cardName;
	public string description;
	public CardType type;
	public Sprite cardImage;
    public string imageSourcePath;
	public Player player;
	public CardRarity rarity;
	public List<ConstComponent> constComponents = new List<ConstComponent>();
	
	public int baseHealth;
	public int baseDamage;
	public int basePlayCost;
	
	
	
	public Card(Player player, string name, int playCost, int damage, int health, CardType type, CardRarity rarity, List<ConstComponent> constComponents){
		this.player = player;
		this.cardName = name;
		this.playCost = playCost;
		this.damage = damage;
		this.health = health;
		this.type = type;
		this.rarity = rarity;
		this.imageSourcePath = GenerateImageSourcePath();
        this.cardImage = Resources.Load<Sprite>(this.imageSourcePath);
		this.constComponents = constComponents;
		this.baseHealth = health;
		this.baseDamage = damage;
		this.basePlayCost = playCost;
		this.description = GenerateDescription();
	}
	
	private string GenerateImageSourcePath(){
        string sourcePath;
        sourcePath = "Images/Cards/"+this.cardName.Replace(" ", "").ToLower();
        return sourcePath;
    }
	
	public string GenerateDescription(){
		string desc = "";
		foreach(ConstComponent c in this.constComponents){
			desc += c.ToString()+"\n";
		}
		return desc;
	}
	
}
