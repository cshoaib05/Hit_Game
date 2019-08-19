using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Destroyer : MonoBehaviour
{
    public GameObject Scorepanel;
    public Camerashake camerashake;
    public ParticleSystem winparticle;
    public TextMeshProUGUI animtext;
    public Animator anim;
   
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.CompareTag("obs"))
        {
            GuiController.score = GuiController.score + 100;
            Destroy(collision.gameObject);
            ObstacleControl.obscount--;
            playy();
            if (ObstacleControl.obscount <=0)
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
            playy();
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

    void playy()
    {
        if(ObstacleControl.obscount%4==0)
        {
            animtext.text = "AWESOME";
        }
        if (ObstacleControl.obscount%3==0)
        {
            animtext.text = "GREAT";
        }
        if (ObstacleControl.obscount%5==0)
        {
            animtext.text = "BLAST!!";
        }
      
        anim.Play("TextAnim");
  
    }

}
