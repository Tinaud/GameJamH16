using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {
	private Color srColor;

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

}
