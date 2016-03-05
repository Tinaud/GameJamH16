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

        oldBrother = GameObject.Find("Brothers").GetComponentInChildren<Controller>().gameObject; //TEMP!!
        moveSpeed = 4f;
        temp = 0;
        lr = gameObject.AddComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Additive"));
        //lr.SetColors(Color.white, Color.yellow);
        lineColor.a = 255;
        lineColor.b = 0;
        //lr = GetComponent<LineRenderer>();
        lineWidth = 0.2f;
        StartCoroutine(testLine());
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
            if (distance > 0 && distance < 2.5f)
            {
                lineColor.g = (byte)(distance * 100);
                lineColor.r = (byte)(250 - (distance * 100));
            }
                
            else if (distance > 2.5f && distance < 5)
            {
                lineColor.r = (byte)((distance - 2.5f) * 100);
                lineColor.g = (byte)(250 - ((distance - 2.5f) * 100));
            }
                
            else
                lineColor.r = 255;

            Color fuckingVraieCouleur = (Color)lineColor;
            lr.SetWidth(lineWidth, lineWidth);

            lr.SetColors(lineColor, lineColor);
            yield return new WaitForSeconds(0.05f);
        }
    }

	private void OnTriggerEnter2D (Collider2D patate)
	{
		if (patate.tag = "Wall") {

		} else if (patate.tag = "Zone") {

		} else if (patate.tag = "Answer") {

		}
	}
}
