using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

    private bool isVisible = false;
    private bool hasNote = false;
    private int sizeX = 0;
    private int sizeY = 0;

    public void setHasNote(bool patate)
    {
        hasNote = patate;
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


}
