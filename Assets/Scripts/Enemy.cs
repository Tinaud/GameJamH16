using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Sprite poof;
	public GameObject papel;
	private int damagePower = 2;

	public int DamagePower {
		get {
			return damagePower;
		}
		set {
			damagePower = value;
		}
	}

    private int health = 100;
    private int rand;
    private bool alive = true, dead = false;
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
        //Debug.Log(health);
        
        if (health <= 0 && !dead)
        {
            dead = true;
            int rnd = Random.Range(1, 5);
            if (rnd == 1)
            {
                GameObject patate = Instantiate(papel);
                patate.transform.position = transform.position;
            }
            anim.SetInteger("Dir", 5);
            StartCoroutine(EnemyDie());
        }
        else if(health > 0 && this.name != "Pablo")
        {
            //Debug.Log("patate");
            anim.SetInteger("Dir", potato);
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
            }
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
			patateX.gameObject.GetComponent<AudioSource>().Play ();
			timer = 0;
		} 
	}

	private void Attack() {
		Debug.Log ("I c u");
		GameObject.Find ("attack").GetComponent<AudioSource> ().Play ();
		Player player = GameObject.Find ("Brothers").GetComponent<Player> ();
		Debug.Log ("DP :" + damagePower);
		player.TakeDamage(damagePower);
	}

	public void gethit() {
		health = health - 50;
	}

    IEnumerator EnemyDie()
    {
        Debug.Log("blebleble");
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
