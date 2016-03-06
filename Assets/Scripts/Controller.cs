using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour 
{
    public Sprite[] sister;
    private bool hitted;
    private float moveSpeed,
                  movementH,
                  movementV;

	private Animator anim;
	private BoxCollider2D boxCollider;
    private GameObject instanciatedObject,
                       youngBrother;
	private Rigidbody2D rb2D;
    private SpriteRenderer sr;
    private Vector3 PunchPos;

    private int patate;

	void Start() 
    {
		anim = GetComponent<Animator>();
        anim.SetLayerWeight(0, 1f);
		boxCollider = GetComponent <BoxCollider2D> ();
        youngBrother = GameObject.Find("Brothers").GetComponentInChildren<ControllerYoung>().gameObject;
		rb2D = GetComponent <Rigidbody2D> ();
        sr = GetComponent<SpriteRenderer>();
        hitted = false;
        moveSpeed = 6f;
	}

    void Update()
    {
        movementH = Input.GetAxis("Horizontal");
        movementV = Input.GetAxis("Vertical");
        transform.Translate(Vector2.right * moveSpeed * movementH * Time.deltaTime);
        transform.Translate(Vector3.down * moveSpeed * movementV * Time.deltaTime);
        anim.SetInteger("Dir", patate);

        if (Mathf.Abs(movementV) < 0.75f)
        {
            if (movementH < 0)
            {
                patate = 4;
                PunchPos = new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z);
            }
            else if (movementH > 0)
            {
                patate = 3;
                PunchPos = new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (movementV > 0)
            {
                patate = 2;
                PunchPos = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
            }
            else
            {
                patate = 1;
                PunchPos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
            }
        }
        if (movementH == 0 && movementV == 0)
            patate = 0;
                

        if (Input.GetAxis("attack1") != 0 && !hitted)
        {
            instanciatedObject = (GameObject)Instantiate(Resources.Load("PunchZone"), PunchPos, Quaternion.identity);
            instanciatedObject.transform.parent = transform.parent;
            hitted = true;
			GameObject.Find ("attack").GetComponent<AudioSource> ().Play ();
            Debug.Log("BAM");
        }

        if (Mathf.Abs(Input.GetAxis("attack1")) < 0.1f)
            hitted = false;

    }

    float getDistance()
    {
        return Mathf.Sqrt(Mathf.Abs(youngBrother.transform.position.x - this.transform.position.x) + Mathf.Abs(youngBrother.transform.position.y - this.transform.position.y));
    }

	private void OnTriggerEnter2D (Collider2D patate)
	{
		if (patate.tag == "Zone") {
			Debug.Log ("Entering " + patate.name);
			patate.GetComponent<Room> ().ControllersInside++;
		} else if (patate.tag == "Apple") {
			Debug.Log ("Pomme");
			Player player = GameObject.Find("Brothers").GetComponent<Player>();
			player.Health += 10; 
			Destroy (patate.gameObject);
		}
	}


	private void OnTriggerExit2D (Collider2D patate)
	{
		if (patate.tag == "Zone") {
			Debug.Log ("Exiting " + patate.name);
			patate.GetComponent<Room> ().ControllersInside--;
		}
	}

    public void attack(GameObject enemy)
    {
        Enemy hittedGuy = GetComponent<Enemy>();
        StartCoroutine(EnemyDie(enemy));
    }

    IEnumerator EnemyDie(GameObject enemy)
    {
        Debug.Log("blebleble");
        
        yield return new WaitForSeconds(1f);
        Destroy(enemy);
    }
}
