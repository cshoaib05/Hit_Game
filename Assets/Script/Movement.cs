using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rigid;
    private Vector3 _velocity, startpos,endpos;
    Camera cam;
    LineRenderer lr;
    RaycastHit hit;

    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        cam = Camera.main;
    }




    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            _velocity = new Vector3(10f, 0f, 0f);
            rigid.AddForce(_velocity, ForceMode.VelocityChange);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("coll"))
        {
            ReflectProjectile(rigid,collision.GetContact(0).normal);   
        }
    }

    private void ReflectProjectile(Rigidbody rb, Vector3 reflectVector)
    {
             reflectVector = reflectVector - new Vector3(0.1f,0f,0.1f);
            _velocity = Vector3.Reflect(_velocity, reflectVector);
            rigid.velocity = _velocity;
    }







    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 500, Color.black);

        if (Input.GetMouseButtonDown(0))
        {
         
            lr.enabled = true;
            startpos = transform.position;
            
            lr.SetPosition(0, startpos);
            lr.useWorldSpace = true;
        }


        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit,100))
            {
                endpos = new Vector3(hit.point.x*-1f, transform.position.y, hit.point.z*-1f);
               
                lr.SetPosition(1, endpos);

                lr.SetPosition(2, new Vector3(5, 0, 5));
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
            lr.enabled = false;
        }
    }
}

