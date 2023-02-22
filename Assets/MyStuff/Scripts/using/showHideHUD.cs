using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Net;

public class showHideHUD : MonoBehaviour
{

    public bool mousehover = false;

    public float Counter = 0;
    public bool turnoff;
   public GameObject section;
    public GameObject hud;

    void Update()
    {
        //string behaviour = PlayerPrefs.GetString("behaviour");
        //if ((behaviour == "tips") || (behaviour == "film"))
        //    {
        //    hud.SetActive(false);

        //}
        if (mousehover)
        {


            Counter += Time.deltaTime;

            if (Counter >= 3)
            {
                mousehover = false;
                Counter = 0;
                if (!turnoff)
                {
                    section.SetActive(true);

                }
                else
                {
                    section.SetActive(false);


                }
            }
        }
    }

    // mouse Enter event
    public void MouseHoverChangeScene()
    {
        
        mousehover = true;
    }

    // mouse Exit Event
    public void MouseExit()
    {

       
        mousehover = false;
        Counter = 0;
    }

 
    
}
