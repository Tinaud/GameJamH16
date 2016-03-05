using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance = null;	

	public enum Gender {Boy, Girl};
	Gender olderSex, youngerSex;

	private int nbEnnemiesMax;

	public int AnswerCollected = 0;
	private MapEditor mapScript;
	private List<Enemy> enemies;

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
}
