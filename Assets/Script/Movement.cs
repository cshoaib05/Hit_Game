using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rigid;
    private Vector3 _velocity, startpos, force, firsttouch,scndtouch,ogpos;
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
                    scndtouch = ray1.GetPoint(distance);
                    firsttouch = transform.position;
                    ogpos = scndtouch - firsttouch;
                   force = new Vector3( ogpos.x* -1f, transform.position.y,ogpos.z * -1f);

                }
                _velocity = Vector3.Scale(force, new Vector3(10f, 1f, 10f));
                lr.SetPosition(1, _velocity);
            }


            if (Input.GetMouseButtonUp(0))
            {
                rigid.constraints = RigidbodyConstraints.FreezePositionY;
                rigid.AddForce(_velocity, ForceMode.VelocityChange);
                lr.enabled = false;
                isMoving = true;
               
            }
        }
        StartCoroutine(waitforsec());
    }

    IEnumerator waitforsec()
    {
        
        yield return new WaitForSeconds(1);
        if(rigid.IsSleeping())
        {
            isMoving = false;
            rigid.constraints = RigidbodyConstraints.None;
        }
    }

}