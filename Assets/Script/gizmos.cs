using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gizmos : MonoBehaviour
{

    public int maxReflectionCount = 4;
    public float maxStepDistance = 200;
    LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, transform.position);
    }

    private void FixedUpdate()
    {
        
        DrawPredictedReflectionPattern(this.transform.position + this.transform.forward, this.transform.forward, maxReflectionCount);
    }


    private void DrawPredictedReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {

        if (reflectionsRemaining == 0)
        {
            return;
        }

        Vector3 startingPosition = position;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        print(ray);
        //        Ray ray = new Ray(position, direction);
        //Debug.DrawRay(position, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxStepDistance))
        {
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;
            lr.useWorldSpace = true;
          
            lr.SetPosition(1, position);
        }
        else
        {
            position += direction * maxStepDistance;
        }
        DrawPredictedReflectionPattern(position, direction, reflectionsRemaining - 1);
    }
}
