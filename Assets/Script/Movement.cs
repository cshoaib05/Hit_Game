using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rigid;
    public static Vector3 playerepos;
    private Vector3 _velocity, startpos, force, firsttouch,scndtouch,ogpos;
    LineRenderer lr;
    Ray ray1;
    Plane plane;
    RaycastHit hit;
    public static bool isMoving;
    int index;
    float distance = 0;
   public static bool done;

    void Start()
    {
        done = false;
        isMoving = false;
        rigid = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("obs"))
        {
            Handheld.Vibrate();
        }
    }

    private void FixedUpdate()
    {
        playerepos = transform.position;
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
                rigid.constraints = RigidbodyConstraints.FreezePositionY| RigidbodyConstraints.FreezeRotation;
                
                rigid.AddForce(_velocity, ForceMode.VelocityChange);
                lr.enabled = false;
                isMoving = true;
                        
            }
        }
        StartCoroutine(waitforsec());
    }

    IEnumerator waitforsec()
    {
        Vector3 beg = transform.position;
        yield return new WaitForSeconds(1);
        if(rigid.IsSleeping() || beg == transform.position)
        {
            isMoving = false;
        }
    }






    private void Update()
    {
        if(LeveCreater.iscleared )
        {
            if(Store.inuseindex!=0)
            {
                if (Store.inuseindex % 2 != 0 && !done)
                {
                    rigid.Sleep();
                    transform.position = new Vector3(transform.position.x, 1, transform.position.z);
                    rigid.constraints = RigidbodyConstraints.None;
                    done = true;
                }
                else
                {
                    if (!done)
                    {
                        gameObject.SetActive(false);
                        done = true;
                    }
                }

            }
            else
            {
                if (!done)
                {
                    gameObject.SetActive(false);
                    done = true;
                }
            }
            
        }
    }
}