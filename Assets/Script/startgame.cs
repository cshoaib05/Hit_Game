using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startgame : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        StartCoroutine(Loadlevel());

    }

 IEnumerator Loadlevel()
    {

        AsyncOperation oper = SceneManager.LoadSceneAsync(1);

        while (!oper.isDone)
        {
            float progress = Mathf.Clamp01(oper.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
