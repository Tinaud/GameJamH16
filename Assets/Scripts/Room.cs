using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

    private bool isVisible = false;
    private bool hasAnswer = false;
    private int sizeX = 0;
    private int sizeY = 0;

    public void setHasAnswer(bool patate)
    {
        hasAnswer = patate;
    }


    public void setIsVisible(bool patate)
    {
        isVisible = patate;
    }

    public void setSizeX(int patate)
    {
        sizeX = patate;
    }

    public void setSizeY(int patate)
    {
        sizeY = patate;
    }
<<<<<<< HEAD
=======

>>>>>>> c59f04349a594e1e9a36462e8bdac89ae2bdf126
}
