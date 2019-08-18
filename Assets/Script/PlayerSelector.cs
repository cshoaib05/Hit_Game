using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public List<GameObject> PlayersList;
    public GameObject Player;
    public Materialscontroller materialscontroller;
    public GameObject[] Animobj;
   
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
          Animobj[0].transform.position =poss;
          Animobj[0].SetActive(true);
        }

        if ( LeveCreater.iscleared && Store.inuseindex ==2)
        {
            Vector3 poss = new Vector3(Movement.playerepos.x, 0.253f, Movement.playerepos.z);
          Animobj[1].transform.position =poss;
          Animobj[1].SetActive(true);
        }


        if ( LeveCreater.iscleared && Store.inuseindex ==4)
        {
            Vector3 poss = new Vector3(Movement.playerepos.x, 0.253f, Movement.playerepos.z);
          Animobj[2].transform.position =poss;
          Animobj[2].SetActive(true);
        }


        if ( LeveCreater.iscleared && Store.inuseindex ==6)
        {
            Vector3 poss = new Vector3(Movement.playerepos.x, 0.253f, Movement.playerepos.z);
          Animobj[3].transform.position =poss;
          Animobj[3].SetActive(true);
        }

        if(!LeveCreater.iscleared)
        {
        foreach(GameObject go in Animobj)
            {
                go.SetActive(false);
            }
        }
    }

}
