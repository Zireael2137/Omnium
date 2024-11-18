using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class LeaderDisplay : MonoBehaviour
{

    private Leader leader;
	public RectTransform leaderRect;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI damageText;

    public Image damageField;
    public Image leaderImage;    
    
    public void SetLeader(Leader leader)
    {
        this.leader = leader;
        this.UpdateLeaderDisplay();
    }
    
    public void UpdateLeaderDisplay(){
        this.healthText.text = this.leader.health.ToString();
        if(this.leader.damage > 0){
	    this.damageText.text = this.leader.damage.ToString();
        } else{
            this.damageField.gameObject.SetActive(false);
	}
        if (leader.leaderImage != null)
        {
            leaderImage.sprite = leader.leaderImage;
            leaderImage.gameObject.SetActive(true); 
        }
        else
        {
            leaderImage.gameObject.SetActive(false); 
        }
		leaderRect.anchoredPosition = new Vector2(leader.x,leader.y);
    }
    
}
