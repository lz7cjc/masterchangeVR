using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DynamicLoadVideo : MonoBehaviour
{
    public bool mousehover = false;
    public float counter = 0;
    //public int Film_button;
    private string Switchscenename;
   // private object Scenename;
    public string VideoUrlLinkGood;
    public string VideoUrlLinkBad;
    private float Jeopardy;
    private int randomInt;
    private float JCMultiplier;
    public int hospitalScene;
    public string returnScene;

    private void Start()

    {

        Jeopardy = PlayerPrefs.GetInt("JCP");
        Debug.Log("jC us: " + Jeopardy);
        randomInt = Random.Range(5, 20);
        Debug.Log("Random number" + randomInt);
        JCMultiplier = randomInt*(Jeopardy/100);
        Debug.Log("Multiplier: " + JCMultiplier);
         }


   
    // Update is called once per frame
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
                Debug.Log("should be switching" + Switchscenename);
               
                //  if (VideoUrlLink != "")
                //     {
                if (JCMultiplier >= 5)
                {
                    Switchscenename = "stream360";
                        SceneManager.LoadScene(Switchscenename);
                    PlayerPrefs.SetString("VideoUrl", VideoUrlLinkBad);
                    PlayerPrefs.SetString("nextscene", returnScene);
                    Debug.Log("Play bad video");
                }
                else
                {
                    Switchscenename = "stream360";
                    SceneManager.LoadScene(Switchscenename);
                    PlayerPrefs.SetString("VideoUrl", VideoUrlLinkGood);
                    PlayerPrefs.SetString("nextscene", returnScene);
                    Debug.Log("Play good video");
                }
                    print("---->>>" + PlayerPrefs.GetString("VideoUrl"));
            //   
            }
        }
    }

    // mouse Enter event
    public void MouseHoverChangeScene(string Scenename)
    {
        Debug.Log("setting scenename");
        Switchscenename = Scenename;
        mousehover = true;
    }

    // mouse Exit Event
    public void MouseExit()
    {
       // Debug.Log("cancelling scene change");
        mousehover = false;
        counter = 0;
    }

    //private class PlayerData
    //{
    //    //Health factors
    //    public bool ttfcless;
    //    public bool ttfcmore;
    //    public bool nrt;
    //    public bool prequit;
    //    public bool quitting;
    //    public bool nodate;
    //    public float cigsPerDay;
    //    public float previousQuits;
    //    public float yearsSmoked;

    //    //progress
    //    public bool learning;
    //    public bool stacy;
    //    public bool goodXray;
    //    public bool badXray;
    //    public bool goodCTscan;
    //    public bool badCTscan;
    //    public bool ctScan;

    //    //scoring
    //    public string badge;
    //    public int score;
    //    public string level;

    //    //Jeopardy Coefficient
    //    public float jeopardyCoefficient;
    //}

    //void SetVideos()
    //{


    //}
}