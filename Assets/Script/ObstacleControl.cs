using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    public static int obscount;
    public Dictionary<int,List<Vector3>> dict;
    public List<Vector3> square;
    public List<Vector3> octagon;
    public List<Vector3> tri;
    public List<Vector3> I;
    public List<Vector3> round;
    public List<Vector3> oval;
    public List<Vector3> heart;
    public List<Vector3> S;
    public List<Vector3> Y;
    public List<Vector3> Z;
    public List<Vector3> Mismatch;

    public List<GameObject> Obstacles;
    public GameObject coin;

    private void Awake()
    {
        obscount = 0;
        PlayerPrefs.SetInt("level", 4);
        obscount = 0;
        dict = new Dictionary<int, List<Vector3>>
        {
            { 0, square },
            { 1, octagon },
            { 2, tri },
            { 3, I },
            { 4, round },
            { 5, oval },
            { 6, heart },
            { 7, S },
            { 8, Y },
            { 9, Z },
            { 10, Mismatch }
        };
    }

    private void Start()
    {
        obstacleplace();
    }


    public void obstacleplace()
    {
        if(!LeveCreater.isbonus)
        {
            for (int i = 0; i <= Random.Range(2, 3); i++)
            {
                place();
            }
        }
        else
        {
            placebonus();
        }
    }

    void place()
    {
        GameObject gooo;
        int index;
        Vector3 randompos;
        List<Vector3> list;
        list = dict[LeveCreater.tableindex];
        randompos = list[Random.Range(0, list.Count)];
        index = Random.Range(0, Obstacles.Count);
        gooo = Instantiate(Obstacles[index]);
        gooo.transform.position = randompos;
        randompos = list[Random.Range(0, list.Count)];
        coinplace(randompos);

    }

   
    void coinplace(Vector3 pos)
     {
        Instantiate(coin, pos, coin.transform.rotation);
     }

    void placebonus()
    {
        List<Vector3> list;
        list = dict[LeveCreater.tableindex];
        foreach (Vector3 po in list)
        {
            Instantiate(coin, po, coin.transform.rotation);
        }
    }

    private void Update()
    {
        print(obscount);
    }

}
