using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rigid;
    private Vector3 _velocity, prevpos, startpos, endpos,force,nextpos, directionnext;
    Camera cam;
    LineRenderer lr;
    Ray ray1;
    Plane plane;
    public static bool isMoving;
    int index;
    float distance = 0;
    void Start()
    {
        prevpos = new Vector3(0, 0, 0);
        isMoving = false;
        rigid = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        cam = Camera.main;
    }



    private void FixedUpdate()
    {

        startpos = transform.position;
        if (GuiController.start && !isMoving)
        { 
            if (Input.GetMouseButtonDown(0))
            {
                 ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
                plane = new Plane(Vector3.up, transform.position);

                if (plane.Raycast(ray1, out distance))
                {
                    prevpos = ray1.GetPoint(distance);
                    prevpos.y = transform.position.y;
                }
                 
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
                    force = new Vector3(startpos.x * -1f, transform.position.y, startpos.z * -1f) + prevpos;
                    lr.SetPosition(1, force);
                }
            }

                
            if (Input.GetMouseButtonUp(0))
            {
                rigid.constraints = RigidbodyConstraints.FreezePositionY;

                _velocity = Vector3.Scale(force, new Vector3(10f, 1f, 10f));
                rigid.AddForce(_velocity, ForceMode.VelocityChange);
                lr.enabled = false;
                StartCoroutine(waitforsec());
            }
        }
    }

    IEnumerator waitforsec()
    {
        yield return new WaitForSeconds(5);
        isMoving = false;
       
        rigid.Sleep();
    }

}