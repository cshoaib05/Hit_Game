using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject shatter;
    public GameObject Ballon;
    public GameObject Bottle;
    public GameObject Jelly;
    public GameObject Scorepanel;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Balloon"))
        {
            ObstacleControl.obscount--;
            Destroy(collision.gameObject);
            shatter = Instantiate(Ballon, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroyobj();
            Handheld.Vibrate();
        }

        if (collision.gameObject.CompareTag("jelly"))
        {
            ObstacleControl.obscount--;
            Destroy(collision.gameObject);
            shatter = Instantiate(Jelly, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroyobj();
            Handheld.Vibrate();
        }


        if (collision.gameObject.CompareTag("bottle"))
        {
            ObstacleControl.obscount--;
            Destroy(collision.gameObject);
 
            shatter = Instantiate(Bottle, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroyobj();
            Handheld.Vibrate();
        }

    }

    public void Destroyobj()
    {
        Destroy(shatter, 1);        
    }
    //    Pull to aim and shoot
    //   next level

}
