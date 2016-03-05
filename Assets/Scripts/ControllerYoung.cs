using UnityEngine;
using System.Collections;

public class ControllerYoung : MonoBehaviour
{
    public Sprite[] brother;
    private Color32 lineColor;
    private float distance,
                  lineWidth,
                  moveSpeed,
                  movementH,
                  movementV;
    private GameObject oldBrother;
    private int temp;
    private LineRenderer lr;

	private Animator animator;
	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;
    private SpriteRenderer sr;

    void Start()
    {
		animator = GetComponent<Animator>();
		boxCollider = GetComponent <BoxCollider2D> ();
		rb2D = GetComponent <Rigidbody2D> ();
        sr = GetComponent<SpriteRenderer>();

        oldBrother = GameObject.Find("Brothers").GetComponentInChildren<Controller>().gameObject; //TEMP!!
        moveSpeed = 4f;
        temp = 0;
        lr = GetComponent<LineRenderer>();
        lineColor.a = 0;
        lineColor.b = 0;
        lineWidth = 0.2f;
        StartCoroutine(testLine());
    }

    void Update()
    {
        distance = getDistance();
        if (distance < 4)
        {
            movementH = Input.GetAxis("HorizontalYoung");
            movementV = Input.GetAxis("VerticalYoung");
            transform.Translate(Vector2.right * moveSpeed * Input.GetAxis("HorizontalYoung") * Time.deltaTime);
            transform.Translate(Vector3.down * moveSpeed * Input.GetAxis("VerticalYoung") * Time.deltaTime);
        }
        else
        {
            Debug.Log("CRY");
        }

        if (Mathf.Abs(movementV) < 0.75f)
        {
            if (movementH < 0)
                sr.sprite = brother[2];
            else if (movementH > 0)
                sr.sprite = brother[3];
        }
        else
            if (movementV > 0)
                sr.sprite = brother[0];
            else
                sr.sprite = brother[1];

        lr.SetPosition(0, this.transform.position);
        lr.SetPosition(1, oldBrother.transform.position);
    }

    float getDistance()
    {
        return Mathf.Sqrt(Mathf.Abs(oldBrother.transform.position.x - this.transform.position.x) + Mathf.Abs(oldBrother.transform.position.y - this.transform.position.y));
    }

    IEnumerator testLine()
    {
        while(true)
        {
            if (temp % 6 < 3)
                lineWidth += 0.02f;
            else
                lineWidth -= 0.02f;
            temp++;

            if (distance > 0 && distance < 3)
                lineColor.a = 0;
            else if (distance > 3 && distance < 4)
                lineColor.a = (byte)((distance - 3) * 230);
            
            lineColor.r = 255;

            lr.SetWidth(lineWidth, lineWidth);

            lr.SetColors(lineColor, lineColor);
            yield return new WaitForSeconds(0.05f);
        }
    }

	private void OnTriggerEnter2D (Collider2D patate)
	{
		if (patate.tag == "Wall") {

		} else if (patate.tag == "Zone") {

		} else if (patate.tag == "Note") {
			Debug.Log ("Note");
			Player player = GameObject.Find("Brothers").GetComponent<Player>();
			player.Note++; 
			Destroy (patate.gameObject);
		} else if (patate.tag == "Apple") {
			Debug.Log ("Pomme");
			Player player = GameObject.Find("Brothers").GetComponent<Player>();
			player.Health += 10; 
			Destroy (patate.gameObject);
		}
	}
}
