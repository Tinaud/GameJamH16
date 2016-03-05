using UnityEngine;
using System.Collections;

public class Professor : MonoBehaviour
{
    private float distance,
                  moveSpeed;
    private GameObject oldBrother;
    private Vector2 direction;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    Player player;
    private int damage;

    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        oldBrother = GameObject.Find("Brothers").GetComponentInChildren<Controller>().gameObject;
        moveSpeed = 3f;
        damage = 100;
    }

    void Update()
    {
        distance = getDistance();
        if(distance < 3 && distance > 1)
        {
            direction = normalize(oldBrother.transform.position.x - this.transform.position.x, oldBrother.transform.position.y - this.transform.position.y);
            transform.Translate(direction * moveSpeed * Time.deltaTime);
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
            hitPlayer();
    }

    public void hitPlayer()
    {
        player.Health -= damage;
    }
}
