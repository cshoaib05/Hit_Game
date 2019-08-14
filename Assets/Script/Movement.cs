using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rigid;
    private Vector3 _velocity, startpos,endpos,scndpos;
    Camera cam;
    LineRenderer lr;
    RaycastHit hit,objhit,scndhit;
    public static bool isMoving;

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
        if(GuiController.start && !isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {

                lr.enabled = true;
                startpos = transform.position;

                lr.SetPosition(0, startpos);
                lr.useWorldSpace = true;
            }

            if (Input.GetMouseButton(0))
            {
                if (Physics.Raycast(ray, out hit, 100))
                {
                    endpos = new Vector3(hit.point.x * -1f, transform.position.y, hit.point.z * -1f);
                }
            }


            if (Input.GetMouseButtonUp(0))
            {
               
                lr.enabled = false;
            }


        }

    }



    private void Update()
    {
        if (GuiController.start && !isMoving)
        {
            Ray objray = new Ray(transform.position, endpos);

            if (Physics.Raycast(objray, out objhit, 100))
            {
                Vector3 scnd = new Vector3(objhit.point.x, transform.position.y, objhit.point.z);
                lr.SetPosition(1, scnd);

                scndpos = Vector3.Reflect(endpos, objhit.normal);

                Ray thrdray = new Ray(scnd, scndpos);

                if (Physics.Raycast(thrdray, out scndhit, 100))
                {
                    Vector3 thrd = new Vector3(scndhit.point.x, transform.position.y, scndhit.point.z);
                    lr.SetPosition(2, thrd);
                    thrd = Vector3.Reflect(scndpos, scndhit.normal);
                    lr.SetPosition(3, thrd);
                }
            }


            if (Input.GetMouseButtonUp(0))
            {
                _velocity = Vector3.Scale(endpos, new Vector3(10f, 1f, 10f));

                rigid.AddForce(_velocity, ForceMode.VelocityChange);
                isMoving = true;
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
}

