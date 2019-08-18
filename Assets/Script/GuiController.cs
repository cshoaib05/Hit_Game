using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GuiController : MonoBehaviour
{
    public static bool start;
    public TextMeshProUGUI Scoretext;
    public TextMeshProUGUI Scoretextpause;
    public TextMeshProUGUI ScoretextFinal;
    public static int score;
    [SerializeField] GameObject menupanel;
    [SerializeField] GameObject pausebutton;
    [SerializeField] GameObject storepanel;
    [SerializeField] GameObject pausepanel;
    [SerializeField] GameObject settingpanel;
    [SerializeField] GameObject Scorepanel;
    public static bool check;

    void Awake()
    {
        check = false;
        start = false;
        Scoretext.enabled = false;
    }

    private void Update()
    {
        if(LeveCreater.iscleared && !check)
        {
            StartCoroutine(timewait());
            check = true;
        }

        if(!start)
        {
            pausebutton.SetActive(false);
        }
        else
        {
            pausebutton.SetActive(true); 
        }

        Scoretext.text = score.ToString();
        Scoretextpause.text = Scoretext.text;
        ScoretextFinal.text = Scoretext.text;
    }

    public void Play()
    {
        Time.timeScale = 1;
        start = true;
        score = 0;
        menupanel.SetActive(false);
        Scoretext.enabled = true;
    }


    public void Pausepanellshow()
    {
        Time.timeScale = 0;
        start = false;
        pausepanel.SetActive(true);
    }

    public void settingpanelshow()
    {
        settingpanel.SetActive(true);
    }

    public void resume()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1;
        start = true;
    }

    public void mainmenu()
    {
        pausepanel.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void storeshow()
    {
        storepanel.SetActive(true);
    }

    public void storehide()
    {
        storepanel.SetActive(false);
        menupanel.SetActive(true);
    }

    public void settingclose()
    {
        settingpanel.SetActive(false);
        menupanel.SetActive(true);
    }

    IEnumerator timewait()
    {
        yield return new WaitForSeconds(3);
        Scorepanel.SetActive(true);
    }


}
