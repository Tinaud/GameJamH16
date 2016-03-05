using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour 
{
    private float moveSpeed;

	private Animator animator;
	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;

	void Start() 
    {
		animator = GetComponent<Animator>();
		boxCollider = GetComponent <BoxCollider2D> ();
		rb2D = GetComponent <Rigidbody2D> ();

        moveSpeed = 5f;
	}

	void Update() 
    {
        transform.Translate(Vector2.right * moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        transform.Translate(Vector3.down * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);    
	}

	private void OnTriggerEnter2D (Collider2D patate)
	{
		if (patate.tag = "Wall") {

		} else if (patate.tag = "Zone") {
			
		}
	}
}
