using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	
	Controller oldBrother;
	ControllerYoung youngBrother;

	private bool isInExamRoom = false;

	public bool IsInExamRoom {
		get {
			return isInExamRoom;
		}
		set {
			isInExamRoom = value;
		}
	}

	public int damagePower = 2;
	private float health = 80;

	public float Health {
		get {
			return health;
		}
        set {
            health = value;
        }
	}

	private bool alive = true;

	public bool Alive {
		get {
			return alive;
		}
	}

	private int note;		// Nombre de reponses collectees



	public int Note {
		get {
			return note;
		}
		set {
			note = value;
		}
	}

	void Start() {
		note = GameManager.instance.NoteCollected;
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
			note++;
	}

	public void TakeDamage(int damage) {
		health -= damage;
	}
}
