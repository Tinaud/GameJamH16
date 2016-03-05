using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour{

	private int index;

	public int Index {
		get {
			return index;
		}
		set {
			index = value;
		}
	}

	string content = " ";

	public string Content {
		get {
			return content;
		}
	}

	void SetNoteText() {
		switch (index) {
		case 1: 
			content = "A";
			break;
		case 2: 
			content = "B";
			break;
		case 3: 
			content = "C";
			break;
		case 4: 
			content = "D";
			break;
		case 5: 
			content = "E";
			break;
		case 6: 
			content = "F";
			break;
		case 7: 
			content = "G";
			break;
		case 8: 
			content = "H";
			break;
		case 9: 
			content = "I";
			break;
		case 10: 
			content = "J";
			break;
		case 11: 
			content = "K";
			break;
		case 12: 
			content = "L";
			break;
		case 13: 
			content = "M";
			break;
		case 14: 
			content = "N";
			break;
		case 15: 
			content = "O";
			break;

		}
	}
}
