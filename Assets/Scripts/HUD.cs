using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	
    public int min;
    public int hour;
    public Text note;
    public Text noteT;
    public Text minT;
    public Text hourT;
	public Text roomIndic;
    public Slider healthSlider;
	public GameObject gameManager;
	Timer time;

	bool inDanger = false;
	bool onceD;


	// Use this for initialization
    void Start() {
		onceD = false; 
		noteT.text = GameManager.instance.NotesMax.ToString();
		time = gameManager.GetComponent<Timer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inDanger && !onceD) {
			StartCoroutine (faint ());
			onceD = true;
		}

		hour = time.Hours;
		min = time.Minutes;
		healthSlider.value = Player.instance.Health;

		if (healthSlider.value < 30)
			inDanger = true;
		else
			inDanger = false;
		
		note.text = Player.instance.Note.ToString();
		if (hour < 10)
			hourT.text = "0" + hour;
		else
			hourT.text = "" + hour;
		if (min < 10)
			minT.text = "0" + min;
		else
			minT.text = "" + min;
	}

	IEnumerator faint() {
		while (Player.instance.Health > 0 && Player.instance.Health < 30) {
			
			healthSlider.gameObject.SetActive (false);
			yield return new WaitForSeconds (.7f);
			healthSlider.gameObject.SetActive (true);
			yield return new WaitForSeconds (1f);
		}
	}
}
