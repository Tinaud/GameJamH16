using UnityEngine;
using System.Collections;

public class MapEditor : MonoBehaviour {

	int nbAnswerToPlace;

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
		// load map
		placeFirstAnswer();
	}
		
	void placeFirstAnswer() {

	}
}
