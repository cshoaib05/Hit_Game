using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject Scorepanel;
    public Camerashake camerashake;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("obs"))
        {
            Destroy(collision.gameObject);
            ObstacleControl.obscount--;
            if(ObstacleControl.obscount <=0)
            {
                LeveCreater.iscleared = true;
                StartCoroutine(Timeleft());
            }
        }
    }

  

    IEnumerator Timeleft()
    {
        camerashake.Shake();
        yield return new WaitForSeconds(3);
        Scorepanel.SetActive(true);
     
    }
}
