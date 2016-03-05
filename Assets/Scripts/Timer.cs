using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    public static float timer = 480;
    public bool timeStarted = false;
	int hours, minutes;

	public int Minutes {
		get {
			return minutes;
		}
	}

	public int Hours {
		get {
			return hours;
		}
	}
		
    void Start()
    {
		
	}
		
	public void StartTimer() {
		timeStarted = true;
	}

	public void StopTimer() {
		timeStarted = false;
		enabled = false;
	}

    void Update()
    {
		if (timeStarted) {
	        timer = timer + 2*Time.deltaTime;
	        hours = (int)timer / 60;
	        minutes = (int) timer % 60;
	        //Debug.Log(hours + ":" + minutes);
		}
    }
}
