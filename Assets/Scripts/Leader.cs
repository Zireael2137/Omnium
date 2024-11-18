using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader
{
	public string leaderName;
	public Sprite leaderImage;
    public string leaderImageSourcePath;
	public int health = 30;
	public int damage = 0;
	public string fractionName;
	public float x;
	public float y;
    
	public Leader(string leaderName, string fractionName){
		this.leaderName = leaderName;
		this.fractionName = fractionName;
		this.leaderImageSourcePath = GenerateLeaderImageSourcePath();
		//this.leaderImageSourcePath = "Images/Leaders/Kirian'Taal/sho'gun";
        this.leaderImage = Resources.Load<Sprite>(this.leaderImageSourcePath);
		this.x = 0;
		this.y = 0;
	}
	
	private string GenerateLeaderImageSourcePath(){
        string sourcePath = "Images/Leaders/"+this.fractionName+"/"+this.leaderName;
        return sourcePath;
    }
	
	public void SetPosition(float x, float y){
		this.x = x;
		this.y = y;
	}
}
