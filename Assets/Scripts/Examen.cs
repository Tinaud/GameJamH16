using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class Examen : MonoBehaviour {

	private List<string> notes = new List<string> ();
	private List<string> questions = new List<string> ();
	private int good = 0;
	private int ques = 6, Y = 360, x=0;
	public GameObject canvas;
	GameObject InstObject;
	bool question = false;
	public Text goods;
	public Text total;

	// Use this for initialization
	void Start () {
		notes.Add ("Horse");
		notes.Add ("1942");
		notes.Add ("24");
		notes.Add ("Oui");
		notes.Add ("When");
		notes.Add ("Canada");
		questions.Add ("Which animal Karine like?");
		questions.Add ("When am I born?");
		questions.Add ("2 + 4 = ?");
		questions.Add ("Say yes in french");
		questions.Add ("A word for time questions");
		questions.Add ("Which country?");
		total.text = ques + "";
		for (int i = 0; i < ques; i++) {
			InstObject = (GameObject)Instantiate(Resources.Load("Answers"),new Vector3(0,0,0), Quaternion.identity);
			InstObject.transform.parent = canvas.transform;
			InstObject.transform.localScale = new Vector3 (1, 1, 1);
			InstObject.transform.localPosition = new Vector3 (800, (Y-70*i), 0);
			int rnd = Random.Range (0, notes.Count);
			InstObject.GetComponentInChildren<Text> ().text = notes[rnd];
			InstObject.tag = notes[rnd];
			notes.RemoveAt (rnd);
		}
	}

	// Update is called once per frame
	void Update () {
		goods.text =  good +" /";
		if (!question && x<=ques) {
			askquestion (x);
		}
	}

	void askquestion(int i) {
		question = true;
		InstObject = (GameObject)Instantiate(Resources.Load("Text"),new Vector3(0,0,0), Quaternion.identity);
		InstObject.transform.parent = canvas.transform;
		InstObject.transform.localScale = new Vector3 (1, 1, 1);
		int rnd = Random.Range (0, questions.Count);
		InstObject.GetComponentInChildren<Text> ().text = questions[rnd];
		questions.RemoveAt (rnd);
	}

	public void verification(int i){
		/*Debug.Log (i);
		Destroy (InstObject);
		if (notes [x] == notes [i])
			good++;
		x++;
		question = false;*/
	}
}
