﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	
	Controller oldBrother;
	ControllerYoung youngBrother;

	public int damagePower = 2;
	private float health = 100;

	public float Health {
		get {
			return health;
		}
	}

	private bool alive = true;

	public bool Alive {
		get {
			return alive;
		}
	}

	private int answer;		// Nombre de reponses collectees
	public int Answer {
		get {
			return answer;
		}
	}

	void Start() {
		answer = GameManager.instance.AnswerCollected;
	}

    public void characterHurt(int damage)
    {
        health -= damage;
    }

    public void setCharacterHealth(int patate)
    {
        health = patate;
    }
    
	void Awake() {
		youngBrother = GetComponentInChildren<ControllerYoung> ();
		oldBrother = GetComponentInChildren<Controller> ();
	}

	void Update () {
        if (health <= 0)
        {
            alive = false;
        }

		if (Input.GetKey (KeyCode.H))
			health--;

		if (Input.GetKey (KeyCode.P))
			health++;

		if (Input.GetKey (KeyCode.N))
			answer++;
	}

    
}
