using UnityEngine;
using System.Collections;

public class MenuTrigger : MonoBehaviour {

	public GameObject menu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter2D (Collider2D patate)
	{
		Player player = GetComponentInParent<Player>();
		if (patate.tag == "easy") {
			menu.GetComponent<Menu> ().easybutton ();
		} else if (patate.tag == "medium") {
			menu.GetComponent<Menu> ().medbutton ();			
		} else if (patate.tag == "hard") {
			menu.GetComponent<Menu> ().hardbutton ();			
		}
	}
}
