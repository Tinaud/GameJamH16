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


	// Use this for initialization
    void Start() {
		noteT.text = GameManager.instance.NotesMax.ToString();
		player = GetComponentInParent<ControllerYoung> ().GetComponentInParent<Player>();
		time = gameManager.GetComponent<Timer> ();
	}
	
	// Update is called once per frame
	void Update () {
		hour = time.Hours;
		min = time.Minutes;
		healthSlider.value = player.Health;
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

}
