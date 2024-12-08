using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader
{
    public string leaderName;
	public int health;
	public Sprite leaderImage;
	public string imageSourcePath;
	
	public Player player;
	
	public Leader(Player player, string name, int health){
		this.leaderName = name;
		this.health = health;
		this.imageSourcePath = GenerateImageSourcePath();
        this.leaderImage = Resources.Load<Sprite>(this.imageSourcePath);
		this.player = player;
	}
	
	private string GenerateImageSourcePath(){
        string sourcePath;
        sourcePath = "Images/Leaders/"+this.leaderName.Replace(" ", "").ToLower();
        return sourcePath;
    }
	
	public void takeDamage(int damage){
		if(damage >= this.health) this.health = 0;
		else this.health -= damage;
	}
}
