using UnityEngine;
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

	private List<Enemy> enemies;
	private Player player;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);	

		DontDestroyOnLoad(gameObject);

		enemies = new List<Enemy>();

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

		enabled = false;

	}

	public void GameWin() {
		//Set levelText to display number of levels passed and game over message
		levelText.text = "You success your Exam " + level + " !!!!";

		//Enable black background image gameObject.
		levelImage.SetActive (true);

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
