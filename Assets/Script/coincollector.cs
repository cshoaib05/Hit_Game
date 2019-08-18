using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coincollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        Store.coin++;
    }

}
