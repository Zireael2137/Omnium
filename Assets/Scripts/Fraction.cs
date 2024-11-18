using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraction : MonoBehaviour
{
    public int fractionId;
    public string fractionTag;
    public string fractionName;
    public Leader leader;
    public string description;
    //public HeroPower heroPower;

    public Fraction(){}

    public Fraction(int fractionId, string fractionTag, string fractionName, Leader leader, string description){
        this.fractionId = fractionId;
        this.fractionTag = fractionTag;
        this.fractionName = fractionName;
        this.description = description;
		this.leader = leader;
        
    }

    

}
