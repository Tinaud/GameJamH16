using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	
	public static Player instance = null;

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

	private bool isEnterInRoom = false;
	public bool IsEnterInRoom {
		get {
			return isEnterInRoom;
		}
		set {
			isEnterInRoom = value;
		}
	}

	Room currentRoom;

	public Room CurrentRoom {
		get {
			return currentRoom;
		}
		set {
			currentRoom = value;
		}
	}

	public int damagePower = 2;
	private float health = 100;
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
		note = 0;
		currentRoom = null;
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
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);	
		
		youngBrother = GetComponentInChildren<ControllerYoung> ();
		oldBrother = GetComponentInChildren<Controller> ();
	}

	void Update () {
		if (health > 100)
			health = 100; 
		
        if (health <= 0)
        {
			health = 0;
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

	public void showRoomName() {
		StartCoroutine (HUDindic ());
	}

	IEnumerator HUDindic() {
		GameManager.instance.HUD.GetComponent<HUD> ().roomIndic.text = currentRoom.nameOfRoom ();
		GameManager.instance.HUD.GetComponent<HUD> ().roomIndic.gameObject.SetActive (true);
		yield return new WaitForSeconds (3f);
		GameManager.instance.HUD.GetComponent<HUD> ().roomIndic.gameObject.SetActive (false);
	}
}
