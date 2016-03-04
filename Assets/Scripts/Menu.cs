using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public Sprite ferm;
	public Sprite ouv;
	public GameObject play;
	public Button easy;
	public Button med;
	public Button hard;
	public GameObject menu;
	public GameObject HUD;

	bool playable;

	// Use this for initialization
	void Start () {
		easy.image.overrideSprite = ferm;
		med.image.overrideSprite = ferm;
		hard.image.overrideSprite = ferm;
		play.SetActive(false);
		playable = false;
		menu.SetActive(true);
		HUD.SetActive (false);
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
		playable = true;		
	}

	public void medbutton() {
		easy.image.overrideSprite = ferm;
		med.image.overrideSprite = ouv;
		hard.image.overrideSprite = ferm;
		playable = true;		
	}

	public void hardbutton() {
		easy.image.overrideSprite = ferm;
		med.image.overrideSprite = ferm;
		hard.image.overrideSprite = ouv;
		playable = true;		
	}

	public void playtime(){
		menu.SetActive(false);
		HUD.SetActive (true);
	}
}
