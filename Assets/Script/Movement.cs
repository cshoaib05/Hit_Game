using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rigid;
    private Vector3 _velocity, startpos, endpos,force,first,second,thrd,frth,nextpos, directionnext;
    Camera cam;
    LineRenderer lr;
    RaycastHit hit, objhit;
    RaycastHit colhit;
    public static bool isMoving;
    int index;
    float distance = 0;
    void Start()
    {
       
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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                lr.enabled = true;
                lr.SetPosition(0, startpos);
                lr.useWorldSpace = true;
            }


            if (Input.GetMouseButton(0))
            {
                Ray ray1 = Camera.main.ScreenPointToRay(Input.mousePosition);
                Plane plane = new Plane(Vector3.up, transform.position);
                if (plane.Raycast(ray1, out distance))
                {
                    startpos = ray1.GetPoint(distance);
                    force = new Vector3(startpos.x * -1f, transform.position.y, startpos.z * -1f);
                }

                first = Drawline(transform.position, force);
                lr.SetPosition(1, first);
                second = Drawline(first, directionnext);
                lr.SetPosition(2, second);
                thrd = Drawline(second, directionnext);
                lr.SetPosition(3, thrd);
            }

                
            if (Input.GetMouseButtonUp(0))
            {
                _velocity = Vector3.Scale(force, new Vector3(10f, 1f, 10f));
                rigid.AddForce(_velocity, ForceMode.VelocityChange);
                isMoving = true;
                endpos = new Vector3(0, 0, 0);
                lr.enabled = false;
                StartCoroutine(waitforsec());
            }
        }
        StartCoroutine(checkmovement());

    }

    IEnumerator checkmovement()
    {
        Vector3 pos = transform.position;
        yield return new WaitForSeconds(1);
        if (pos == transform.position)
        {
            transform.position = new Vector3(0, transform.position.y, 0);
            isMoving = false;
        }
    }

    IEnumerator waitforsec()
    {
        yield return new WaitForSeconds(5);
        transform.position = new Vector3(0, transform.position.y, 0);
        rigid.Sleep();
    }

    public Vector3 Drawline(Vector3 origin, Vector3 direction)
    {
        Ray objray = new Ray(origin, direction);

        if (Physics.Raycast(objray, out colhit,200))
        {
            nextpos = new Vector3(colhit.point.x, transform.position.y, colhit.point.z);

        }
         directionnext = Vector3.Reflect(nextpos.normalized, colhit.normal);

        return nextpos;
    }
}