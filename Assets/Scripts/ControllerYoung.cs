using UnityEngine;
using System.Collections;

public class ControllerYoung : MonoBehaviour
{
    private Color32 lineColor;
    private float distance,
                  lineWidth,
                  moveSpeed;
    private GameObject oldBrother;
    private int temp;
    private LineRenderer lr;

	private Animator animator;
	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D;

    void Start()
    {
		animator = GetComponent<Animator>();
		boxCollider = GetComponent <BoxCollider2D> ();
		rb2D = GetComponent <Rigidbody2D> ();

		oldBrother = GetComponentInParent<Player>().GetComponentInChildren<Controller>().gameObject; //TEMP!!
        moveSpeed = 4f;
        temp = 0;
        lr = GetComponent<LineRenderer>();
        lineColor.a = 150;
        lineColor.b = 0;
        lineWidth = 0.2f;
        StartCoroutine(testLine());
    }

    void Update()
    {
        distance = getDistance();
        if (distance < 4)
        {
            transform.Translate(Vector2.right * moveSpeed * Input.GetAxis("HorizontalYoung") * Time.deltaTime);
            transform.Translate(Vector3.down * moveSpeed * Input.GetAxis("VerticalYoung") * Time.deltaTime);
        }
        else
        {
            Debug.Log("CRY");
        }

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
            if (distance > 0 && distance < 2)
            {
                lineColor.r = (byte)(250 - (distance * 125));
                lineColor.g = (byte)(distance * 125);
            }
                
            else if (distance > 2 && distance < 4)
            {
                lineColor.r = (byte)((distance - 2) * 125);
                lineColor.g = (byte)(250 - ((distance - 2) * 125));
            }
                
            else
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

		}
	}
}
