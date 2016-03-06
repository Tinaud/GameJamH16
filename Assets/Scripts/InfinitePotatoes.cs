using UnityEngine;
using System.Collections;

public class InfinitePotatoes : MonoBehaviour
{
    int patate = 0;
    GameObject InstObject, InstObject2;
    Vector3 pos1, pos2;
    

    void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    void FixedUpdate()
    {

    }


    IEnumerator MyCoroutine()
    {
        pos1.x = -60;
        pos1.y = Random.Range(-10, -15);
        pos1.z = 0;
        pos2.x = -20;
        pos2.y = Random.Range(-10, -15);
        pos2.z = 0;

        InstObject = (GameObject)Instantiate(Resources.Load("Patate"), pos1, Quaternion.identity);
        InstObject2 = (GameObject)Instantiate(Resources.Load("Patate2"), pos2, Quaternion.identity);

        InstObject.transform.parent = Camera.main.transform;
        InstObject2.transform.parent = Camera.main.transform;

        if (patate < 15)
        {
            yield return new WaitForSeconds(0.5F);
            StartCoroutine(MyCoroutine());
        }

        yield return new WaitForSeconds(1F);
        Destroy(Camera.main.GetComponentInChildren<MouvementPatate1>().gameObject);
        Destroy(Camera.main.GetComponentInChildren<MouvementPatate2>().gameObject);
        patate++;

        if(patate >= 15)
        {
            Destroy(Camera.main.GetComponentInChildren<MouvementPatate1>().gameObject);
            Destroy(Camera.main.GetComponentInChildren<MouvementPatate2>().gameObject);
        }
    }
}
