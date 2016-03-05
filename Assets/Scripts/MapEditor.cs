using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapEditor : MonoBehaviour {

	int nbAnswerToPlace;
    private Room roomAnswer;
    private List<Room> roomList;
    private int Diff;
    private int difficulte;
    public GameObject Answer;

	public int NbAnswerToPlace {
		get {
			return nbAnswerToPlace;
		}
		set {
			nbAnswerToPlace = value;
		}
	}

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void placeAnswer() {

	}

	void InitializeMap() {
		placeFirstAnswer(roomAnswer);
	}
		
	void placeFirstAnswer(Room patate) {

        GameObject newAnswer = (GameObject)Instantiate(Answer, new Vector3(0, 0, 0f), Quaternion.identity); // changer la position pour la position de la zone

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

