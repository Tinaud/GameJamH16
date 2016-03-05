using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {

	private Events eventManager;

	public static GameManager instance = null;	
	public float levelStartDelay = 2f;
	private int level = 1;
	private GameObject levelImage;
	private Text levelText;
	Timer timer;

	public enum Gender {Boy, Girl};
	Gender olderSex, youngerSex;

	private int nbEnnemiesMax;
    private int nbNotesMax;

    public int NoteCollected = 0;
	private MapEditor mapScript;
	private List<Enemy> enemies;

	private Player player;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);	

		DontDestroyOnLoad(gameObject);

		timer = GetComponent<Timer> ();
		eventManager = GetComponent<Events> ();
		enemies = new List<Enemy>();
		mapScript = GameObject.Find("Map").GetComponent<MapEditor>();

		// Par défaut pour le moment, flafla
		olderSex = Gender.Boy;
		youngerSex = Gender.Boy;
		player = GetComponentInParent<ControllerYoung> ().GetComponentInParent<Player>();
	}

	public void InitGame() {
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();

		levelText.text = "Exam " + level;
		levelImage.SetActive (true);

        nbNotesMax = mapScript.NoteToPlace;
		Invoke("HideLevelImage", levelStartDelay);
		Debug.Log ("Level 1 Start !!!");
	}

	void HideLevelImage()
	{
		levelImage.SetActive(false);
		timer.StartTimer ();
		mapScript.InitializeMap ();
		//StartCoroutine(eventLoop());
	}


	// Update is called once per frame
	void Update () {
		if (timer.Hours == 16)
			timer.StopTimer ();

		if (!player.Alive || (!timer.enabled && !player.IsInExamRoom))
			GameOver ();

        if(timer.Hours == 14 && timer.Minutes == 0)
        {
            eventManager.applyEventEffect(2, ref enemies);
        }
		
	}

	public bool AnswerLostInToilets() {
        Room toilet = GameObject.Find("ZoneToiletsF").GetComponent<Room>();
        if (toilet.HasNote)
        {
            nbNotesMax--;
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
