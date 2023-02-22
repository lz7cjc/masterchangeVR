using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadscene : MonoBehaviour
{
    
    
    public bool mousehover = false;
    public float counter = 0;
    private int isTraining;
    private int whichsigns;
    public Boolean skiptraininglevel;
    public Boolean smallsigns;

    public void changeSignSetting()
    {
        if (smallsigns)
        {
            PlayerPrefs.SetInt("EyesGood", 1);
         }
        else
        {
            PlayerPrefs.SetInt("EyesGood", 0);
        }
    }

    public void changetraining()
    {
        if (skiptraininglevel)
        {
            PlayerPrefs.SetInt("SkipLearningScreenInt",1);

        }
        else
        {
            PlayerPrefs.SetInt("SkipLearningScreenInt", 0);
        }
    }




    void Update()
    {
        if (mousehover)
        {
            counter += Time.deltaTime;
            if (counter >= 3)
            {
                mousehover = false;
                counter = 0;
                // name of scene which you want to load
                SceneManager.LoadScene("otherlandscape");

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
        // Debug.Log("cancelling scene change");
        mousehover = false;
        counter = 0;
    }



}
