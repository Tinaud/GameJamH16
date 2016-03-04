using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

	private enum Rooms {Corridor=0, History=1, Geography=2, French=3, Maths=4, English=5, Music=6, ToiletsM=7, ToiletsW=8, DirectorOffice=9, ProfRoom=10, Library=11, Locker=12, Gym=13, Courtyard=14, Cafeteria=15, Kitchen=16};
	Rooms type;

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

}
