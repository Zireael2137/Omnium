using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDatabase : MonoBehaviour
{
    public static List<Fraction> fractionList = new List<Fraction>();
    public static List<Card> cardList = new List<Card>();

	//public Player player1 = new Player();
	//public Player player2 = new Player();

    public GameObject cardPrefab;
    public Transform cardParent;
	
	public GameObject leaderPrefab;
    public Transform leaderParent;
	
	public GameObject unitPrefab;
    public Transform unitParent;
	
	//public GameObject rowPrefab;
	//public GameObject rowParent;

    void Start(){
        this.CreateFractions();
        this.CreateCards();
        //DisplayCard(8);
        DisplayCard(7,100,100);
        //DisplayCard(32);
		DisplayLeader(1,-750,400);
		DisplayLeader(2,-750,-380);
		DisplayUnit(8,300,100);
		DisplayUnit(7,-300,100);
		
    }
    void CreateFractions(){
        fractionList.Add(new Fraction(0, "ntr", "Neutral", null, ""));
        fractionList.Add(new Fraction(1, "krt", "Kirian'Taal", new Leader("Sho'Gun","Kirian'Taal"), "Kirian'Taal desc"));
        fractionList.Add(new Fraction(2, "lrn", "Lyann Rinn", new Leader("Gyanna","Lyann Rinn"), "Lyann Rinn desc"));
        //fractionList.Add(new Fraction(3, "lna","Lunea","","Lunea desc"));
        //fractionList.Add(new Fraction(4, "stl","Sin'Tilia","","Sin'Tilia desc"));
        //fractionList.Add(new Fraction(5, "snb","Snobarne","Ulvekonge","Snobarne desc"));
        //fractionList.Add(new Fraction(6, "wtr","Western Rose","","Western Rose desc"));
    }

    void CreateCards(){
        // NEUTRAL -----------------------------------------------------------------------------------------------------------------------------------------
        cardList.Add(new Card(1, 0, CardRarity.Basic, "Łaska Uzdrowienia", 0, 0, 2, 0, CardType.Spell, null, null));
        cardList.Add(new Card(2, 0, CardRarity.Basic, "Brawura", 0, 0, 3, 0, CardType.Spell, null, null));
        cardList.Add(new Card(3, 0, CardRarity.Rare, "Ślepy Płomień", 0, 0, 4, 0, CardType.Spell, null, null));
        cardList.Add(new Card(4, 0, CardRarity.Rare, "Wzmocnienie", 0, 0, 6, 0, CardType.Spell, null, null));
        cardList.Add(new Card(5, 0, CardRarity.Epic, "Potępienie", 0, 0, 8, 0, CardType.Spell, null, null));

        cardList.Add(new Card(6, 0, CardRarity.Basic, "Łucznik Wojskowy", 2, 1, 1, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(7, 0, CardRarity.Basic, "Młody Magik", 3, 1, 1, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(8, 0, CardRarity.Basic, "Narwany Strzelec", 2, 1, 1, 0, CardType.Ranged, new List<ConstComponent> {ConstComponent.Agility}, null));
        cardList.Add(new Card(9, 0, CardRarity.Basic, "Doktor Melendez", 1, 3, 2, 2, CardType.Ranged, null, null));
        cardList.Add(new Card(10, 0, CardRarity.Basic, "Plująca Lama", 3, 3, 2, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(11, 0, CardRarity.Basic, "Pijany Myśliwy", 5, 2, 3, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(12, 0, CardRarity.Rare, "Dowódca Broni", 1, 3, 4, 1, CardType.Ranged, null, null));
        cardList.Add(new Card(13, 0, CardRarity.Rare, "Arcymag Imerias", 2, 6, 3, 2, CardType.Ranged, null, null));
        cardList.Add(new Card(14, 0, CardRarity.Rare, "Wioskowy Szaman", 1, 5, 4, 2, CardType.Ranged, null, null));
        cardList.Add(new Card(15, 0, CardRarity.Rare, "Strzelec Wyborowy", 2, 3, 4, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(16, 0, CardRarity.Rare, "Procarz", 5, 5, 5, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(17, 0, CardRarity.Rare, "Ukryta Armata", 4, 3, 5, 0, CardType.Ranged, new List<ConstComponent> {ConstComponent.Camouflage}, null));
        cardList.Add(new Card(18, 0, CardRarity.Epic, "Kanonierka", 2, 4, 4, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(19, 0, CardRarity.Epic, "Artyleria Wojskowa", 4, 5, 6, 2, CardType.Ranged, null, null));
        cardList.Add(new Card(20, 0, CardRarity.Epic, "Śpiewak Bitewny", 3, 3, 8, 3, CardType.Ranged, null, null));

        cardList.Add(new Card(21, 0, CardRarity.Basic, "Kapłan Wiernych", 1, 2, 1, 1, CardType.Melee, null, null));
        cardList.Add(new Card(22, 0, CardRarity.Basic, "Bot Obronny", 1, 6, 1, 0, CardType.Melee, null, null));
        cardList.Add(new Card(23, 0, CardRarity.Basic, "Szeregowy", 1, 1, 1, 0, CardType.Melee, null, null));
        cardList.Add(new Card(24, 0, CardRarity.Basic, "Pies Bojowy", 2, 2, 2, 0, CardType.Melee, new List<ConstComponent> {ConstComponent.Agility}, null));
        cardList.Add(new Card(25, 0, CardRarity.Basic, "Kalmar", 2, 4, 2, 0, CardType.Melee, null, null));
        cardList.Add(new Card(26, 0, CardRarity.Basic, "Samozwańczy Tarczownik", 2, 6, 3, 0, CardType.Melee, null, null));
        cardList.Add(new Card(27, 0, CardRarity.Basic, "Nożownik", 4, 1, 3, 0, CardType.Melee, null, null));
        cardList.Add(new Card(28, 0, CardRarity.Basic, "Wojownik Dusz", 3, 4, 4, 0, CardType.Melee, null, null));
        cardList.Add(new Card(29, 0, CardRarity.Basic, "Drzewiec Nadziei", 4, 5, 4, 0, CardType.Melee, null, null));
        cardList.Add(new Card(30, 0, CardRarity.Rare, "Starszy Kapłan", 4, 4, 3, 3, CardType.Melee, null, null));
        cardList.Add(new Card(31, 0, CardRarity.Rare, "Wyszkolona Skrytobójczyni", 4, 2, 3, 0, CardType.Melee, new List<ConstComponent> {ConstComponent.Camouflage}, null));
        cardList.Add(new Card(32, 0, CardRarity.Rare, "Niezdecydowany Wojownik", 3, 3, 4, 0, CardType.Melee, new List<ConstComponent> {ConstComponent.Agility, ConstComponent.Camouflage}, null));
        cardList.Add(new Card(33, 0, CardRarity.Rare, "Wielki Wąż", 5, 5, 4, 0, CardType.Melee, null, null));
        cardList.Add(new Card(34, 0, CardRarity.Rare, "Prorok Cieni", 10, 7, 5, 0, CardType.Melee, null, null));
        cardList.Add(new Card(35, 0, CardRarity.Rare, "Bibliotekarka", 1, 2, 5, 2, CardType.Melee, null, null));
        cardList.Add(new Card(36, 0, CardRarity.Rare, "Lokalny Żebrak", 2, 4, 6, 0, CardType.Melee, null, null));
        cardList.Add(new Card(37, 0, CardRarity.Epic, "Mnich Zakonu", 3, 7, 5, 4, CardType.Melee, null, null));
        cardList.Add(new Card(38, 0, CardRarity.Epic, "Skalny Golem", 8, 8, 6, 0, CardType.Melee, null, null));
        cardList.Add(new Card(39, 0, CardRarity.Epic, "Poszukiwacz Skarbów", 4, 4, 7, 5, CardType.Melee, null, null));
        cardList.Add(new Card(40, 0, CardRarity.Legendary, "Śmiercionośca", 4, 6, 8, 0, CardType.Melee, null, null));

        // KIRIAN'TAAL -------------------------------------------------------------------------------------------------------------------------------------
        cardList.Add(new Card(41, 1, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Spell, null, null));
        cardList.Add(new Card(42, 1, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Spell, null, null));
        cardList.Add(new Card(43, 1, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Spell, null, null));
        cardList.Add(new Card(44, 1, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Spell, null, null));
        cardList.Add(new Card(45, 1, CardRarity.Epic, "", 0, 0, 0, 0, CardType.Spell, null, null));

        cardList.Add(new Card(46, 1, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(47, 1, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(48, 1, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(49, 1, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(50, 1, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(51, 1, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(52, 1, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(53, 1, CardRarity.Epic, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(54, 1, CardRarity.Epic, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(55, 1, CardRarity.Legendary, "", 0, 0, 0, 0, CardType.Ranged, null, null));

        cardList.Add(new Card(56, 1, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(57, 1, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(58, 1, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(59, 1, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(60, 1, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(61, 1, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(62, 1, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(63, 1, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(64, 1, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(65, 1, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(66, 1, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(67, 1, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(68, 1, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(69, 1, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(70, 1, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(71, 1, CardRarity.Epic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(72, 1, CardRarity.Epic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(73, 1, CardRarity.Epic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(74, 1, CardRarity.Legendary, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(75, 1, CardRarity.Omnium, "", 0, 0, 0, 0, CardType.Melee, null, null));

        
        // LYANN RINN --------------------------------------------------------------------------------------------------------------------------------------
        cardList.Add(new Card(76, 2, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Spell, null, null));
        cardList.Add(new Card(77, 2, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Spell, null, null));
        cardList.Add(new Card(78, 2, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Spell, null, null));
        cardList.Add(new Card(79, 2, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Spell, null, null));
        cardList.Add(new Card(80, 2, CardRarity.Epic, "", 0, 0, 0, 0, CardType.Spell, null, null));

        cardList.Add(new Card(81, 2, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(82, 2, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(83, 2, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(84, 2, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(85, 2, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(86, 2, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(87, 2, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(88, 2, CardRarity.Epic, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(89, 2, CardRarity.Epic, "", 0, 0, 0, 0, CardType.Ranged, null, null));
        cardList.Add(new Card(90, 2, CardRarity.Legendary, "", 0, 0, 0, 0, CardType.Ranged, null, null));

        cardList.Add(new Card(91, 2, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(92, 2, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(93, 2, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(94, 2, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(95, 2, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(96, 2, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(97, 2, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(98, 2, CardRarity.Basic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(99, 2, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(100, 2, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(101, 2, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(102, 2, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(103, 2, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(104, 2, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(105, 2, CardRarity.Rare, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(106, 2, CardRarity.Epic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(107, 2, CardRarity.Epic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(108, 2, CardRarity.Epic, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(109, 2, CardRarity.Legendary, "", 0, 0, 0, 0, CardType.Melee, null, null));
        cardList.Add(new Card(110, 2, CardRarity.Omnium, "", 0, 0, 0, 0, CardType.Melee, null, null));
    }

    private void DisplayCard(int id, float x, float y){
        GameObject newCard = Instantiate(cardPrefab, cardParent);
        CardDisplay cardDisplay = newCard.GetComponent<CardDisplay>();
        if (cardDisplay != null)
            {
				GameDatabase.cardList[id-1].SetPosition(x, y);
                cardDisplay.SetCard(GameDatabase.cardList[id-1]);
            }
    }
	private void DisplayLeader(int fractionId, float x, float y){
        GameObject newLeader = Instantiate(leaderPrefab, leaderParent);
        LeaderDisplay leaderDisplay = newLeader.GetComponent<LeaderDisplay>();
        if (leaderDisplay != null)
            {
				GameDatabase.fractionList[fractionId].leader.SetPosition(x,y);
                leaderDisplay.SetLeader(GameDatabase.fractionList[fractionId].leader);
            }
    }
	private void DisplayUnit(int id, float x, float y){
        GameObject newUnit = Instantiate(unitPrefab, unitParent);
        UnitDisplay unitDisplay = newUnit.GetComponent<UnitDisplay>();
        if (unitDisplay != null)
            {
				GameDatabase.cardList[id-1].SetUnitPosition(x, y);
                unitDisplay.SetCard(GameDatabase.cardList[id-1]);
            }
    }
	
}
