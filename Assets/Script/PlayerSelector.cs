using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public List<GameObject> PlayersList;
    public GameObject Player;
    public Materialscontroller materialscontroller;
    public GameObject Animobj;
   
    private void Start()
    {

        playerchange();
    }

    public void playerchange()
    {
       if(Player == null)
        {
            Player = Instantiate(PlayersList[Store.inuseindex], PlayersList[Store.inuseindex].transform.position, PlayersList[Store.inuseindex].transform.rotation);
        }
       else
        {
            Destroy(Player);
            Player = Instantiate(PlayersList[Store.inuseindex], Vector3.zero,Quaternion.identity);
            materialscontroller.changecolor();
        }
   
    }

    private void Update()
    {
        if( LeveCreater.iscleared && Store.inuseindex ==0)
        {
            Vector3 poss = new Vector3(Movement.playerepos.x, 0.253f, Movement.playerepos.z);
            Animobj.transform.position =poss;
            Animobj.SetActive(true);
        }
        if(!LeveCreater.iscleared)
        {
            Animobj.SetActive(false);
        }
    }

}
