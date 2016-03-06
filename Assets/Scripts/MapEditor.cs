using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapEditor : MonoBehaviour {

	public GameObject noteObj;
	int noteToPlace;
    public int NoteToPlace {
        get {
            return noteToPlace;
        }
        set {
            noteToPlace = value;
        }
    }

	private List<Room> roomList;

	public void placeNote(Room patateRoom, int id) {

		Vector2 randomPos = new Vector2 ();

		randomPos.x = Random.Range ((patateRoom.transform.position.x - patateRoom.gameObject.GetComponent<BoxCollider2D> ().size.x / 2), 
			(patateRoom.transform.position.x + patateRoom.gameObject.GetComponent<BoxCollider2D> ().size.x / 2));

		randomPos.y = Random.Range ((patateRoom.transform.position.y - patateRoom.gameObject.GetComponent<BoxCollider2D> ().size.y / 2), 
			(patateRoom.transform.position.y + patateRoom.gameObject.GetComponent<BoxCollider2D> ().size.y / 2));

		GameObject note = Instantiate (noteObj, randomPos, Quaternion.identity) as GameObject;
		note.name = "Note_" + id;
		note.transform.parent = patateRoom.transform;
		Debug.Log (note.name + " in " + patateRoom.transform.name);
	}

	public void InitializeMap() {
		//gameObject.SetActive (true);

		noteToPlace = GameManager.instance.NotesMax;
		roomList = new List<Room>(gameObject.GetComponentsInChildren<Room> ());
		for (int i = 0; i < noteToPlace; i++) {
			placeNote (getRandomRoom (), i+1);
		}
	}
		
	Room getRandomRoom() {
		int patate = Random.Range (0, roomList.Count);

		Room randomRoom = roomList [patate];
		roomList.RemoveAt (patate);

		return randomRoom;
	}
}

