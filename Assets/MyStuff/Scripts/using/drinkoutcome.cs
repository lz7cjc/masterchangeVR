﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;


public class drinkoutcome : MonoBehaviour
{
    private showhide3d showhide3d;

    public bool mousehover = false;
    public float counter = 0;
    private floorceilingmove floorceilingmove;
    private bool tempStop;
    // Start is called before the first frame update

    //  public Text guidelines_txt;
    // Update is called once per frame
    public void setCategory(string category)
    {
        PlayerPrefs.SetString("setCat", category);
    }

    public void setFilm()
    {
        PlayerPrefs.SetInt("stageAlcohol", 3);
        string setCategory = PlayerPrefs.GetString("setCat");
        if (setCategory == "binge")

        {
            PlayerPrefs.SetString("VideoUrl", "https://youtu.be/FJ7bKoJmaek");
        }
     
        if (setCategory == "chronic")
        {
            PlayerPrefs.SetString("VideoUrl", "https://youtu.be/AW78uVJfm44");
        }
        if (setCategory == "dependent")

        {
            PlayerPrefs.SetString("VideoUrl", "https://youtu.be/ZbueA2RgSFk");

        }

        if (setCategory =="guidelines")
        {
             PlayerPrefs.SetString("behaviour", "alcohol");
            PlayerPrefs.SetString("nextscene", "hospital");
             PlayerPrefs.SetInt("stageAlcohol", 3);

            showhide3d = FindObjectOfType<showhide3d>();
            showhide3d.ResetScene();
        }
        PlayerPrefs.SetString("returntoscene", "hospital");
        PlayerPrefs.SetString("behaviour", "alcohol");
        PlayerPrefs.SetString("nextscene", "film");
        PlayerPrefs.SetInt("stageAlcohol", 3);

        showhide3d = FindObjectOfType<showhide3d>();
        showhide3d.ResetScene();

    }

    void Update()

    {
        if (mousehover)
        {
            Debug.Log("iii");
            counter += Time.deltaTime;
            if (counter >= 3)
            {
                mousehover = false;
                counter = 0;
                // name of scene which you want to load

                setFilm();
            }
        }
    }



    // mouse Enter event
    public void MouseHoverChangeScene()
    {
        startStopMove(tempStop = true);
        mousehover = true;
    }

    // mouse Exit Event
    public void MouseExit()
    {
        
        mousehover = false;
        counter = 0;
    }

    private void startStopMove(bool tempStop)
    {
        if (tempStop)
        {
            Debug.Log("iii +");
            floorceilingmove = FindObjectOfType<floorceilingmove>();
            floorceilingmove.stopTheCamera();

        }

        //else if (!tempStop)
        //{
        //    floorceilingmove = FindObjectOfType<floorceilingmove>();
        //    floorceilingmove.LetsGo();
        //}
    }

}
