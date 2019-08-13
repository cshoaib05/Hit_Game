using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiController : MonoBehaviour
{
    public static bool start;

    [SerializeField] GameObject menupanel;
    [SerializeField] GameObject pausebutton;
    [SerializeField] GameObject storepanel;
    [SerializeField] GameObject pausepanel;
    [SerializeField] GameObject settingpanel;
       
    void Awake()
    {
        start = false; 
    }

    private void Update()
    {
        if(!start)
        {
            pausebutton.SetActive(false);
        }
        else
        {
            pausebutton.SetActive(true); 
        }
    }

    public void Play()
    {
        start = true;
        menupanel.SetActive(false);
    }

    public void Storepanel()
    {
        storepanel.SetActive(true);
    }

    public void Pausepanellshow()
    {
        Time.timeScale = 0;
        pausepanel.SetActive(true);
    }

    public void settingpanelshow()
    {
        
        settingpanel.SetActive(true);
    }
}
