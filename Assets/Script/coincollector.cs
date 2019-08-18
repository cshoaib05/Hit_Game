using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coincollector : MonoBehaviour
{

    private void Start()
    {

        if(LeveCreater.isbonus)
        {
          ObstacleControl.obscount++;
        }
      
    }
    private void OnTriggerEnter(Collider other)
    {
        Store.coin++;
        if(LeveCreater.isbonus)
        {
            ObstacleControl.obscount--;
            if(ObstacleControl.obscount<=0)
            {
                LeveCreater.iscleared = true;
            }
        }
        Destroy(gameObject);
    }

}
