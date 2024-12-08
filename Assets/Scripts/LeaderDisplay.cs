using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class LeaderDisplay : MonoBehaviour
{
    public Leader leader;
	
    public TextMeshProUGUI healthText;
    public Image leaderImage;    
    
    public void SetLeader(Leader leader)
    {
        this.leader = leader;
        this.UpdateLeaderDisplay();
    }
    
    public void UpdateLeaderDisplay(){
        this.healthText.text = this.leader.health.ToString();
        if (leader.leaderImage != null)
        {
            leaderImage.sprite = leader.leaderImage;
            leaderImage.gameObject.SetActive(true); 
        }
        else
        {
            leaderImage.gameObject.SetActive(false); 
        }
    }
}
