﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitCount : MonoBehaviour
{

    private void Awake()
    {
        ObstacleControl.obscount++;
        if(gameObject.CompareTag("coin") && LeveCreater.isbonus)
        {
            ObstacleControl.obscount++;
        }
    }

}
