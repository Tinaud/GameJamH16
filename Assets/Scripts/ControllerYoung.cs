using UnityEngine;
using System.Collections;

public class ControllerYoung : MonoBehaviour
{
    private float distance,
                  moveSpeed;
    private GameObject oldBrother;

    void Start()
    {
        oldBrother = GameObject.Find("Brothers").GetComponentInChildren<Controller>().gameObject; //TEMP!!
        moveSpeed = 4f;
    }

    void Update()
    {
        distance = getDistance();

        if (distance < 3)
        {
            transform.Translate(Vector2.right * moveSpeed * Input.GetAxis("HorizontalYoung") * Time.deltaTime);
            transform.Translate(Vector3.down * moveSpeed * Input.GetAxis("VerticalYoung") * Time.deltaTime);
        }
        else
        {
            Debug.Log("CRY");
        } 
    }

    float getDistance()
    {
        return Mathf.Sqrt(Mathf.Abs(oldBrother.transform.position.x - this.transform.position.x) + Mathf.Abs(oldBrother.transform.position.y - this.transform.position.y));
    }
}
