using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Net;
using Unity;

public class showHideHUDMove : MonoBehaviour
{

    /// <summary>
    /// //display the zones sub menu on the mainvr hud////////
    /// </summary>
    /// 

    public bool mousehover = false;
   // public GameObject altImage;
    private float Counter = 0;
    public float delay; 
   // public bool turnoff;
   public GameObject speedSet;
    //  public GameObject hud;
    private bool turnon = true;
    public GameObject hudZones;


    void Update()
    {
       
        if (mousehover)
        {

            Debug.Log("turnon 1" + turnon);
            Counter += Time.deltaTime;

            if (Counter >= delay)
            {
                Debug.Log("turnon 2" + turnon);
                mousehover = false;
                Counter = 0;
                if (turnon)
                {

                    showWalkSub();
                    
                }
                else
                {

                    hideWalkSub();

                }
            }
        }
    }

    public void showWalkSub()
    {
        Debug.Log("12345 update");
        speedSet.SetActive(true);
        hudZones.SetActive(false);
        turnon = false;

    }


    public void hideWalkSub()
    {
        speedSet.SetActive(false);
        turnon = true;
    }
    // mouse Enter event
    public void MouseHoverChangeScene()
    {
        
        mousehover = true;
        //ChangeSprite(true);

    }

    // mouse Exit Event
    public void MouseExit()
    {

        //ChangeSprite(false);
         mousehover = false;
        Counter = 0;
    }

 
    
}
