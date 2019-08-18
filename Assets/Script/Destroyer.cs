using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject Scorepanel;
    public Camerashake camerashake;
    public ParticleSystem winparticle;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("obs"))
        {
            GuiController.score = GuiController.score + 100;
            Destroy(collision.gameObject);
            ObstacleControl.obscount--;
            if(ObstacleControl.obscount <=0)
            {
                LeveCreater.iscleared = true;
                StartCoroutine(Timeleft());
            }
        }

        if(collision.gameObject.CompareTag("Balloon") || collision.gameObject.CompareTag("jelly")|| collision.gameObject.CompareTag("bottle"))
        {
            GuiController.score = GuiController.score + 100;
            Destroy(collision.gameObject);
            ObstacleControl.obscount--;
            if (ObstacleControl.obscount <= 0)
            {
                LeveCreater.iscleared = true;
                StartCoroutine(Timeleft());
            }
        }
    }

  
    

    IEnumerator Timeleft()
    {
        if (!Materialscontroller.isplyaed)
        {
            winparticle.Play();
            Materialscontroller.isplyaed = true;
        }
     
        camerashake.Shake();
        yield return new WaitForSeconds(3);
        Scorepanel.SetActive(true);
     
    }

}
