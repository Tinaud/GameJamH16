using UnityEngine;
using System.Collections;

public class Professor : MonoBehaviour
{
    private float moveSpeed;
    private GameObject youngBrother;
    private Vector2 direction;

    void Start()
    {
        youngBrother = GameObject.Find("Brothers").GetComponentInChildren<Controller>().gameObject;
        moveSpeed = 4.5f;
    }

    void Update()
    {
        direction = normalize(youngBrother.transform.position.x - this.transform.position.x, youngBrother.transform.position.y - this.transform.position.y);
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    Vector2 normalize(float x, float y)
    {
        float length = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
        Vector2 temp;

        temp.x = x / length;
        temp.y = y / length;

        return temp;
    }
}
