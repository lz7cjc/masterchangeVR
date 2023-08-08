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
    public bool showing = false;
   public GameObject hudprimary;
    public GameObject turnHudOn;
    public GameObject turnHudOff;
    public GameObject hudZones;
    public GameObject hudMove;

    public void Start()
    {
        hudprimary.SetActive(false);
        hudZones.SetActive(false);
        hudMove.SetActive(false);
        turnHudOn.SetActive(true);
        turnHudOff.SetActive(false);
    }
    

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
                directClick();
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

    public void directClick()
    {
        if (!showing)
        {

            Debug.Log("show + primary only");
            hudprimary.SetActive(true);
            turnHudOff.SetActive(true);
            turnHudOn.SetActive(false);
            showing = true;
        }
        else
        {
            //hide primary hud and change to a +

            hudprimary.SetActive(false);
            turnHudOff.SetActive(false);
            turnHudOn.SetActive(true);
            hudZones.SetActive(false);
            hudMove.SetActive(false);


            showing = false;
        }
    }    
 
    
}
