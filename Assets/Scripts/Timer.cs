using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    public Rect timerRect;
    private float startTime;
    private string currentTime;
    private int seconds, minutes, hours;

	void Start () {
        hours = 8;
    }
	
	void Update () {

        if (hours == 16)
            return;
        seconds = seconds + 4;
        if (seconds >= 59)
        {
            minutes++;
            seconds = 0;
        }
        if (minutes == 59)
        {
            hours++;
            minutes = 0;
        }
        currentTime = string.Format("{0:##}:{1:##}", hours, minutes);
        Debug.Log(currentTime);
    }
}
