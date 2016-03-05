using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

	private SpriteRenderer sr;
	private Color srColor;
	private BoxCollider2D boxCollider;

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
		sr = GetComponent<SpriteRenderer> ();
		boxCollider = GetComponent<BoxCollider2D> ();
		srColor = sr.color;
	}

	void Update() {
		if (controllersInside > 0) {
			srColor.a = 0;
		} else if (controllersInside == 0) {
			srColor.a = 255;
		}
		sr.color = srColor;

	}


    public void setHasNote(bool patate)
    {
        hasNote = patate;
    }

}
