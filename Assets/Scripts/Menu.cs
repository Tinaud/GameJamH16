using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public Sprite ferm;
	public Sprite ouv;
	public GameObject play;
	public Button easy;
	public Button med;
	public Button hard;
	public GameObject menu;
	public GameObject world;

	private int difficulty;

	public int Difficulty {
		get {
			return difficulty;
		}
	}

	bool playable;

	// Use this for initialization
	void Start () {
		difficulty = 0;

		easy.image.overrideSprite = ferm;
		med.image.overrideSprite = ferm;
		hard.image.overrideSprite = ferm;

		play.SetActive(false);
		playable = false;
		menu.SetActive(true);

		DontDestroyOnLoad(gameObject);
	}

	// Update is called once per frame
	void Update () {
		if (playable)
			play.SetActive(true);
	}

	public void easybutton() {
		easy.image.overrideSprite = ouv;
		med.image.overrideSprite = ferm;
		hard.image.overrideSprite = ferm;
		Debug.Log ("Easy");
		playable = true;
		difficulty = 1;
	}

	public void medbutton() {
		easy.image.overrideSprite = ferm;
		med.image.overrideSprite = ouv;
		hard.image.overrideSprite = ferm;
		Debug.Log ("Medium");
		playable = true;
		difficulty = 2;
	}

	public void hardbutton() {
		easy.image.overrideSprite = ferm;
		med.image.overrideSprite = ferm;
		hard.image.overrideSprite = ouv;
		Debug.Log ("Hard");
		playable = true;	
		difficulty = 3;
	}

	public void playtime(){
		enabled = false;
		menu.SetActive(false);
		menu.GetComponent<AudioSource> ().Pause ();

		SceneManager.LoadScene ("Game");
	}

	public void playtime2(){
		enabled = false;
		menu.SetActive(false);
		menu.GetComponent<AudioSource> ().Pause ();

		world = (GameObject)Instantiate (world, Vector2.zero, Quaternion.identity);
	}
}
