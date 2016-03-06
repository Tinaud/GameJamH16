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
			if (name == "Beaver")
				examen.GetComponent<Examen> ().verification (name);
			if (name == "21-12-2012")
				examen.GetComponent<Examen> ().verification (name);				
			if (name == "Everywhere")
				examen.GetComponent<Examen> ().verification (name);				
			if (name == "Oui")
				examen.GetComponent<Examen> ().verification (name);				
			if (name == "Purple")
				examen.GetComponent<Examen> ().verification (name);				
			if (name == "Canada")
				examen.GetComponent<Examen> ().verification (name);			
			if (name == "Grilled Cheese")
				examen.GetComponent<Examen> ().verification (name);			
			if (name == "Trump")
				examen.GetComponent<Examen> ().verification (name);			
			if (name == "Recess")
				examen.GetComponent<Examen> ().verification (name);		
			if (name == "(a)jar")
				examen.GetComponent<Examen> ().verification (name);		
			if (name == "socks")
				examen.GetComponent<Examen> ().verification (name);		
			if (name == "Procrastination")
				examen.GetComponent<Examen> ().verification (name);	
			if (name == "I don't know")
				examen.GetComponent<Examen> ().verification (name);	
		}

	}

	private void OnTriggerEnter2D (Collider2D patate) {	
		name = patate.tag;
	}
}
