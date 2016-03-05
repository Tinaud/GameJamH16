using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public float healthmax;
    public float health;
    public int notes;
    public int notesTotal;
    public Text note;
    public Text noteT;
    public Slider healthSlider;

	// Use this for initialization
	void Start () {
        note.text = "" + notes;
        noteT.text = "" + notesTotal;
	}
	
	// Update is called once per frame
	void Update () {
        healthSlider.value = health;
	}
}
