using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {
	private Color srColor;
	public int index = 0;
	private int controllersInside = 0;

	public int ControllersInside {
		get {
			return controllersInside;
		}
		set {
			controllersInside = value;
		}
	}

	private bool isVisible = false;

	public bool IsVisible {
		get {
			return isVisible;
		}
		set {
			isVisible = value;
		}
	}

    private bool hasNote = false;
    public bool HasNote {
        get {
            return hasNote;
        }
        set {
            hasNote = value;
        }
    }

    void Start() {
		srColor = GetComponent<SpriteRenderer> ().color;
		srColor.a = .8f;
		GetComponent<SpriteRenderer> ().color = srColor;
	}

	void Update() {
		if (controllersInside > 0) {
			srColor.a = 0;
		} else {
			srColor.a = .8f;
		}
		GetComponent<SpriteRenderer> ().color = srColor;
	}


    public void setHasNote(bool patate)
    {
        hasNote = patate;
    }


	public string nameOfRoom() {
		switch (index) {
		case 1:
			return "History Class";
		case 2:
			return "Geeography Class";
		case 3:
			return "Classe de Fraçais";
		case 4:
			return "Maths Class";
		case 5:
			return "English Class";
		case 6:
			return "Clase de Musica";
		case 7:
			return "Boy Services";
		case 8:
			return "Girl Services";
		case 9: 
			return "Director Office";
		case 10:
			return "Profs Room";
		case 11:
			return "Library";
		case 12:
			return "Courtyard";
		case 14:
			return "Gym";
		case 15:
			return "Cafeteria";
		case 16:
			return "Kitchen";
		default:
			return "";
		}
	}
}
