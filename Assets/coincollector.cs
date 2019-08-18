using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coincollector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        Store.coin = Store.coin++;
    }

}
