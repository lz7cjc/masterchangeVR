﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Net;

//this is used when coming from a different scene
public class showhide3d : MonoBehaviour
{
    //moving camera
 //  public GameObject player;
   private Rigidbody Player;

    //targets
    public GameObject targetStartReception;
    public GameObject targetPhobias1;
    public GameObject targetPhobias2;
    public GameObject targetPhobias3;
    public GameObject targetSharks;
    public GameObject targetSmoking0;
    public GameObject interruptFilm;
    //public GameObject targetSmoking1;
    //public GameObject targetSmoking2;
    //public GameObject targetSmoking3;
    //public GameObject targetSmoking4;
    //public GameObject targetSmoking5;
    public GameObject targetactivityCentre;

    public GameObject targetalcohol1;
    public GameObject targetalcohol2;
    public GameObject targetalcohol3;
    public GameObject targetalcohol4;
    public GameObject waitingtgt;
  //  public GameObject targetfilm;
   // public GameObject targettip;

    //generic films
    public GameObject targetTravel;
    public GameObject targetCalm;
    public GameObject targetAdrenaline;
    public GameObject targetMuseums;
    public GameObject targetHistory;
    public GameObject targetBeaches;
    public GameObject targetParks;
    public GameObject targetSpace;



    public GameObject preReadyCT;
    public GameObject readyCT;

    private videocontrollerff videocontrollerff;
    // public GameObject keyButtons;

    private riroStopGo riroStopGo;
    //variables for playerprefs
    private int stage;
    private string nextscene;
    private string returntoscene;
  //  private int isLearning;
    private bool gotnextscene;
    private string behaviour;
    private int trainingDone;
    private bool toggler;

    //show/hide sections
   // public GameObject section_tip;
    public GameObject alcoholintro;
    public GameObject alcoholfollow;
    public GameObject alcoholsolution;
    public GameObject alcoholfinish;
    public GameObject welcomeSmoking;
    public GameObject riroCheck;

    public GameObject xrayResults;
    public GameObject stopGoCtscan;
    public GameObject CTresults;
    public GameObject smokingDone;
    //public videocontrollerff videocontrollerff;
 //   public GameObject films;
    public GameObject notFilms;
    public GameObject terrain;

    private justGetRiros justGetRiros;
    private setCTdate setCTdate;
    private int starting;

    private int scriptCounter;
    private int stopFilm;
    public GameObject mainCamera;
    Vector3 m_EulerAngleVelocity;

    public GameObject hud;

    private void Start()
    {
        //Player.useGravity = true;
 //       Debug.Log("^^^ start");
        ResetScene();
      
        
    }
    //get player prefs

    /// <summary>
    /// check to see if there is a next scene set. This is used when leaving VR and going back in or when playing a film,
    /// so you are taken back to the right place. 
    ///     /// </summary>
    public void ResetScene()
    {
        trainingDone = PlayerPrefs.GetInt("trainingDone");
        toggler = false;
        Player = GameObject.Find("Player").GetComponent<Rigidbody>();

             if (trainingDone == 0)
            {

            Player.transform.position = targetStartReception.transform.position;
            Player.transform.SetParent(targetStartReception.transform);
            toggler = true;
            PlayerPrefs.SetInt("trainingDone", 1);
        }

        //otherwise run script
        else if (trainingDone == 1)
        {
            whereto();
        }
    

}

        private void whereto()
    {
        //get player prefs and assign to variables
        returntoscene = PlayerPrefs.GetString("returntoscene");
        stage = PlayerPrefs.GetInt("stage");
        behaviour = PlayerPrefs.GetString("behaviour");
        nextscene = PlayerPrefs.GetString("nextscene");
        trainingDone = PlayerPrefs.GetInt("trainingDone");
        stopFilm = PlayerPrefs.GetInt("stopFilm");


        {
            //if we have no behaviour set and we aren't launching a film or going to the tips or intercepting the films
            // i.e. this is the default behaviour going to activity centre

            if ((nextscene == "home") || (((behaviour == "") && (nextscene != "film") && (nextscene != "tip") && (!PlayerPrefs.HasKey("stopFilm")) && (trainingDone == 1))))
            {
                notFilms.SetActive(true);
                hud.SetActive(true);
                Player.transform.position = targetactivityCentre.transform.position;
                Player.transform.SetParent(targetactivityCentre.transform);
            }
            else
            {
                goToNextScene();
            }
        }
    }

