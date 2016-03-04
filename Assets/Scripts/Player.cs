using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int health = 100;
    private bool alive = true;

    public void characterHurt(int damage)
    {
        health -= damage;
    }

    public void setCharacterHealth(int patate)
    {
        health = patate;
    }
    
	void Update () {

        if (health <= 0)
        {
            alive = false;
        }
	}

    private void OnTriggerAnswer(Collider2D patate)
    {

    }
}
