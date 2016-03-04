using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour 
{
    private float moveSpeed;

	void Start() 
    {
        moveSpeed = 5f;

	}

	void Update() 
    {
        transform.Translate(Vector2.right * moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        transform.Translate(Vector3.down * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime); 
	}
}
