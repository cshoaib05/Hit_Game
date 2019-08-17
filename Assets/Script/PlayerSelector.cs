using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public List<GameObject> PlayersList;
    public GameObject Player;

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
            Player = Instantiate(PlayersList[Store.inuseindex], PlayersList[Store.inuseindex].transform.position, PlayersList[Store.inuseindex].transform.rotation);
        }
   
    }

    private void Update()
    {
        if(LeveCreater.iscleared)
        {
            playerchange();
        }
    }

}
