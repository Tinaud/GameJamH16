using UnityEngine;
using System.Collections;

public class MenuTrigger : MonoBehaviour {

	public GameObject menu;
	private string name;
	private float moveSpeed,
	movementH,
	movementV;

	// Use this for initialization
	void Start () {
		moveSpeed = 100f;
		name = "naud";
	}
	
	// Update is called once per frame
	void Update () {
		movementH = Input.GetAxis("HorizontalYoung");
		movementV = Input.GetAxis("VerticalYoung");
		transform.Translate(Vector2.right * moveSpeed * Input.GetAxis("HorizontalYoung") * Time.deltaTime);
		transform.Translate(Vector3.down * moveSpeed * Input.GetAxis("VerticalYoung") * Time.deltaTime);
		Debug.Log(Input.GetButtonDown("Accept"));
		if (Input.GetButtonDown ("Accept")&& name != "naud") {
			if (name == "easy")
				menu.GetComponent<Menu> ().easybutton ();
			if (name == "medium")
				menu.GetComponent<Menu> ().medbutton ();
			if (name == "hard")
				menu.GetComponent<Menu> ().hardbutton ();
			if (name == "play")
				menu.GetComponent<Menu> ().playtime ();
			if (name == "exit")
				menu.GetComponent<Menu> ().Exit ();
		}
			
	}

	private void OnTriggerEnter2D (Collider2D patate) {	
		name = patate.tag;
	}
}
