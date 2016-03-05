using UnityEngine;
using System.Collections;

public class TestDrop : MonoBehaviour {

	public GameObject papel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			destruct ();
		}
	}

	void destruct() {
		int rnd = Random.Range (1, 10);
		Debug.Log (rnd);
		if (rnd == 9) {
			GameObject patate = Instantiate (papel);
			patate.transform.position = transform.position;
		}
		Destroy (gameObject);
	}
}
