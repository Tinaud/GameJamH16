using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    public Rect timerRect;
    private float startTime;
    private string currentTime;
    private int seconds, minutes, hours;

	bool activate = false;

	public bool Activate {
		get {
			return activate;
		}
		set {
			activate = value;
		}
	}

	void Awake () {
        hours = 8;
		minutes = 0;
		seconds = 0;
    }

	public void StartTimer() {
		activate = true;
	}
	
	void Update () {
		if (activate) {
			if (hours == 16) {
				enabled = false;
			}

			seconds += 40;
			if (seconds >= 59) {
				minutes++;
				seconds = 0;
			}
			if (minutes == 59) {
				hours++;
				minutes = 0;
			}
			currentTime = string.Format ("{0:##}:{1:##}", hours, minutes);
			Debug.Log (currentTime);
		}
    }
}
