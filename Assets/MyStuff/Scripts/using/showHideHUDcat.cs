using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Net;

public class showHideHUDcat : MonoBehaviour
{

    public bool mousehover = false;

    public float Counter = 0;
   // public bool turnoff;
   public GameObject zones;
    //  public GameObject hud;
    private bool turnon = true;

    void Update()
    {
        //string behaviour = PlayerPrefs.GetString("behaviour");
        //if ((behaviour == "tips") || (behaviour == "film"))
        //    {
        //    hud.SetActive(false);

        //}
        Debug.Log("12345" + turnon);
        if (mousehover)
        {


            Counter += Time.deltaTime;

            if (Counter >= 3)
            {
                mousehover = false;
                Counter = 0;
                if (turnon)
                {
                    Debug.Log("12345 update");
                    zones.SetActive(true);
                    turnon = false;

                }
                else
                {
                    zones.SetActive(false);
                    turnon = true;


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
