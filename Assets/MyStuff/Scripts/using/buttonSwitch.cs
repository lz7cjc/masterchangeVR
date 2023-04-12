using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Globalization;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
public class buttonSwitch : MonoBehaviour
{

    public GameObject defaultButton;
    public GameObject hoverButton;
    public GameObject visitedButton;
    private bool mousehover;
    public float Counter = 0;

    void Update()
    {

        if (mousehover)
        {


            Counter += Time.deltaTime;

            if (Counter >= 3)
            {
                mousehover = false;
                Counter = 0;


            }
        }
    }

    // mouse Enter event
    public void buttonGaze()
    {
       
        mousehover = true;
        defaultButton.SetActive(false);
        hoverButton.SetActive(true);
    }

    // mouse Exit Event
    public void MouseExit()
    {

        
        mousehover = false;
        Counter = 0;
    }

}
