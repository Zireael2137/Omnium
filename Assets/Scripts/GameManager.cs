using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<Player> players = new List<Player>();
    public int turn = 0; // 0 - player 1, 1 - player 2
    public bool gameEnded = false;
    public bool cardPlayedInThisTurn = false;
	
    public GameObject unitPrefab;
    public GameObject cardPrefab;
    public GameObject leaderPrefab;

    public Transform playerHand;
    public Transform opponentHand;

    public Transform playerMeleeRow;
    public Transform playerRangedRow;
    public Transform opponentMeleeRow;
    public Transform opponentRangedRow;

    public Transform playerLeaderPanel;
    public Transform opponentLeaderPanel;
	
	public TextMeshProUGUI playerHastePoints;
	public TextMeshProUGUI opponentHastePoints;

    public Image playerTurnMark;
    public Image opponentTurnMark;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        players.Add(new Player());
        players.Add(new Player());

        this.players[1].leader = new Leader(this.players[1],"Gyanna", 30);

        this.players[0].DrawCard();
        this.players[0].DrawCard();
        this.players[0].DrawCard();

        this.players[1].DrawCard();
        this.players[1].DrawCard();
        this.players[1].DrawCard();

        RefreshHandsAndRows();
        RefreshLeaders();

        this.opponentTurnMark.enabled = false;
		DisableCardDragAndDrops(1);
    }

    void Update()
    {
        // Możliwe inne operacje
    }

    public void EndTurn()
    {
		if(this.gameEnded) return;
		this.players[turn].RefreshHastePoints();
        this.turn = turn == 0 ? 1 : 0;
        this.cardPlayedInThisTurn = false;
        this.players[0].ResetUnitsAttacks();
        this.players[1].ResetUnitsAttacks();
        this.players[this.turn].DrawCard();
		RefreshHandsAndRows();
        if (this.turn == 0)
        {
            this.playerTurnMark.enabled = true;
            this.opponentTurnMark.enabled = false;
        }
        else
        {
            this.playerTurnMark.enabled = false;
            this.opponentTurnMark.enabled = true;
        }
		this.players[turn].turnCounter++;
		
		
        
    }

    public void EndGame()
    {
        this.gameEnded = true;
		if(players[0].leader.health <= 0) Debug.Log("Player 2 won");
		else Debug.Log("Player 1 won");
    }

    public void RefreshHandsAndRows()
    {
		if(this.gameEnded) return;
        this.ClearHandsAndRows();
		
        foreach (Card c in this.players[0].hand)
        {
            GameObject newObj = Instantiate(this.cardPrefab, this.playerHand);
            newObj.name = c.cardName;
            CardDisplay cardDisplay = newObj.GetComponent<CardDisplay>();
            if (cardDisplay != null)
            {
                cardDisplay.SetCard(c);
            }
        }
        foreach (Card c in this.players[1].hand)
        {
            GameObject newObj = Instantiate(this.cardPrefab, this.opponentHand);
            newObj.name = c.cardName;
            CardDisplay cardDisplay = newObj.GetComponent<CardDisplay>();
            if (cardDisplay != null)
            {
                cardDisplay.SetCard(c);
            }
        }

        foreach (Unit u in this.players[0].rows[0])
        {
            GameObject newObj = Instantiate(this.unitPrefab, this.playerMeleeRow);
            newObj.name = u.unitName;
            UnitDisplay unitDisplay = newObj.GetComponent<UnitDisplay>();
            if (unitDisplay != null)
            {
                unitDisplay.SetUnit(u);
            }
        }
        foreach (Unit u in this.players[0].rows[1])
        {
            GameObject newObj = Instantiate(this.unitPrefab, this.playerRangedRow);
            newObj.name = u.unitName;
            UnitDisplay unitDisplay = newObj.GetComponent<UnitDisplay>();
            if (unitDisplay != null)
            {
                unitDisplay.SetUnit(u);
            }
        }

        foreach (Unit u in this.players[1].rows[0])
        {
            GameObject newObj = Instantiate(this.unitPrefab, this.opponentMeleeRow);
            newObj.name = u.unitName;
            UnitDisplay unitDisplay = newObj.GetComponent<UnitDisplay>();
            if (unitDisplay != null)
            {
                unitDisplay.SetUnit(u);
            }
        }
        foreach (Unit u in this.players[1].rows[1])
        {
            GameObject newObj = Instantiate(this.unitPrefab, this.opponentRangedRow);
            newObj.name = u.unitName;
            UnitDisplay unitDisplay = newObj.GetComponent<UnitDisplay>();
            if (unitDisplay != null)
            {
                unitDisplay.SetUnit(u);
            }
        }
		this.ResetIsMovable();
		if (this.turn == 0)
        {
			this.DisableCardDragAndDrops(1);
			this.DisableAllUnitsDragAndDrops(1);
        }
        else
        {
			this.DisableCardDragAndDrops(0);
			this.DisableAllUnitsDragAndDrops(0);
        }
		this.RefreshHasteTexts();
		this.DisableAlreadyAttackedUnitsDragAndDrops();
		this.UpdateAllCanAttacks();
		
		this.DestroyDeadUnits();
		this.CheckEndGame();
    }

    public void Attack(Unit attacker, Unit defender)
    {
		if(this.gameEnded) return;
		if(attacker.player == defender.player){
			this.RefreshHandsAndRows();
			return;
		}
		if(defender.type == CardType.Ranged && !attacker.canAttackRanged){
			this.RefreshHandsAndRows();
			return;
		}
		if(defender.constComponents.Contains(ConstComponent.Camouflage)){
			this.RefreshHandsAndRows();
			return;
		}
		attacker.alreadyAttacked = true;
        int attackerDamage = attacker.damage;
        int defenderDamage = defender.damage;
        attacker.takeDamage(defenderDamage);
        defender.takeDamage(attackerDamage);
		
		if(attacker.constComponents.Contains(ConstComponent.Camouflage)) attacker.RemoveConstComponent(ConstComponent.Camouflage);
		
        this.RefreshHandsAndRows();
    }

    public void Attack(Unit attacker, Leader defender)
    {
		if(this.gameEnded) return;
		if(attacker.player == defender.player){
			this.RefreshHandsAndRows();
			return;
		}
		if(!attacker.canAttackLeader){
			this.RefreshHandsAndRows();
			return;
		}
		attacker.alreadyAttacked = true;
        int attackerDamage = attacker.damage;
		if(attacker.type == CardType.Ranged && attackerDamage%2 == 0) attackerDamage = attackerDamage/2;
		else if(attacker.type == CardType.Ranged && attackerDamage%2 != 0) attackerDamage = (attackerDamage/2)+1;
        defender.takeDamage(attackerDamage);
		
		if(attacker.constComponents.Contains(ConstComponent.Camouflage)) attacker.RemoveConstComponent(ConstComponent.Camouflage);
		
        this.RefreshHandsAndRows();
        this.RefreshLeaders();
    }

    public void RefreshLeaders()
    {
		if(this.gameEnded) return;
        this.ClearLeaders();

        GameObject newObj = Instantiate(this.leaderPrefab, this.playerLeaderPanel);
        newObj.name = this.players[0].leader.leaderName;
        LeaderDisplay leaderDisplay = newObj.GetComponent<LeaderDisplay>();
        if (leaderDisplay != null)
        {
            leaderDisplay.SetLeader(this.players[0].leader);
        }
        newObj = Instantiate(this.leaderPrefab, this.opponentLeaderPanel);
        newObj.name = this.players[1].leader.leaderName;
        leaderDisplay = newObj.GetComponent<LeaderDisplay>();
        if (leaderDisplay != null)
        {
            leaderDisplay.SetLeader(this.players[1].leader);
        }
    }

    private void ClearHandsAndRows()
    {
		if(this.gameEnded) return;
        foreach (Transform child in this.playerHand)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in this.opponentHand)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in this.playerMeleeRow)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in this.playerRangedRow)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in this.opponentMeleeRow)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in this.opponentRangedRow)
        {
            Destroy(child.gameObject);
        }
    }

    private void ClearLeaders()
    {
		if(this.gameEnded) return;
        foreach (Transform child in this.playerLeaderPanel)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in this.opponentLeaderPanel)
        {
            Destroy(child.gameObject);
        }
    }
	
	private void DisableCardDragAndDrops(int player){
		if(this.gameEnded) return;
		Transform hand = player == 0 ? this.playerHand : this.opponentHand;
		if (hand != null)
		{
			CanvasGroup[] groups = hand.GetComponentsInChildren<CanvasGroup>();
			foreach (CanvasGroup group in groups)
			{
				group.blocksRaycasts = false;
			}
		}		
	}
	
	private void DisableAllUnitsDragAndDrops(int player)
	{
		if(this.gameEnded) return;
		foreach(List<Unit> row in players[player].rows){
			foreach(Unit u in row){
				u.isMovable = false;
			}
		}
	}
	
	private void DisableAlreadyAttackedUnitsDragAndDrops(){
		if(this.gameEnded) return;
		foreach(List<Unit> row in players[0].rows){
			foreach(Unit u in row){
				if(u.alreadyAttacked || u.turnsToAttack > 0)
					u.isMovable = false;
			}
		}
		foreach(List<Unit> row in players[1].rows){
			foreach(Unit u in row){
				if(u.alreadyAttacked || u.turnsToAttack > 0)
					u.isMovable = false;
			}
		}
	}
	
	private void ResetIsMovable(){
		if(this.gameEnded) return;
		foreach(List<Unit> row in players[0].rows){
			foreach(Unit u in row){
				u.isMovable = true;
			}
		}
		foreach(List<Unit> row in players[1].rows){
			foreach(Unit u in row){
				u.isMovable = true;
			}
		}
	}
	
	private void UpdateAllCanAttacks(){
		if(this.gameEnded) return;
		foreach(Unit u in players[0].rows[0]){
			u.canAttackRanged = false;
			u.canAttackLeader = false;
			if(players[1].rows[0].Count == 0){
				u.canAttackRanged = true;
				if(players[1].rows[1].Count == 0)
					u.canAttackLeader = true;
			}	
		}
		foreach(Unit u in players[1].rows[0]){
			u.canAttackRanged = false;
			u.canAttackLeader = false;
			if(players[0].rows[0].Count == 0){
				u.canAttackRanged = true;
				if(players[0].rows[1].Count == 0)
					u.canAttackLeader = true;
			}
		}
	}
	
	private void DestroyDeadUnits(){
		if(this.gameEnded) return;
		foreach(Transform child in this.playerMeleeRow){
			if(child.GetComponent<UnitDisplay>().unit.health <= 0){
				this.players[0].rows[0].Remove(child.GetComponent<UnitDisplay>().unit);
				Destroy(child.gameObject);
			}
		}
		foreach(Transform child in this.opponentMeleeRow){
			if(child.GetComponent<UnitDisplay>().unit.health <= 0){
				this.players[1].rows[0].Remove(child.GetComponent<UnitDisplay>().unit);
				Destroy(child.gameObject);
			}
		}
		foreach(Transform child in this.playerRangedRow){
			if(child.GetComponent<UnitDisplay>().unit.health <= 0){
				this.players[0].rows[1].Remove(child.GetComponent<UnitDisplay>().unit);
				Destroy(child.gameObject);
			}
		}
		foreach(Transform child in this.opponentRangedRow){
			if(child.GetComponent<UnitDisplay>().unit.health <= 0){
				this.players[1].rows[1].Remove(child.GetComponent<UnitDisplay>().unit);
				Destroy(child.gameObject);
			}
		}
	}
	
	private void CheckEndGame(){
		if(players[0].leader.health <= 0 || players[1].leader.health <= 0) this.EndGame();
	}
	
	private void RefreshHasteTexts(){
		this.playerHastePoints.text = "Haste: "+this.players[0].hastePoints.ToString()+"/"+this.players[0].maxHastePoints.ToString();
		this.opponentHastePoints.text = "Haste: "+this.players[1].hastePoints.ToString()+"/"+this.players[1].maxHastePoints.ToString();;
	}
}
