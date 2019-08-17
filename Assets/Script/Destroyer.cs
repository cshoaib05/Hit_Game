using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject Scorepanel;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("obs"))
        {
            Destroy(collision.gameObject);
            ObstacleControl.obscount--;
            if(ObstacleControl.obscount <=0)
            {
                LeveCreater.iscleared = true;
                Scorepanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    private void FixedUpdate()
    {
        if (ObstacleControl.obscount <= 0 && !LeveCreater.iscleared)
        {
            LeveCreater.iscleared = true;
            StartCoroutine(Timeleft());
        }
        if(ObstacleControl.obscount >=1)
        {
            LeveCreater.iscleared = false;
        }
    }


    IEnumerator Timeleft()
    {
        yield return new WaitForSeconds(3);
        Scorepanel.SetActive(true);
    }

}
