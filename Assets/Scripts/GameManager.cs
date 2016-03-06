﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {

	private Events eventManager;

	public static GameManager instance = null;	

	// Ecran Debut, GameOver/ Win
	private float levelStartDelay = 2f;
	private int level = 1;
	private GameObject levelImage;
	private Text levelText;


	Timer timer;
	private MapEditor mapScript;
	public GameObject HUD;
	private GameObject menuCamera;

	private int notesMax;
	public int NotesMax {
		get {
			return notesMax;
		}
		set {
			notesMax = value;
		}
	}

	public GameObject[] bullies;
	private List<Enemy> enemies;
	private List<Vector2> spawnPoints;
	private Player player;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);	

		DontDestroyOnLoad(gameObject);

		initSpawnList ();
		enemies = new List<Enemy>();
		initEnemies ();

		timer = GetComponent<Timer> ();
		eventManager = GetComponent<Events> ();
		mapScript = GetComponentInChildren<MapEditor> ();
		player = GetComponentInChildren<Player> ();

		// Setup Difficulty (notesMax, enemiesDamage ?)
		menuCamera = GameObject.Find ("MenuCamera");
		setupDifficulty ();
	}
		
	void Start() {
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();

		levelText.text = "Exam " + level;
		levelImage.SetActive (true);

		Invoke("HideLevelImage", levelStartDelay);

		Debug.Log ("Level 1 Start !");
	}

	void HideLevelImage()
	{
		levelImage.SetActive(false);
		GetComponent<AudioSource> ().Play ();
		timer.StartTimer ();
		HUD.SetActive (true);
		mapScript.InitializeMap ();
		//StartCoroutine(eventLoop());
	}


	// Update is called once per frame
	void Update () {
		if (timer.Hours == 16)
			timer.StopTimer ();

		if (!player.Alive || (!timer.enabled && !player.IsInExamRoom))
			GameOver ();

		if (player.Note == 6)
			GameWin ();

       /* if(timer.Hours == 14 && timer.Minutes == 0)
        {
            eventManager.applyEventEffect(2, ref enemies);
        }*/
		
	}

	public bool AnswerLostInToilets() {
		Room toilet = GameObject.Find("ZoneToiletsF").GetComponent<Room>();
        if (toilet.HasNote)
        {
            notesMax--;
            mapScript.NoteToPlace--;
            return true;
        }
		return false;
	}

	public void GameOver() {
		//Set levelText to display number of levels passed and game over message
		levelText.text = "You failed your Exam " + level + " !!!!";

		//Enable black background image gameObject.
		levelImage.SetActive(true);
		GetComponent<AudioSource> ().Stop ();
		enabled = false;

	}

	public void GameWin() {
		//Set levelText to display number of levels passed and game over message
		levelText.text = "You success your Exam " + level + " !!!!";

		//Enable black background image gameObject.
		levelImage.SetActive (true);
		GetComponent<AudioSource> ().Stop ();
		enabled = false;
	}

	void setupDifficulty() {
		int difficulty = menuCamera.GetComponent<Menu> ().Difficulty;
		switch (difficulty) {
		case 1:
			notesMax = 6;
			// enemeniesMaxDamages = 2;
			break;
		case 2:
			notesMax = 9;
			// enemeniesMaxDamages = 4;
			break;
		case 3:
			notesMax = 12;
			// enemeniesMaxDamages = 8;
			break;
		}

		Destroy (menuCamera);
	}

	void initSpawnList() {
		spawnPoints = new List<Vector2> ();

		// classe 1
		spawnPoints.Add (new Vector2 (-55, 144)); spawnPoints.Add (new Vector2 (-54, 136)); spawnPoints.Add (new Vector2 (-48, 140));
		spawnPoints.Add (new Vector2 (-59, 145)); spawnPoints.Add (new Vector2 (-67, 145)); spawnPoints.Add (new Vector2 (-86, 145));

		// classe 2
		spawnPoints.Add (new Vector2 (-55, 112)); spawnPoints.Add (new Vector2 (-54, 104)); spawnPoints.Add (new Vector2 (-48, 108));
		spawnPoints.Add (new Vector2 (-59, 113)); spawnPoints.Add (new Vector2 (-67, 113)); spawnPoints.Add (new Vector2 (-86, 113));

		// classe 3
		spawnPoints.Add (new Vector2 (-55, 80)); spawnPoints.Add (new Vector2 (-54, 82)); spawnPoints.Add (new Vector2 (-48, 76));
		spawnPoints.Add (new Vector2 (-59, 81)); spawnPoints.Add (new Vector2 (-67, 81)); spawnPoints.Add (new Vector2 (-86, 81));

		// classe 4
		spawnPoints.Add (new Vector2 (92, 146)); spawnPoints.Add (new Vector2 (80, 143)); spawnPoints.Add (new Vector2 (72, 144));
		spawnPoints.Add (new Vector2 (61, 139)); spawnPoints.Add (new Vector2 (53, 145)); spawnPoints.Add (new Vector2 (58, 129));

		// classe 5
		spawnPoints.Add (new Vector2 (92, 114)); spawnPoints.Add (new Vector2 (80, 111)); spawnPoints.Add (new Vector2 (72, 112));
		spawnPoints.Add (new Vector2 (61, 107)); spawnPoints.Add (new Vector2 (53, 133)); spawnPoints.Add (new Vector2 (58, 99));

		// classe 6
		spawnPoints.Add (new Vector2 (92, 82)); spawnPoints.Add (new Vector2 (80, 79)); spawnPoints.Add (new Vector2 (72, 80));
		spawnPoints.Add (new Vector2 (61, 75)); spawnPoints.Add (new Vector2 (53, 101)); spawnPoints.Add (new Vector2 (58, 67));

        //bibliotheque
        spawnPoints.Add(new Vector2(-4, 140)); spawnPoints.Add(new Vector2(6, 140)); spawnPoints.Add(new Vector2(6, 130));
        spawnPoints.Add(new Vector2(-4, 130)); spawnPoints.Add(new Vector2(22, 130)); spawnPoints.Add(new Vector2(26, 148));

        //casiers
        spawnPoints.Add(new Vector2(26, 106)); spawnPoints.Add(new Vector2(-10, 106)); spawnPoints.Add(new Vector2(-10, 119));
        spawnPoints.Add(new Vector2(19, 119)); spawnPoints.Add(new Vector2(16, 94)); spawnPoints.Add(new Vector2(-7, 94));

        //coursInterieure
        spawnPoints.Add(new Vector2(-7, 72)); spawnPoints.Add(new Vector2(11, 72)); spawnPoints.Add(new Vector2(17, 63));
        spawnPoints.Add(new Vector2(17, 52)); spawnPoints.Add(new Vector2(9, 48)); spawnPoints.Add(new Vector2(-11, 48));

        //toilettesHommes
        spawnPoints.Add(new Vector2(-56, 48)); spawnPoints.Add(new Vector2(-74, 48));

        //toilettesFemmes
        spawnPoints.Add(new Vector2(-83, 30)); spawnPoints.Add(new Vector2(-61, 30));

        //cafeteriat
        spawnPoints.Add(new Vector2(-61, 5)); spawnPoints.Add(new Vector2(-45, 5)); spawnPoints.Add(new Vector2(-45, -32));
        spawnPoints.Add(new Vector2(-32, -19)); spawnPoints.Add(new Vector2(-18, -15)); spawnPoints.Add(new Vector2(-32, -32));

        //cuisine
        spawnPoints.Add(new Vector2(-78, 1)); spawnPoints.Add(new Vector2(-78, -14)); spawnPoints.Add(new Vector2(-78, -30));
        spawnPoints.Add(new Vector2(-91, -25)); spawnPoints.Add(new Vector2(-93, 0));

        //salle de prof
        spawnPoints.Add(new Vector2(55, 25)); spawnPoints.Add(new Vector2(64, 23)); spawnPoints.Add(new Vector2(82, 23));
        spawnPoints.Add(new Vector2(90, 23)); spawnPoints.Add(new Vector2(56, 31));

        //Bureau Directeur
        spawnPoints.Add(new Vector2(52, 44)); spawnPoints.Add(new Vector2(52, 55)); spawnPoints.Add(new Vector2(64, 50));
        spawnPoints.Add(new Vector2(76, 50)); spawnPoints.Add(new Vector2(96, 50));

        //corridor
        spawnPoints.Add(new Vector2(40, 50)); spawnPoints.Add(new Vector2(40, 70)); spawnPoints.Add(new Vector2(40, 88));
        spawnPoints.Add(new Vector2(40, 110)); spawnPoints.Add(new Vector2(40, 132)); spawnPoints.Add(new Vector2(-37, 148));
        spawnPoints.Add(new Vector2(-37, 113)); spawnPoints.Add(new Vector2(-37, 85)); spawnPoints.Add(new Vector2(-37, 60));
        spawnPoints.Add(new Vector2(-37, 23)); spawnPoints.Add(new Vector2(-18, 20)); spawnPoints.Add(new Vector2(14, 20));
        spawnPoints.Add(new Vector2(2, 8));

    }

	void initEnemies() {
		for (int i = 0; i < 12; i++) {
			int patateSP = Random.Range (0, spawnPoints.Count);
			int rand = Random.Range (0, 5);

			Vector2 randomSP = spawnPoints [patateSP];
			spawnPoints.RemoveAt (patateSP);

			GameObject bully = (GameObject) Instantiate (bullies [rand], randomSP, Quaternion.identity);
			enemies.Add(bully.GetComponent<Enemy>());
			Debug.Log (bully.name);
		}
	}
		
	/*	IEnumerator eventLoop() {
		while (timer.enabled) {
			if ((timer.Hours == 10 && timer.Minutes == 0) || (timer.Hours == 12 && timer.Minutes == 0) || (timer.Hours == 14 && timer.Minutes == 0)) {
				yield return new WaitUntil (() => Input.GetKeyDown (KeyCode.A));
				int eventNumber = eventManager.getEvent ();

				eventManager.restoreEvents ();
				eventManager.applyEventEffect (eventNumber, ref enemies);
			}
		}
	}*/
}
