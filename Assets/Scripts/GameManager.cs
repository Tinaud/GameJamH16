using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance = null;	

	// Condition de Start
	public enum Difficulty {Easy, Medium, Hard} ;
	Difficulty difficulte;
	public Difficulty Difficulte {
		get {
			return difficulte;
		}
	}

 

	public enum Gender {Boy, Girl};
	Gender olderSex, youngerSex;

	private int nbAnswersMax;
	private int nbEnnemiesMax;

	public int AnswerCollected = 0;
	private MapEditor mapScript;
	private List<Enemy> enemies;
	private List<int> Areas;

	private Player player;


	// Use this for initialization
	void Awake () {
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);	

		DontDestroyOnLoad(gameObject);

		Areas = new List<int> ();
		enemies = new List<Enemy>();
		mapScript = GetComponent<MapEditor>();

		// Par défaut pour le moment, flafla
		olderSex = Gender.Boy;
		youngerSex = Gender.Boy;
		player = GetComponentInChildren<Player> ();
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
			int r = rnd.Next (1, Areas.Count);
			Debug.Log ("Area " + r + " get an answer !");
			Areas.RemoveAt(r);
		}
	}

	public void InitializeMap() {
		// changer de scene
		// load la map
		choiceDifficulty ();
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
