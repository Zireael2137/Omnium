using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Card
{
    public int cardId;
    public string cardName;
    public int health;
    public int baseHealth;
    public int damage;
    public int baseDamage;
    public int playCost;
    public int basePlayCost;
    public int useCost;
    public int baseUseCost;
    public string description = "";
    public List<ConstComponent> constComponents;
    public List<ModComponent> modComponents;
    public CardType type;
    public int turnsToAttack;
    public bool alreadyAttacked;
    public bool powerUsed;
    public int fractionId;
    public CardRarity rarity;
    public Sprite cardImage;
    public string imageSourcePath;
	public string imageUnitSourcePath;
	public Sprite cardUnitImage;
	
	public float x;
	public float y;
	public float unitX;
	public float unitY;

    public Card(){}

    public Card(int cardId, int fractionId, CardRarity rarity, string cardName, int baseDamage, int baseHealth, int basePlayCost, int baseUseCost, CardType type, List<ConstComponent> constComponents, List<ModComponent> modComponents){
        
        this.cardId = cardId;
        this.fractionId = fractionId;
        this.rarity = rarity;
        this.cardName = cardName;
        this.baseHealth = baseHealth;
        this.health = baseHealth;
        this.damage = baseDamage;
        this.baseDamage = baseDamage;
        this.basePlayCost = basePlayCost;
        this.playCost = basePlayCost;
        this.baseUseCost = baseUseCost;
        this.useCost = baseUseCost;
        this.type = type;
		this.x = 0;
		this.y = 0;
		this.x = 0;
		this.y = 0;

        this.constComponents = constComponents ?? new List<ConstComponent>();
        this.modComponents = modComponents ?? new List<ModComponent>();

        this.alreadyAttacked = false;
        this.powerUsed = false;
        this.turnsToAttack = 1;

        this.imageSourcePath = GenerateImageSourcePath();
        this.cardImage = Resources.Load<Sprite>(this.imageSourcePath);
		
		this.imageUnitSourcePath = GenerateImageSourcePath();
        this.cardUnitImage = Resources.Load<Sprite>(this.imageUnitSourcePath);

        this.description = GenerateDescription();

    }

    private string GenerateImageSourcePath(){
        string sourcePath;
        if(this.cardName == "Młody Magik")
            sourcePath = "Images/Cards/"+GameDatabase.fractionList[this.fractionId].fractionName+"/"+this.cardName.Replace(" ", "").ToLower();
        else 
            sourcePath = "Images/Cards/Neutral/default";
        return sourcePath;
    }

	


    private string GenerateDescription(){
        string desc = "";
        if(this.constComponents.Count == 0 && this.modComponents.Count == 0) return "";
        if (this.constComponents.Count != 0){
            if(this.constComponents.Contains(ConstComponent.Agility)) desc+="Zwinność\n";
            if(this.constComponents.Contains(ConstComponent.Camouflage)) desc+="Kamuflaż\n";
            if(this.constComponents.Contains(ConstComponent.Devotion)) desc+="Oddanie\n";
            if(this.constComponents.Contains(ConstComponent.Kamikaze)) desc+="Kamikaze\n";
        }
        return desc;
    }
	
	public void SetPosition(float x, float y){
		this.x = x;
		this.y = y;
	}
	public void SetUnitPosition(float x, float y){
		this.unitX = x;
		this.unitY = y;
	}
}
