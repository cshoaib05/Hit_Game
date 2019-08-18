using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject shatter;
    public GameObject Ballon;
    public GameObject Bottle;
    public GameObject Jelly;
    public GameObject Scorepanel;
    public Camerashake camerashake;

    private void OnCollisionExit(Collision collision)
    {
 
        if (collision.gameObject.CompareTag("Balloon"))
        {
            ObstacleControl.obscount--;
            Destroy(collision.gameObject);
            shatter = Instantiate(Ballon, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(shatter, 0.5f);
            if(GuiController.vibrate ==1)
            {
                Handheld.Vibrate();
            }

            scoreinscrease();
            
        }

        if (collision.gameObject.CompareTag("jelly"))
        {
            ObstacleControl.obscount--;
            Destroy(collision.gameObject);
            shatter = Instantiate(Jelly, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroyobj();
            if (GuiController.vibrate == 1)
            {
                Handheld.Vibrate();
            }
            scoreinscrease();
        }


        if (collision.gameObject.CompareTag("bottle"))
        {
            ObstacleControl.obscount--;
            Destroy(collision.gameObject);
 
            shatter = Instantiate(Bottle, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroyobj();
            if (GuiController.vibrate == 1)
            {
                Handheld.Vibrate();
            }
            scoreinscrease();
        }

    }



    public void Destroyobj()
    {
        Destroy(shatter, 1);
        if(ObstacleControl.obscount<=0)
        {
            LeveCreater.iscleared = true;
        }
    }


    void scoreinscrease()
    {
        GuiController.score = GuiController.score + 100;
    }
    //    Pull to aim and shoot


}
