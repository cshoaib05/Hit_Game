﻿using System.Collections;
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
            shatter = Instantiate(Ballon, transform.position, transform.rotation);
            Destroyobj();   
        }

        if (collision.gameObject.CompareTag("jelly"))
        {
            ObstacleControl.obscount--;
            Destroy(collision.gameObject);
            shatter = Instantiate(Jelly, transform.position, transform.rotation);
            Destroyobj();
        }


        if (collision.gameObject.CompareTag("bottle"))
        {
            ObstacleControl.obscount--;
            Destroy(collision.gameObject);
 
            shatter = Instantiate(Bottle, transform.position, transform.rotation);
            Destroyobj();
        }

    }

    public void Destroyobj()
    {
        Destroy(shatter, 1);        
    }
    //    Pull to aim and shoot
    //   next level

}
