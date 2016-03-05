using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private int damagePower = 2;
    private int health = 100;
    private bool alive = true;
	private float distance,
				  moveSpeed;
	private GameObject oldBrother;
	private Vector2 direction;

	private Animator animator;

	void Start()
	{
		oldBrother = GameObject.Find("Brothers").GetComponentInChildren<Controller>().gameObject;
		moveSpeed = 3f;
	}

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
            this.gameObject.SetActive(false);
        }
		distance = getDistance();
		if(distance < 3 && distance > 1)
		{
			direction = normalize(oldBrother.transform.position.x - this.transform.position.x, oldBrother.transform.position.y - this.transform.position.y);
			transform.Translate(direction * moveSpeed * Time.deltaTime);
		}
	}

	Vector2 normalize(float x, float y)
	{
		float length = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
		Vector2 temp;

		temp.x = x / length;
		temp.y = y / length;

		return temp;
	}

	float getDistance()
	{
		return Mathf.Sqrt(Mathf.Abs(oldBrother.transform.position.x - this.transform.position.x) + Mathf.Abs(oldBrother.transform.position.y - this.transform.position.y));
	}

	// Pour Evenement les profs vont dans la cour
	public void goTo(int zone) {

	}
}
