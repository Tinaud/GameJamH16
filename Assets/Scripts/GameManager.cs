using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	// Condition de Start
	private enum Difficulty {Easy, Medium, Hard} ;
	Difficulty difficulte; 

	private enum Gender {Boy, Girl};
	Gender olderSex, youngerSex;

	private enum Rooms {Corridor=0, ToiletsM=7, ToiletsW=8, DirectorOffice=9, ProfRoom=10, Library=11, Locker=12, Gym=13, Courtyard=14, Cafeteria=15, Kitchen=16};

	private enum Classes {History=1, Geography=2, French=3, Maths=4, English=5, Music=6};

	private int nbAnswersMax;
	private int nbEnnemiesMax;

	private int nbAnswersCollected;

	//SchoolMap map;

	private List<int> Areas;

	Controller oldBrother;
	ControllerYoung youngBrother;



	// Use this for initialization
	void Start () {
		Areas = new List<int> ();
		// Par défaut pour le moment, flafla
		difficulte = Difficulty.Easy;
		olderSex = Gender.Boy;
		youngerSex = Gender.Boy;
		choiceDifficulty();
		youngBrother = GetComponentInChildren<ControllerYoung>();
		oldBrother = GetComponentInChildren<Controller>();
		InitializeMap ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void choiceDifficulty() {
		switch (difficulte) {
			case Difficulty.Easy: 
				nbAnswersMax = 9;
				break;

			case Difficulty.Medium:
				nbAnswersMax = 6;
				break;

			case Difficulty.Hard:
				nbAnswersMax = 15;
				break;
		}
	}

	void placeAnswers() {
		System.Random rnd = new System.Random();
		for (int i = 0; i < nbAnswersMax; i++) {
			int r = rnd.Next (Areas.Count);
			Debug.Log ("Area " + r + " get an answer !");
			Areas.RemoveAt(r);
		}
	}

	void InitializeMap() {
		for (int i = 1; i <= 16; i++) {Areas.Add (i);}
		placeAnswers ();
	}

	public void setEasy() {
		difficulte = Difficulty.Easy;
	}

	public void setMedium() {
		difficulte = Difficulty.Medium;
	}

	public void setHard() {
		difficulte = Difficulty.Hard;
	}
}