    private void goToNextScene()
    {
     //   Debug.Log("lll next scene is: " + nextscene);
         if (PlayerPrefs.HasKey("stopFilm"))
         {
            stopTheFilm();
         }
       
        else if (nextscene == "sectors")
        {
            goToSectors();

        }
        else if (nextscene == "hospital")
        {
            runVR();
       }

        else if (nextscene == "phobia" )
        {
            gotophobias();
        }

        else if (nextscene == "film")
        {
            // SceneManager.LoadScene("videoplayer");
            //   SceneManager.LoadScene("videoplayer", LoadSceneMode.Additive);
            SceneManager.LoadScene("videoplayer");
        }
        else if (nextscene == "register")
        {
      //      Debug.Log("kkk8 register"); 
            SceneManager.LoadScene("register");
            PlayerPrefs.SetString("nextscene", returntoscene);
            PlayerPrefs.DeleteKey("returntoscene");
      //      Debug.Log("^^^ register");


        }

        else if (nextscene == "dashboard")
        {
       //     Debug.Log("kkk9 dashboard");

            SceneManager.LoadScene("dashboard");
            PlayerPrefs.SetString("nextscene", returntoscene);
            PlayerPrefs.DeleteKey("returntoscene");
       //     Debug.Log("^^^ dashboard");

        }

        else
        {
       //     Debug.Log("kkk10 runVR");
       //     Debug.Log("^^^ runVR");
            runVR();
        }
    }

    public void runVR()
    {
      //  Debug.Log("kkk11 runVR");
        notFilms.SetActive(true);
        hud.SetActive(true);
        //   PlayerPrefs.DeleteKey("nextscene");
        goToBehaviourChange();
    }


