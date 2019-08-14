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

    public Sprite yellowimage;

    private void Update()
    {
       
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

    }
    public void Button2()
    {

    }
    public void Button3()
    {

    }
    public void Button4()
    {

    }
    public void Button5()
    {

    }
    public void Button6()
    {

    }
    public void Button7()
    {

    }

    void inusebool(int index)
    {
        for (int i = 0; i <= elements.Count; i++)
        {
            if(i==index)
            {
                elements[i].inusestats = true;
            }
            else
            {
                elements[i].inusestats = false;
            }
        }
    }

    void Inuseimage(int index)
    {
        for(int i =0; i<=elements.Count; i++)
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

}
