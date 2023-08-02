﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveCamera : MonoBehaviour
{

    public bool mousehover = false;

    public float Counter = 0;

    public Rigidbody player;
    public GameObject cameratarget;
 
    private getfav getfav;
    private floorceilingmove floorceilingmove;

    public TMP_Text TMP_title;
    public bool gravity = true;
    public string nextscene;
    public GameObject section;
    private bool tempStop;
   // private showHideHUD showHideHUD;

    //  private bool tempStart;

    private void Start()
    {


    }
    void Update()
    {

        if (mousehover)
        {


            Counter += Time.deltaTime;
           if (Counter >0.75)
            {
                startStopMove(tempStop = true);
            }

            if (Counter >= 3)
            {
                mousehover = false;
                Counter = 0;
                section.SetActive(true);
                PlayerPrefs.SetString("nextscene", nextscene);
                showandhide();

            }
        }
    }

    // mouse Enter event
    public void MouseHoverChangeScene()
    {
        
        TMP_title.color = Color.white;
        mousehover = true;
       
    }

    // mouse Exit Event
    public void MouseExit()
    {
     
       // Color32 db = new Color(.102f, .153f, .255f, .255f); 
        //15, 23,94
     //   TMP_title.color = db;
        mousehover = false;
        Counter = 0;
    }

    private void showandhide()
    {
        Debug.Log("picked it up 2");
        player.useGravity = gravity;
        player.transform.position = cameratarget.transform.position;
        player.transform.SetParent(cameratarget.transform);

        //player.MovePosition(cameratarget.transform.position);
        //player.transform.SetParent(cameratarget.transform);
        getfav = FindObjectOfType<getfav>();
        getfav.favReset();

    }

    private void startStopMove(bool tempStop)
    {
        if (tempStop)
        {
            floorceilingmove = FindObjectOfType<floorceilingmove>();
            floorceilingmove.stopTheCamera();
        //    showHideHUD = FindObjectOfType<showHideHUD>();
       //     showHideHUD.Start();

        }

        //else if (!tempStop)
        //{
        //    floorceilingmove = FindObjectOfType<floorceilingmove>();
        //    floorceilingmove.LetsGo();
        //}
    }
   

}
