using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
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


    public List<GameObject> objready;
    public List<GameObject> Obstacles;
        


    private void Awake()
    {
        dict = new Dictionary<int, List<Vector3>>();

        dict.Add(0, square);
        dict.Add(1, octagon);
        dict.Add(2, tri);
        dict.Add(3, I);
        dict.Add(4, round);
        dict.Add(5, oval);
        dict.Add(6, heart);
        dict.Add(7, S);
        dict.Add(8, Y);
        dict.Add(9, Z);
        dict.Add(11, Mismatch);
    }

    private void Start()
    {
        objready = new List<GameObject>();
        foreach(GameObject go in Obstacles)
        {
            GameObject gor = Instantiate(go);
            gor.SetActive(false);
            objready.Add(gor);
        }
        foreach (GameObject go in Obstacles)
        {
            GameObject gor = Instantiate(go);
            gor.SetActive(false);
            objready.Add(gor);
        }
        obstacleplace();
    }

    public void obstacleplace()
    {
        int index;
        Vector3 randompos;
        List<Vector3> list;
        list = dict[Store.inuseindex];
        randompos = list[Random.Range(0, list.Count)];
        print(objready.Count);
        index = Random.Range(0, objready.Count);
        objready[index].SetActive(true);
        objready[index].transform.position = randompos;
    }
}
