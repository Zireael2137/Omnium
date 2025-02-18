using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Unit
{
    public int health;
	public int damage;
	public Sprite unitImage;
	public int turnsToAttack = 1;
	public bool alreadyAttacked = false;
	public string unitName;
	public CardType type;
	public bool canAttackLeader = true;
	public bool canAttackRanged = true;
	public bool isMovable = true;
	public List<ConstComponent> constComponents = new List<ConstComponent>();
	
	public Player player;
	
	public Unit(Card card){
		this.health = card.health;
		this.damage = card.damage;
		this.unitImage = card.cardImage;
		this.unitName = card.cardName;
		this.type = card.type;
		this.player = card.player;
		this.constComponents = card.constComponents;
		if(this.constComponents.Contains(ConstComponent.Agility)) this.turnsToAttack = 0;
	}
	
	public void takeDamage(int damage){
		if(damage >= this.health) this.health = 0;
		else this.health -= damage;
	}
	
	public void RemoveConstComponent(ConstComponent component){
		this.constComponents.Remove(component);
	}

}
