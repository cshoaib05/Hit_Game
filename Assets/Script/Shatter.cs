using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject shatter;
    public GameObject Ballon;
    public GameObject Bottle;
    public GameObject Jelly;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Balloon"))
        {
            collision.gameObject.SetActive(false);
            shatter = Instantiate(Ballon, transform.position, transform.rotation);
            Destroy(shatter, 2);
        }

        if (collision.gameObject.CompareTag("jelly"))
        {
            collision.gameObject.SetActive(false);
            shatter = Instantiate(Jelly, transform.position, transform.rotation);
            Destroy(shatter, 2);
        }
        if (collision.gameObject.CompareTag("bottle"))
        {
            collision.gameObject.SetActive(false);
            shatter= Instantiate(Bottle, transform.position, transform.rotation);
            Destroy(shatter, 2);
        }

    }
}
