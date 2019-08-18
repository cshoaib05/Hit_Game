using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materialscontroller : MonoBehaviour
{
    public ParticleSystem winparticles;
    public static bool isplyaed;
    public Material basecolor;
    public Material bordercolor;

    public Color[] Base;
    public Color[] Border;
    public Color[] Bgcolor;
    public Camera cam;
    private void Start()
    {
        isplyaed = false;
    }
    public void changecolor()
    {
        int i;
        i = Random.Range(0, 5);
        basecolor.color = Base[i];
        bordercolor.color = Border[i];
        cam.backgroundColor = Bgcolor[i];
    }

    private void Update()
    {
        if(ObstacleControl.obscount<=0 && !isplyaed)
        {
            winparticles.Play();
            isplyaed = true;
        }
    }
}
