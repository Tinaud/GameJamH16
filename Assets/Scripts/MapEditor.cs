using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapEditor : MonoBehaviour {

	private SpriteRenderer sr;
	public Sprite mapSprite;
	GameObject zones;
	GameObject walls;

	int noteToPlace;

    public int NoteToPlace
    {
        get
        {
            return noteToPlace;
        }

        set
        {
            noteToPlace = value;
        }
    }
	private List<Room> roomList;

	void placeNote(Room patateRoom) {
		Vector2 randomPos = new Vector2 ();

		randomPos.x = Random.Range ((patateRoom.transform.position.x - patateRoom.gameObject.GetComponent<BoxCollider2D> ().size.x / 2), 
			(patateRoom.transform.position.x + patateRoom.gameObject.GetComponent<BoxCollider2D> ().size.x / 2));

		randomPos.y = Random.Range ((patateRoom.transform.position.y - patateRoom.gameObject.GetComponent<BoxCollider2D> ().size.y / 2), 
			(patateRoom.transform.position.y + patateRoom.gameObject.GetComponent<BoxCollider2D> ().size.y / 2));

		GameObject note = Instantiate (Resources.Load ("Note", typeof(GameObject)), randomPos, Quaternion.identity) as GameObject;
		noteToPlace--;
		Debug.Log ("note in " + patateRoom.transform.name);
	}

	public void InitializeMap() {
		sr = GetComponent<SpriteRenderer> ();
		sr.sprite = mapSprite;
		zones = Instantiate (Resources.Load ("Zones", typeof(GameObject))) as GameObject;
		walls = Instantiate (Resources.Load ("Walls", typeof(GameObject))) as GameObject;

		roomList = new List<Room>(zones.GetComponentsInChildren<Room> ());
		placeNote (getRandomRoom());
	}
		
	Room getRandomRoom() {
		System.Random rnd = new System.Random ();
		int patate = rnd.Next (0, roomList.Count);

		Room randomRoom = roomList [patate];
		roomList.RemoveAt (patate);

		return randomRoom;
	}

    public void setEasy()
    {
		noteToPlace = 6;
    }

    public void setMedium()
    {
		noteToPlace = 9;
    }

    public void setHard()
    {
		noteToPlace = 12;
    }
}

