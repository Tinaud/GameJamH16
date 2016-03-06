﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	
    public int min;
    public int hour;
    public Text note;
    public Text noteT;
    public Text minT;
    public Text hourT;
    public Slider healthSlider;
	Player player;
	public GameObject gameManager;
	Timer time;

	bool inDanger = false;
	int once = 1;


	// Use this for initialization
    void Start() {
		noteT.text = GameManager.instance.NotesMax.ToString();
		player = GetComponentInParent<ControllerYoung> ().GetComponentInParent<Player>();
		time = gameManager.GetComponent<Timer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inDanger && once == 1) {
			StartCoroutine (faint ());
			once--;
		}

		hour = time.Hours;
		min = time.Minutes;
		healthSlider.value = player.Health;

		if (healthSlider.value < 30)
			inDanger = true;
		
		note.text = player.Note.ToString();
		if (hour < 10)
			hourT.text = "0" + hour;
		else
			hourT.text = "" + hour;
		if (min < 10)
			minT.text = "0" + min;
		else
			minT.text = "" + min;
	}

	IEnumerator faint() {
		while (player.Health > 0 && player.Health < 30) {
			
			healthSlider.gameObject.SetActive (false);
			yield return new WaitForSeconds (.7f);
			healthSlider.gameObject.SetActive (true);
			yield return new WaitForSeconds (1f);
		}
	}

}
