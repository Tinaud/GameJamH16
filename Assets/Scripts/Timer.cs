using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{

    public static float timer = 480;
    public static bool timeStarted = false;
    int hours, minutes;

    void Start()
    {

    }

    void Update()
    {
        timer = timer + 2*Time.deltaTime;
        hours = (int)timer / 60;
        minutes = (int) timer % 60;
        Debug.Log(hours);
        Debug.Log(minutes);
    }
}