    public void goToBehaviourChange()
    {
        //       Debug.Log("kkk12 in hospital function");
        //  Debug.Log("^^^ behaviour change");
        terrain.SetActive(true);
        switch (behaviour)
        {
            case "alcohol":
                stage = PlayerPrefs.GetInt("stageAlcohol");
                if (stage == 0)
                {

                    alcoholintro.SetActive(true);
                    alcoholfollow.SetActive(false);
                    alcoholsolution.SetActive(false);
                    alcoholfinish.SetActive(false);
                    Player.transform.position = targetalcohol1.transform.position;
                    Player.transform.SetParent(targetalcohol1.transform);
                    //          Debug.Log("kkk13 in alcohol stage 0");
                    //         Debug.Log("^^^ alcohol0");
                }
                else if (stage == 1)
                {
                    //         Debug.Log("kkk14 in alcohol stage 1");
                    alcoholintro.SetActive(false);
                    alcoholfollow.SetActive(true);
                    alcoholsolution.SetActive(false);
                    alcoholfinish.SetActive(false);

                    Player.transform.position = targetalcohol2.transform.position;
                    Player.transform.SetParent(targetalcohol2.transform);
                    //         Debug.Log("^^^ alcohol1");
                }
                else if (stage == 2)
                {
                    //         Debug.Log("kkk15 in alcohol stage 2");
                    alcoholintro.SetActive(false);
                    alcoholfollow.SetActive(false);
                    alcoholsolution.SetActive(true);
                    alcoholfinish.SetActive(false);
                    Player.transform.position = targetalcohol3.transform.position;
                    Player.transform.SetParent(targetalcohol3.transform);
                    //       Debug.Log("^^^ alcohol2");
                }
                else if (stage == 3)
                {
                    //        Debug.Log("kkk16 in alcohol stage 3");
                    alcoholintro.SetActive(false);
                    alcoholfollow.SetActive(false);
                    alcoholsolution.SetActive(false);
                    alcoholfinish.SetActive(true);
                    //        Debug.Log("^^^ alcohol3");

                    Player.transform.position = targetalcohol4.transform.position;
                    Player.transform.SetParent(targetalcohol4.transform);
                }
                break;

            case "smoking":
                    stage = PlayerPrefs.GetInt("stageSmoking");
                    //      Debug.Log("^^^ smoking");
                    //    keyButtons.SetActive(true);
                    //Welcome to smoking
                    if (stage == 0)
                    {

                        //        Debug.Log("^^^ smoking0");

                        welcomeSmoking.SetActive(true);
                        xrayResults.SetActive(false);
                        stopGoCtscan.SetActive(false);
                        CTresults.SetActive(false);
                        smokingDone.SetActive(false);
                        Player.transform.position = targetSmoking0.transform.position;
                        Player.transform.SetParent(targetSmoking0.transform);
                    }
                    //Get XRay Results
                    else if (stage == 1)
                    {
                        //       Debug.Log("^^^ smoking1");
                        welcomeSmoking.SetActive(false);
                        xrayResults.SetActive(true);
                        stopGoCtscan.SetActive(false);
                        CTresults.SetActive(false);
                        smokingDone.SetActive(false);
                        Player.transform.position = targetSmoking0.transform.position;
                        Player.transform.SetParent(targetSmoking0.transform);
                    }

                    //book CT Scan and go for scan when allowed
                    else if (stage == 2)
                    {
                        //        Debug.Log("^^^ smoking2");
                        welcomeSmoking.SetActive(false);
                        xrayResults.SetActive(false);
                        stopGoCtscan.SetActive(true);
                        CTresults.SetActive(false);
                        smokingDone.SetActive(false);

                        setCTdate = FindObjectOfType<setCTdate>();
                        setCTdate.setReferenceDate();

                        if (PlayerPrefs.GetInt("delaynotification") > 0)
                        {
                            //            Debug.Log("^^^ smoking2 wait for CT");
                            xrayResults.SetActive(false);
                            stopGoCtscan.SetActive(true);
                            preReadyCT.SetActive(true);
                            Player.transform.position = targetSmoking0.transform.position;
                            Player.transform.SetParent(targetSmoking0.transform);
                        }
                        else
                        {
                            //          Debug.Log("^^^ smoking2 ready for CT");

                            readyCT.SetActive(true);
                            xrayResults.SetActive(false);
                            stopGoCtscan.SetActive(true);
                            Player.transform.position = targetSmoking0.transform.position;
                            Player.transform.SetParent(targetSmoking0.transform);

                        }

                    }

                    //    PlayerPrefs.DeleteKey("nextscene");
                    //     PlayerPrefs.DeleteKey("stage");


                    // get CT scan results
                    else if (stage == 3)
                    {
                        PlayerPrefs.DeleteKey("CTstartpoint");
                        PlayerPrefs.DeleteKey("delaynotification");

                        welcomeSmoking.SetActive(false);
                        xrayResults.SetActive(false);
                        stopGoCtscan.SetActive(false);
                        CTresults.SetActive(true);
                        smokingDone.SetActive(false);
                        Player.transform.position = targetSmoking0.transform.position;
                        Player.transform.SetParent(targetSmoking0.transform);
                        PlayerPrefs.DeleteKey("delaynotification");
                        PlayerPrefs.DeleteKey("CTstartpoint");
                    }

                    else if (stage == 4)
                    {
                        //         Debug.Log("^^^ smoking4");

                        welcomeSmoking.SetActive(false);
                        xrayResults.SetActive(false);
                        stopGoCtscan.SetActive(false);
                        CTresults.SetActive(false);
                        smokingDone.SetActive(true);
                        Player.transform.position = targetSmoking0.transform.position;
                        Player.transform.SetParent(targetSmoking0.transform);
                    }
                    break;
                }
        }


