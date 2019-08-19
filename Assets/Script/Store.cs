using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    public List<storelement> elements;
    public static int coin;
    public TextMeshProUGUI cointext;
    public static int inuseindex;
    public Sprite yellowimage;
    public PlayerSelector playerSelector;


    private void Awake()
    {
        PlayerPrefs.GetInt("1", 0);
        PlayerPrefs.GetInt("2", 0);
        PlayerPrefs.GetInt("3", 0);
        PlayerPrefs.GetInt("4", 0);
        PlayerPrefs.GetInt("5", 0);
        PlayerPrefs.GetInt("6", 0);
        PlayerPrefs.GetInt("7", 0);
        
       coin = PlayerPrefs.GetInt("coin", 0);
    }


    public void Start()
    {
        for(int j=0; j<=7; j++)
        {
            if(PlayerPrefs.GetInt(j.ToString())==1)
            {
                elements[j].unlocked = true;
            }
        }

        inuseindex = PlayerPrefs.GetInt("inuse", 0);
        for (int i = 0; i < elements.Count; i++)
        {
            if (i == inuseindex)
            {
                elements[i].Button.image.sprite = yellowimage;
                elements[i].inusetext.gameObject.SetActive(true);
            }
        }


    }

    private void Update()
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].unlocked)
            {
                elements[i].pricetext.SetActive(false);
            }
        }
        cointext.text = coin.ToString();
        PlayerPrefs.SetInt("coin", coin);
    }

    public void Button0()
    {
        if (elements[0].unlocked)
        {
            inusebool(0);
            Inuseimage(0);
            elements[0].pricetext.SetActive(false);
        }
    }

    public void Button1()
    {
        if (elements[1].unlocked)
        {
            inusebool(1);
            Inuseimage(1);
          
        }
        else
        {
            Buyelements(1);
        }
    }

    public void Button2()
    {
        if (elements[2].unlocked)
        {
            inusebool(2);
            Inuseimage(2);
            elements[2].pricetext.SetActive(false);
        }
        else
        {
            Buyelements(2);
        }
    }

    public void Button3()
    {
        if (elements[3].unlocked)
        {
            inusebool(3);
            Inuseimage(3);
            elements[3].pricetext.SetActive(false);
        }
        else
        {
            Buyelements(3);
        }
    }

    public void Button4()
    {
        if (elements[4].unlocked)
        {
            inusebool(4);
            Inuseimage(4);
            elements[4].pricetext.SetActive(false);
        }
        else
        {
            Buyelements(4);
        }
    }

    public void Button5()
    {
        if (elements[5].unlocked)
        {
            inusebool(5);
            Inuseimage(5);
            elements[5].pricetext.SetActive(false);
        }
        else
        {
            Buyelements(5);
        }
    }

    public void Button6()
    {
        if (elements[6].unlocked)
        {
            inusebool(6);
            Inuseimage(6);
            elements[6].pricetext.SetActive(false);
        }
        else
        {
            Buyelements(6);
        }
    }

    public void Button7()
    {
        if (elements[7].unlocked)
        {
            inusebool(7);
            Inuseimage(7);
            elements[7].pricetext.SetActive(false);
        }
        else
        {
            Buyelements(7);
        }
    }


    void inusebool(int index)
    {
        for (int i = 0; i <elements.Count; i++)
        {
            if(i==index)
            {
                elements[i].inusestats = true;
                inuseindex = i;
            }
            else
            {
                elements[i].inusestats = false;
            }
        }
        playerSelector.playerchange();
    }

    void Inuseimage(int index)
    {
        for(int i =0; i<elements.Count; i++)
        {
            if(i==index)
            {
                if(elements[i].inusestats)
                {
                    elements[i].Button.image.sprite = yellowimage;
                    elements[i].inusetext.gameObject.SetActive(true);
                    PlayerPrefs.SetInt("inuse", i);
                }
            }
            else
            {
                elements[i].Button.image.sprite = null;
                elements[i].inusetext.gameObject.SetActive(false);
            }

        }
    }

    void Buyelements(int index)
    {
        
        if(!elements[index].unlocked)
        {
            if(coin>=elements[index].price)
            {
                elements[index].unlocked = true;
                coin = coin - elements[index].price;
                PlayerPrefs.SetInt("coin", coin);
                PlayerPrefs.SetInt(index.ToString(), 1);
            }
        }
    }

}
