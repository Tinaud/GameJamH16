using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	Controller oldBrother;
	ControllerYoung youngBrother;

	private int damagePower = 2;
    private int health = 100;
    private bool alive = true;

	private int answer; 	// Nombre de reponses collectees

	void Start() {
		answer = GameManager.instance.AnswerCollected;
	}

    public void characterHurt(int damage)
    {
        health -= damage;
    }

    public void setCharacterHealth(int patate)
    {
        health = patate;
    }
    
	void Awake() {
		youngBrother = GetComponentInChildren<ControllerYoung> ();
		oldBrother = GetComponentInChildren<Controller> ();
	}

	void Update () {

        if (health <= 0)
        {
            alive = false;
        }
	}

    
}
