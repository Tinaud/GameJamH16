using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour 
{
    public Sprite[] sister;
    private float moveSpeed,
                  movementH,
                  movementV;

	private Animator animator;
	private BoxCollider2D boxCollider;
    private GameObject youngBrother;
	private Rigidbody2D rb2D;
    private SpriteRenderer sr;

	void Start() 
    {
		animator = GetComponent<Animator>();
		boxCollider = GetComponent <BoxCollider2D> ();
        youngBrother = GameObject.Find("Brothers").GetComponentInChildren<ControllerYoung>().gameObject;
		rb2D = GetComponent <Rigidbody2D> ();
        sr = GetComponent<SpriteRenderer>();

        moveSpeed = 5f;
	}

    void Update()
    {
        movementH = Input.GetAxis("Horizontal");
        movementV = Input.GetAxis("Vertical");
        transform.Translate(Vector2.right * moveSpeed * movementH * Time.deltaTime);
        transform.Translate(Vector3.down * moveSpeed * movementV * Time.deltaTime);

        if (Mathf.Abs(movementV) < 0.75f)
        {
            if (movementH < 0)
                sr.sprite = sister[2];
            else if (movementH > 0)
                sr.sprite = sister[3];
        }
        else
            if (movementV > 0)
                sr.sprite = sister[0];
            else
                sr.sprite = sister[1];
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
}
