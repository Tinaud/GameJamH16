using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapEditor : MonoBehaviour {

	int nbNoteToPlace;
    private Room roomNote;
    private List<Room> roomList;
    private int Diff;
    private int difficulte;
    public GameObject Note;

	public int NbNoteToPlace {
		get {
			return nbNoteToPlace;
		}
		set {
			nbNoteToPlace = value;
		}
	}

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void placeNote() {

	}

	void InitializeMap() {
		placeFirstNote(roomNote);
	}
		
	void placeFirstNote(Room patate) {

        GameObject newNote = (GameObject)Instantiate(Note, new Vector3(0, 0, 0f), Quaternion.identity); // changer la position pour la position de la zone

	}

    public void setEasy()
    {
        difficulte = 6;
    }

    public void setMedium()
    {
        difficulte = 9;
    }

    public void setHard()
    {
        difficulte = 12;
    }
}

