using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerashake : MonoBehaviour
{

    public Transform camTransform;

     float shakeDuration = 0f;

    float shakeAmount = 0.05f;
    float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        originalPos = transform.position;
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    public void Shake()
    {
        shakeDuration = 0.2f;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }

        if(LeveCreater.iscleared)
        {
            Shake();
        }
    }
}
