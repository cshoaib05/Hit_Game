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
            Destroy(collision.gameObject);
            shatter = Instantiate(Ballon, transform.position, transform.rotation);
            Destroy(shatter, 2);
        }

        if (collision.gameObject.CompareTag("jelly"))
        {
            Destroy(collision.gameObject);
            shatter = Instantiate(Jelly, transform.position, transform.rotation);
            Destroy(shatter, 2);
        }
        if (collision.gameObject.CompareTag("bottle"))
        {
            Destroy(collision.gameObject);
            shatter = Instantiate(Bottle, transform.position, transform.rotation);
            Destroy(shatter, 2);
        }

    }
//    Pull to aim and shoot
//   next level

}
