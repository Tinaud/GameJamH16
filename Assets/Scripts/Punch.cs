using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour 
{
    private Controller cont;

	void Start () 
    {
        cont = GetComponentInParent<Player>().gameObject.GetComponentInChildren<Controller>();
        StartCoroutine(PunchLifeTime());
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name != "Girl" && other.name != "Boy")
            cont.attack(other.gameObject);
    }

    IEnumerator PunchLifeTime()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}
