using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {
	
	public static GameManager instance = null;	
	public float levelStartDelay = 2f;
	private int level = 1;
	private GameObject levelImage;
	private Text levelText;

	public enum Gender {Boy, Girl};
	Gender olderSex, youngerSex;

	private int nbEnnemiesMax;

	public int AnswerCollected = 0;
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

		enemies = new List<Enemy>();
		mapScript = GetComponent<MapEditor>();

		InitGame ();

		// Par défaut pour le moment, flafla
		olderSex = Gender.Boy;
		youngerSex = Gender.Boy;
		player = GetComponentInChildren<Player> ();
	}

	void InitGame() {
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();

		levelText.text = "Exam " + level;
		levelImage.SetActive (true);

		Invoke("HideLevelImage", levelStartDelay);
		Debug.Log ("Level 1 Start !!!");
	}

	void HideLevelImage()
	{
		levelImage.SetActive(false);
	}


	// Update is called once per frame
	void Update () {
		if (!player.Alive)
			GameOver ();
		
	}

	public void GameOver() {
		//Set levelText to display number of levels passed and game over message
		levelText.text = "You failed your Exam " + level + " !!!!";

		//Enable black background image gameObject.
		levelImage.SetActive(true);

		enabled = false;

	}
}
