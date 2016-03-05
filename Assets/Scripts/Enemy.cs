using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	public GameObject papel;
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
	bool playerInRange;
	float timer;
	public float timeBetweenAttacks = .1f;

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
			int rnd = Random.Range (1, 10);
			Debug.Log (rnd);
			if (rnd == 9) {
				GameObject patate = Instantiate (papel);
				patate.transform.position = transform.position;
			}
			Destroy (this.gameObject);
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

	// Pour Evenement les profs vont dans la cour
	public void goTo(int zone) {

	}

	private void OnCollisionStay2D (Collision2D patate)
	{
		timer += Time.deltaTime/5;
		if (patate.gameObject.tag == "Player" && timer >= timeBetweenAttacks) {
			Attack();
			timer = 0;
		} 
	}

	private void Attack() {
		Debug.Log ("I c u");
		Player player = GameObject.Find ("Brothers").GetComponent<Player> ();
		player.TakeDamage(damagePower);
	}

	public void gethit() {
		health = health - 50;
	}
}
