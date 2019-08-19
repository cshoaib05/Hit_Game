using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsFlight : MonoBehaviour
{
    public Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            rigidbody.AddForce(rigidbody.velocity.x, 50, rigidbody.velocity.z);
        }
       
    }

}
