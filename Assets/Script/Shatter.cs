using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject shatter;
    public GameObject Ballon;
    public GameObject Bottle;
    public GameObject Jelly;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Instantiate(shatter, transform.position, transform.rotation);
            StartCoroutine(destroyobj());
        }
    }

    IEnumerator destroyobj()
    {
        
        yield return new WaitForSeconds(2);
    }
}
