using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public float healthmax;
    public int min;
    public int hour;
    public Text note;
    public Text noteT;
    public Text minT;
    public Text hourT;
    public Slider healthSlider;
	Player player;
	GameManager gameManager;
	Timer time;


	// Use this for initialization
    void Start() {
		gameManager = GetComponent<GameManager> ();
		player = GetComponentInParent<ControllerYoung> ().GetComponentInParent<Player>();
		time = GetComponent<Timer> ();
	}
	
	// Update is called once per frame
	void Update () {
		hour = time.Hours;
		min = time.Minutes;
		healthSlider.value = player.Health;
		note.text = "" + player.Note;
        if (hour < 10)
            hourT.text = "0" + hour;
        else
            hourT.text = "" + hour;
        if (min < 10)
            minT.text = "0" + min;
        else
            minT.text = "" + min;
	}

	public void setEasy()
	{
		noteT.text = "" + 6;
	}

	public void setMedium()
	{
		noteT.text = "" + 9;
	}

	public void setHard()
	{
		noteT.text = "" + 12;
	}


}
