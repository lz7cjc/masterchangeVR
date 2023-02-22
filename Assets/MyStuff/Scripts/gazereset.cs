using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;


public class gazereset : MonoBehaviour
{
    private showhide3d showhide3d;
    public bool mousehover = false;
    public float counter = 0;
    public bool main;
    public bool smoking;
    public bool alcohol;
    public bool sharks;
    public bool heights;
    public bool training;
    public bool film;
    public bool tip;
    public string filmlink;


    // 0 = not started 1=xray results/go for CT scan 2= CT diagnosis


    void Update()
    {
        if (mousehover)
        {
            counter += Time.deltaTime;
            if (counter >= 5)
            {
                mousehover = false;
                counter = 0;
                // name of scene which you want to load
                if (main)
                {
                    PlayerPrefs.SetInt("SkipLearningScreenInt", 1);
                    PlayerPrefs.DeleteKey("nextscene");
                    PlayerPrefs.DeleteKey("behaviour");
                }
                else if (training)
                {
                    PlayerPrefs.SetInt("SkipLearningScreenInt", 0);
                    PlayerPrefs.DeleteKey("nextscene");
                }
                else if (smoking)
                {
                    PlayerPrefs.SetString("nextscene", "hospital");
                    PlayerPrefs.SetString("behaviour", "smoking");
                    PlayerPrefs.SetInt("stage", 0);
                }
                else if (alcohol)
                {
                    PlayerPrefs.SetString("nextscene", "hospital");
                    PlayerPrefs.SetString("behaviour", "alcohol");
                    PlayerPrefs.SetInt("stage", 0);
                    PlayerPrefs.DeleteKey("setCat");

                }
                else if (sharks)
                {
                    PlayerPrefs.SetString("nextscene", "phobia");
                    PlayerPrefs.SetString("behaviour", "sharks");

                }
                else if (heights)
                {
                    PlayerPrefs.SetString("nextscene", "phobia");
                    PlayerPrefs.SetString("behaviour", "heights");
                    PlayerPrefs.SetInt("stage", 0);

                }
                //else if (tip)
                //{
                //    PlayerPrefs.SetString("nextscene", "tip");
                //}
                //else if (film)
                //{
                //    PlayerPrefs.SetString("nextscene", "film");
                //    PlayerPrefs.SetString("VideoUrl", filmlink);
                //}



                showhide3d = FindObjectOfType<showhide3d>();
                showhide3d.ResetScene();
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
