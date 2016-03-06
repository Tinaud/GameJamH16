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

	private Animator anim;
    private int potato;

    void Awake()
	{
        anim = GetComponent<Animator>();
        anim.SetLayerWeight(0, 1f);
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

    public void setCharacterHealth(int patateD)
    {
        health = patateD;
    }
    
	void Update () {

        anim.SetInteger("Dir", potato);

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

        if (distance > 3)
            potato = 0;

        if (distance < 3 && distance > 1)
		{
			direction = normalize(oldBrother.transform.position.x - this.transform.position.x, oldBrother.transform.position.y - this.transform.position.y);
			transform.Translate(direction * moveSpeed * Time.deltaTime);

            if (Mathf.Abs(direction.y) < 0.75f)
            {
                if (direction.x < 0)
                {
                    potato = 4;
                }
                else if (direction.x > 0)
                {
                    potato = 3;
                }
            }
            else
            {
                if (direction.y > 0)
                {
                    potato = 1;
                }
                else
                {
                    potato = 2;
                }
            }
            if (direction.x == 0 && direction.y == 0)
                potato = 0;
            /*
            if (direction.y < 0)
                sr.sprite = choosenEnemy[0];
            else
                sr.sprite = choosenEnemy[1];*/
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

	private void OnCollisionStay2D (Collision2D patateX)
	{
		timer += Time.deltaTime/5;
		if (patateX.gameObject.tag == "Player" && timer >= timeBetweenAttacks) {
			Attack();
			patate.gameObject.GetComponent<AudioSource>().Play ();
			timer = 0;
		} 
	}

	private void Attack() {
		Debug.Log ("I c u");
		GameObject.Find ("attack").GetComponent<AudioSource> ().Play ();
		Player player = GameObject.Find ("Brothers").GetComponent<Player> ();
		player.TakeDamage(damagePower);
	}

	public void gethit() {
		health = health - 50;
	}
}
