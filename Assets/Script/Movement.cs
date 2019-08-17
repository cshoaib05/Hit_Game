﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rigid;
    private Vector3 _velocity, startpos, endpos,force,nextpos, directionnext;
    LineRenderer lr;
    Ray ray1;
    Plane plane;
    RaycastHit hit;
    public static bool isMoving;
    int index;
    float distance = 0;

    void Start()
    {

        isMoving = false;
        rigid = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }



    private void FixedUpdate()
    {
        startpos = transform.position;

        if (GuiController.start && !isMoving)
        { 
            if (Input.GetMouseButtonDown(0))
            { 
                lr.enabled = true;
                lr.SetPosition(0, startpos);
                lr.useWorldSpace = true;
            }


            if (Input.GetMouseButton(0))
            {
                ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
                plane = new Plane(Vector3.up, transform.position);

                if (plane.Raycast(ray1, out distance))
                {
                    startpos = ray1.GetPoint(distance);
                    force = new Vector3(startpos.x * -1f, transform.position.y, startpos.z * -1f);
                  
                }
                Ray ray2 = new Ray(startpos, transform.position);
                if (Physics.Raycast(ray2,out hit ,1000))
                {
                    nextpos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                    lr.SetPosition(1, nextpos);
                }
            }

                
            if (Input.GetMouseButtonUp(0))
            {
               rigid.constraints = RigidbodyConstraints.FreezePositionY;

                _velocity = Vector3.Scale(force, new Vector3(10f, 1f, 10f));
                rigid.AddForce(_velocity, ForceMode.VelocityChange);
                lr.enabled = false;
                isMoving = true;
                StartCoroutine(waitforsec());
            }
        }

  
    }

    IEnumerator waitforsec()
    {
        
        yield return new WaitForSeconds(5);
        rigid.constraints = RigidbodyConstraints.None;
        isMoving = false;
        rigid.Sleep();
    }

}