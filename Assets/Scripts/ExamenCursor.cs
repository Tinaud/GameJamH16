using UnityEngine;
using System.Collections;

public class ExamenCursor : MonoBehaviour {

	public GameObject examen;
	private string name;
	private float moveSpeed,
	movementH,
	movementV;

	// Use this for initialization
	void Start () {
		moveSpeed = 8f;
		name = "naud";
	}

	// Update is called once per frame
	void Update () {
		movementH = Input.GetAxis("HorizontalYoung");
		movementV = Input.GetAxis("VerticalYoung");
		transform.Translate(Vector2.right * moveSpeed * Input.GetAxis("HorizontalYoung") * Time.deltaTime);
		transform.Translate(Vector3.down * moveSpeed * Input.GetAxis("VerticalYoung") * Time.deltaTime);
		if (Input.GetButtonDown ("Accept")&& name != "naud") {
			if (name == "Horse")
				examen.GetComponent<Examen> ().verification (0);
			if (name == "1942")
				examen.GetComponent<Examen> ().verification (1);				
			if (name == "24")
				examen.GetComponent<Examen> ().verification (2);				
			if (name == "Oui")
				examen.GetComponent<Examen> ().verification (3);				
			if (name == "When")
				examen.GetComponent<Examen> ().verification (4);				
			if (name == "Canada")
				examen.GetComponent<Examen> ().verification (5);				
		}

	}

	private void OnTriggerEnter2D (Collider2D patate) {	
		name = patate.tag;
	}
}
