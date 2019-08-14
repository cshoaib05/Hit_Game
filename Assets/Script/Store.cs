using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
   public   Button Button;
   public Image Sprite;
    public List<storelement> elements;
    public static int coin;
    public TextMeshProUGUI cointext;
    public int inuseindex;
    public Sprite yellowimage;


    public void Start()
    {
        coin = 1000;
        inuseindex = 0;
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
    }

    public void Button0()
    {
        print(elements.Count);
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
            }
        }
    }

}
