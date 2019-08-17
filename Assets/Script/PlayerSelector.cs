using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public List<GameObject> PlayersList;
    public GameObject Player;
    public Materialscontroller materialscontroller;

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



}