    public void goToSectors()
    {
        notFilms.SetActive(true);
        hud.SetActive(true);
        terrain.SetActive(true);
        if (behaviour == "travel")
        {
       //     Debug.Log("^^^ travel");
            Player.transform.position = targetTravel.transform.position;
            Player.transform.SetParent(targetTravel.transform);
        }

        else if (behaviour == "calm")
        {
       //     Debug.Log("^^^ targetCalm");
            Player.transform.position = targetCalm.transform.position;
            Player.transform.SetParent(targetCalm.transform);
        }
        else if (behaviour == "adrenaline")
        {
       //     Debug.Log("^^^ targetAdrenaline");
            Player.transform.position = targetAdrenaline.transform.position;
            Player.transform.SetParent(targetAdrenaline.transform);
        }
        else if (behaviour == "museums")
        {
      //      Debug.Log("^^^ targetMuseums");
            Player.transform.position = targetMuseums.transform.position;
            Player.transform.SetParent(targetMuseums.transform);
        }
        else if (behaviour == "history")
        {
      //      Debug.Log("^^^ targetHistory");
            Player.transform.position = targetHistory.transform.position;
            Player.transform.SetParent(targetHistory.transform);
        }
        else if (behaviour == "beaches")
        {
       //     Debug.Log("^^^ targetBeaches");
            Player.transform.position = targetBeaches.transform.position;
            Player.transform.SetParent(targetBeaches.transform);
        }
        else if (behaviour == "parks")
        {
       //     Debug.Log("^^^ targetParks");
            Player.transform.position = targetParks.transform.position;
            Player.transform.SetParent(targetParks.transform);
        }
        else if (behaviour == "space")
        {
         //   Debug.Log("^^^ targetSpace");
            Player.transform.position = targetSpace.transform.position;
            Player.transform.SetParent(targetSpace.transform);
        }
    }
    public void gotophobias()
    {
      //  Debug.Log("^^^ phobias top");
        hud.SetActive(true);
        terrain.SetActive(true);
        //just uncommented; maybe recomment


        stage = PlayerPrefs.GetInt("stage");

        switch (behaviour)
        {
            case "heights":

                stage = PlayerPrefs.GetInt("stageHeights");

                //   Debug.Log("^^^ heights top");
                if (stage == 1)
                {
                    //        Debug.Log("^^^ heights 1");

                    Player.transform.position = targetPhobias1.transform.position;
                    Player.transform.SetParent(targetPhobias1.transform);


                }
                else if (stage == 2)
                {
                    //        Debug.Log("^^^ heights 2");
                    Player.transform.position = targetPhobias2.transform.position;
                    Player.transform.SetParent(targetPhobias2.transform);

                }
                else if (stage == 3)
                {
                    //         Debug.Log("^^^ heights 3");
                    Player.transform.position = targetPhobias3.transform.position;
                    Player.transform.SetParent(targetPhobias3.transform);
                }
                break;

            case "sharks":

                stage = PlayerPrefs.GetInt("stageSharks");

                //   Debug.Log("^^^ sharks");
                Player.transform.position = targetSharks.transform.position;
                Player.transform.SetParent(targetSharks.transform);
                break;
        }

        PlayerPrefs.DeleteKey("nextscene");
        notFilms.SetActive(true);
        

    }
    public void stopTheFilm()
    {
       // Debug.Log("^^^ stopTheFilm");
        notFilms.SetActive(true);
        terrain.SetActive(true);
        hud.SetActive(true);
        stopFilm = PlayerPrefs.GetInt("stopFilm");
        riroStopGo = FindObjectOfType<riroStopGo>();
        riroStopGo.doNotPass(stopFilm);
        Player.transform.position = interruptFilm.transform.position;
        Player.transform.SetParent(interruptFilm.transform);
        PlayerPrefs.DeleteKey("stopFilm");
    }
   
}
