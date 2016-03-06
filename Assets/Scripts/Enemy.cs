using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

    public Sprite poof;
	public GameObject papel;
    private int damagePower = 2;
    private int health = 100;
    private int rand;
    private bool alive = true, dead = false, followPath = false;
	private float distance,
				  moveSpeed;
	private GameObject oldBrother;
	private Vector2 direction;
    private Vector2 ancientDirection;
    private List<Vector2> smallGraph = new List<Vector2>();
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
		moveSpeed = 5f;
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
            int rnd = Random.Range(1, 10);
            if (rnd == 9)
            {
                GameObject patate = Instantiate(papel);
                patate.transform.position = transform.position;
            }
            anim.SetInteger("Dir", 5);
            StartCoroutine(EnemyDie());
        }
        else if (health > 0)
        {
            anim.SetInteger("Dir", potato);
            distance = Mathf.Sqrt(Mathf.Abs(oldBrother.transform.position.x - this.transform.position.x) + Mathf.Abs(oldBrother.transform.position.y - this.transform.position.y));

            if (this.tag == "prof" && !followPath)
                StartCoroutine(pathFinder());

            else if (distance > 3)
                direction = wander();

            if (distance < 3 && distance > 1)
                direction = normalize(oldBrother.transform.position.x - this.transform.position.x, oldBrother.transform.position.y - this.transform.position.y);

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
        smallGraph.Add(new Vector2(-36, 80)); 
        smallGraph.Add(new Vector2(-36, -28));
        smallGraph.Add(new Vector2(41, 80)); 
        smallGraph.Add(new Vector2(41, -32));
        smallGraph.Add(new Vector2(2, 18));
        smallGraph.Add(new Vector2(2, -3));
        smallGraph.Add(new Vector2(-12, -3));
        smallGraph.Add(new Vector2(-28, -17));
    }

    IEnumerator EnemyDie()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    IEnumerator pathFinder()
    {
        followPath = true;
        int j = 0;

        while(j < 5)
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
    }
}
