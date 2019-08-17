using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeveCreater : MonoBehaviour
{
    public TextMeshProUGUI leveltext;
    public List<GameObject> TableList;
    public List<GameObject> Tablesready;
    public GameObject Table;
    public static bool iscleared;
    public static int tableindex;
    public GameObject SCorePanel;
    public ObstacleControl obstaclecreater;
    public PlayerSelector playerSelector;
    public static int levelno;

    private void Start()
    {
        levelno = PlayerPrefs.GetInt("level", 1);
        iscleared = false;
        leveltext.text = "LEVEL " + levelno.ToString();
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
        iscleared = false;
        Tablesready[tableindex].SetActive(false);
        int i;
        i=Random.Range(0, 11);
        Tablesready[i].SetActive(true);
        tableindex = i;
        PlayerPrefs.SetInt("table", tableindex);
        iscleared = false;
        SCorePanel.SetActive(false);
        Time.timeScale = 1;
        obstaclecreater.obstacleplace();
        playerSelector.playerchange();
        levelno++;
        leveltext.text = "LEVEL " + levelno.ToString();
        PlayerPrefs.SetInt("level", levelno);
    }

}