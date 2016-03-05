using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Sprite[] enemy1, enemy2, enemy3, choosenEnemy;
    private int damagePower = 2;
    private int health = 100;
    private int rand;
    private bool alive = true;
	private float distance,
				  moveSpeed;
	private GameObject oldBrother;
	private Vector2 direction;
    private SpriteRenderer sr;

	private Animator animator;

	void Awake()
	{
		oldBrother = GameObject.Find("Brothers").GetComponentInChildren<Controller>().gameObject;
        sr = GetComponent<SpriteRenderer>();
		moveSpeed = 3f;
        rand = Random.Range(1, 4);

        switch(rand)
        {
            case 1:
                choosenEnemy = enemy1;
                break;
            case 2:
                choosenEnemy = enemy2;
                break;
            default:
                choosenEnemy = enemy3;
                break;
        }
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

            if (direction.y < 0)
                sr.sprite = choosenEnemy[0];
            else
                sr.sprite = choosenEnemy[1];
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
}
