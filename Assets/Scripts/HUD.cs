using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public float healthmax;
    public float health;
    public int notes;
    public int notesTotal;
    public int min;
    public int hour;
    public Text note;
    public Text noteT;
    public Text minT;
    public Text hourT;
    public Slider healthSlider;
	GameObject sister;
	Player player;
	Timer time;


	// Use this for initialization
    void Start() {
        noteT.text = "" + notesTotal;
		player = GameObject.Find ("Brothers").GetComponent<Player> ();
		time = GetComponent<Timer> ();
	}
	
	// Update is called once per frame
	void Update () {
		hour = time.Hours;
		min = time.Minutes;
		health = player.Health;
		notes = player.Answer;
        healthSlider.value = health;
        note.text = "" + notes;
        if (hour < 10)
            hourT.text = "0" + hour;
        else
            hourT.text = "" + hour;
        if (min < 10)
            minT.text = "0" + min;
        else
            minT.text = "" + min;
	}
}
