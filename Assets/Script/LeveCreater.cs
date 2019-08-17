using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeveCreater : MonoBehaviour
{
    public List<GameObject> TableList;
    public List<GameObject> Tablesready;
    public GameObject Table;
    public int tableindex;

    private void Start()
    {
        tableindex = PlayerPrefs.GetInt("table", 0);
       foreach(GameObject go in TableList)
       {
            GameObject tab=   Instantiate(go, go.transform.position, go.transform.rotation);
            tab.SetActive(false);
            Tablesready.Add(tab);
       }
        CreateTable();
    }

    public void CreateTable()
    {
        Tablesready[tableindex].SetActive(true);
    }


    public void TableChanger()
    {
        int i;
        i=Random.Range(0, 12);
        Tablesready[i].SetActive(true);
        tableindex = i;
    }
}