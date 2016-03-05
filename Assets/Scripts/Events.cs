﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Events : MonoBehaviour {

	public List<int> schoolEvents = new List<int> ();

	private GameManager gameManager;

	void Awake () {
		gameManager = GetComponent<GameManager> ();
		schoolEvents.Add (0);
		schoolEvents.Add (1);
		schoolEvents.Add (2);
	}

	public int getEvent() {
		int eventToSend = schoolEvents [0];
		schoolEvents.RemoveAt(0);

		return eventToSend;
	}

	public void applyEventEffect(int eventNumber, ref List<Enemy> enemies)
	{
		switch (eventNumber) {
		case 0:
			Debug.Log ("Playtime, everybody out !");
			foreach (Enemy enemy in enemies)
				enemy.goTo (0);
			break;
		case 1:
			Debug.Log ("FoodParty !! Hold a potatoe and Potate them !!!!!");
			foreach (Enemy enemy in enemies)
				enemy.goTo (0);
			break;
		case 2:
			if (gameManager.AnswerLostInToilets ())
				Debug.Log ("Ohh ! Crap women's toilets are in fire !! You lost an answer.");
			else
				Debug.Log ("Something spêcial !! Women's toilets are in fire !!");
			break;
		}
	}

	public void restoreEvents() {

	}
}