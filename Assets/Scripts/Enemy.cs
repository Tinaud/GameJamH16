using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
    public static bool potatoFight = false;

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
    private bool alive = true, dead = false, followPath = false;
	private float distance,
				  moveSpeed;
	private GameObject oldBrother;
	private Vector2 direction;
    private Vector2 ancientDirection;
    private List<Vector2> graph12 = new List<Vector2>();
    private List<Vector2> graph10 = new List<Vector2>();
    private SpriteRenderer sr;
	bool playerInRange;
	float timer;
	public float timeBetweenAttacks = .1f;

	private Animator anim;
    private int potato;

    void Awake()
	{
        ancientDirection = new Vector2(0, 1);
        anim = GetComponent<Animator>();
        anim.SetLayerWeight(0, 1f);
        oldBrother = GameObject.Find("Brothers").GetComponentInChildren<Controller>().gameObject;
        sr = GetComponent<SpriteRenderer>();
		moveSpeed = 6f;
        buildGraph();
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
        else if (health > 0 && this.name != "Pablo")
        {
            anim.SetInteger("Dir", potato);
            distance = Mathf.Sqrt(Mathf.Abs(oldBrother.transform.position.x - this.transform.position.x) + Mathf.Abs(oldBrother.transform.position.y - this.transform.position.y));

            if (this.tag == "Prof")
            {
                if (!followPath)
                    StartCoroutine(pathFinder());
            }
            else
            {
                if (distance > 3)
                    direction = wander();

                if (distance < 3 && distance > 1)
                    direction = normalize(oldBrother.transform.position.x - this.transform.position.x, oldBrother.transform.position.y - this.transform.position.y);
            }

            transform.Translate(direction * moveSpeed * Time.deltaTime);

            if (Mathf.Abs(direction.y) < 0.75f)
            {
                if (direction.x < 0)
                    potato = 4;
                else if (direction.x > 0)
                    potato = 3;
            }
            else
            {
                if (direction.y > 0)
                    potato = 1;
                else
                    potato = 2;
            }
            if (direction.x == 0 && direction.y == 0)
                potato = 0;

            ancientDirection = direction;

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

    Vector2 wander()
    {
        direction.x = ancientDirection.x + Random.Range(-0.2f, 0.2f);
        direction.y = ancientDirection.y + Random.Range(-0.2f, 0.2f);

        return normalize(direction.x, direction.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Walls" || other.gameObject.tag == "Enemy")
        {
            ancientDirection.x *= -1;
            ancientDirection.y *= -1;
        }
    }

    void buildGraph()
    {
        graph10.Add(new Vector2(-36, 80));
        graph10.Add(new Vector2(-36, 58));
        graph10.Add(new Vector2(-15, 58));
        graph10.Add(new Vector2(21, 58));
        graph10.Add(new Vector2(41, 80));
        graph10.Add(new Vector2(41, 58));

        graph12.Add(new Vector2(-36, 80));
        graph12.Add(new Vector2(-36, 20));
        graph12.Add(new Vector2(-36, -28));
        graph12.Add(new Vector2(41, 80));
        graph12.Add(new Vector2(41, 20));
        graph12.Add(new Vector2(41, -32));
        graph12.Add(new Vector2(2, 18));
        graph12.Add(new Vector2(2, -1));
        graph12.Add(new Vector2(-12, -1));
        graph12.Add(new Vector2(-28, -17));
    }

    IEnumerator EnemyDie()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    IEnumerator pathFinder()
    {
        List<Vector2> smallGraph = new List<Vector2>();

        if (GameManager.instance.timer.Hours == 12)
            foreach (Vector2 element in graph12)
                smallGraph.Add(element);
        else if (GameManager.instance.timer.Hours == 10)
            foreach (Vector2 element in graph10)
                smallGraph.Add(element);

        followPath = true;
        int j = 0;

        while(j < smallGraph.Count)
        {
            float closestDist = 1000;
            int closestID = 0, i = 0;

            foreach (Vector2 coord in smallGraph)
            {
                float dist = Mathf.Sqrt(Mathf.Abs(coord.x - this.transform.position.x) + Mathf.Abs(coord.y - this.transform.position.y));
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closestID = i;
                }
                i++;
            }
            j++;

            float distTest = 20;
            while(distTest > 2)
            {
                direction = normalize(smallGraph[closestID].x - this.transform.position.x, smallGraph[closestID].y - this.transform.position.y);
                distTest = Mathf.Sqrt(Mathf.Abs(smallGraph[closestID].x - this.transform.position.x) + Mathf.Abs(smallGraph[closestID].y - this.transform.position.y));
                yield return new WaitForSeconds(0.3f);
            }   
            smallGraph.RemoveAt(closestID);
        }
        followPath = false;
        this.tag = "Enemy";
        if (GameManager.instance.timer.Hours >= 12 && !potatoFight)
        {
            potatoFight = true;
            Instantiate(Resources.Load("FoodFight"), new Vector3(-30, -11, transform.position.z), Quaternion.identity);
        }  
    }
}
