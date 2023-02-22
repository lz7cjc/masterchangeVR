using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Net;

//this is used when coming from a different scene
public class showhide4d : MonoBehaviour
{
    //moving camera
   // public GameObject player;
    public GameObject MainCamera;

    //targets
    public GameObject targetMainSmall;
    //public GameObject targetTrainingPos;
    public GameObject targetPhobias1;
    public GameObject targetPhobias2;
    public GameObject targetPhobias3;
    public GameObject targetSharks;
    public GameObject targethospital0;
    public GameObject targethospital1;
    public GameObject targethospital2;
    public GameObject targethospital3;
    public GameObject targethospital4;

    public GameObject targetalcohol1;
    public GameObject targetalcohol2;
    public GameObject targetalcohol3;
    public GameObject targetalcohol4;
    public GameObject chatTarget;
    public GameObject waitingtgt;
    public GameObject targetfilm;
    public GameObject targettip;



    //variables for playerprefs
    private int stage;
    private string nextscene;
    private string returntoscene;
    private int isLearning;
    private bool gotnextscene;
    private string behaviour;

    //show/hide sections
   // public GameObject TrainingLevel;
    public GameObject Main;
    //public GameObject terrain;
    public GameObject films;
     public GameObject hospital;
    public GameObject phobia;
    public GameObject chat;
    public Transform level2signs;



    //  public GameObject shoot;


    public GameObject signs;
    public GameObject alcohol;
    public GameObject alcoholintro;
    public GameObject alcoholfollow;
    public GameObject alcoholsolution;
    public GameObject alcoholfinish;
    public GameObject welcome;
    public GameObject xrayresults;
    public GameObject stopgoctscan;
    public GameObject CTresults;
    public GameObject smokingDone;
    public GameObject tip;
    public GameObject smoking;
    public videocontrollerff videoController;

    private justGetRiros justGetRiros;
    private setCTdate setCTdate;


    private void Start()
    {
       Debug.Log("in start of showhide3d script");
        ResetScene();
        // PlayerPrefs.DeleteKey("nextscene");

        
    }
    //get player prefs
   
    /// <summary>
    /// check to see if there is a next scene set. This is used when leaving VR and going back in or when playing a film,
    /// so you are taken back to the right place. 
    ///     /// </summary>
    public void ResetScene()
    {
     
         Debug.Log("hh1 what is nextscene0 " + nextscene);

        //get player prefs and assign to variables
        isLearning = PlayerPrefs.GetInt("SkipLearningScreenInt");
        returntoscene = PlayerPrefs.GetString("returntoscene");
        stage = PlayerPrefs.GetInt("stage");
        Debug.Log("hh2 what stage is it" + stage);
        behaviour = PlayerPrefs.GetString("behaviour");
    Debug.Log("hh3 stage at start of showhide file: " + stage);
        nextscene = PlayerPrefs.GetString("nextscene");
      Debug.Log("hh4 what is nextscene setto" + nextscene); 
        if ((nextscene == ""))
        {
            PlayerPrefs.DeleteKey("nextscene");
           Debug.Log("hh5next scene is blank");
            gotnextscene = false;
        }
        else if ((!PlayerPrefs.HasKey("nextscene")))
        {

            gotnextscene = false;
        }
        else
        {
            Debug.Log("hh6next scene is not blank");

            gotnextscene = true;
        }

        if (returntoscene == "")
        {
          Debug.Log("hh7 returntoscene is blank");

            PlayerPrefs.DeleteKey("returntoscene");
        }

     //   Debug.Log("hh8 in ResetScene of showhide3d script");
        if ((PlayerPrefs.HasKey("returntoscene")) && (!gotnextscene))
        {
          Debug.Log("hh9 where there is no nextscene but there is a return to scene");
            PlayerPrefs.SetString("nextscene", returntoscene);
            nextscene = PlayerPrefs.GetString("nextscene");
       
            PlayerPrefs.DeleteKey("returntoscene");
            
        }
        goToNextScene();
    }

    private void goToNextScene()

    {

        Debug.Log("hh10 where there is an nextscene in function ");

        if (nextscene == "hospital")
        {
            gotohospital();
          Debug.Log("hh11 go to nextscene hospital");

        }

        else if (nextscene == "phobia" )
        {
          Debug.Log("hh12 in returntoscene phobia go to function");
            gotophobias();

        }

        else if (nextscene == "film")
        {
            //////////////////////
            ///when switching to alt scene as pp not working with videoplayer
         //   SceneManager.LoadScene("filmplayer");
         //   PlayerPrefs.DeleteKey("nextscene");
         ///////////////////////////
          
            //4.0.1 change to load different scene

               Debug.Log("hh13 playing film");
            Main.SetActive(false);
         //   TrainingLevel.SetActive(false);
            films.SetActive(true);
            hospital.SetActive(false);
          //  terrain.SetActive(false);
            tip.SetActive(false);
            phobia.SetActive(false);
            //  shoot.SetActive(false);

            MainCamera.transform.position = targetfilm.transform.position;
            MainCamera.transform.SetParent(targetfilm.transform);
            PlayerPrefs.DeleteKey("nextscene");


            if (videoController == null)
            {
                videoController = FindObjectOfType<videocontrollerff>();
            }

            if (videoController)
            {
                Debug.Log("hh14 Request a new video play");
            //    videoController.RequestYoutubeStart();
            }

        }

        else if (nextscene == "tip")
        {
            Main.SetActive(false);
          //  TrainingLevel.SetActive(false);
            films.SetActive(false);
            hospital.SetActive(false);
          //  terrain.SetActive(false);
            tip.SetActive(true);
            phobia.SetActive(false);
            chat.SetActive(false);
            //shoot.SetActive(false);
        Debug.Log("hh15 playing tips scene");
            PlayerPrefs.DeleteKey("nextscene");

          


            MainCamera.transform.position = targettip.transform.position;
            MainCamera.transform.SetParent(targettip.transform);
        }

        else if (nextscene == "register")
        {
            SceneManager.LoadScene("register");
            PlayerPrefs.DeleteKey("nextscene");


        }

        else if (nextscene == "dashboard")
        {
            SceneManager.LoadScene("dashboard");
            PlayerPrefs.DeleteKey("nextscene");

        }

        else
        {
            gotrainandstart();
        }
    }
   
private void gotrainandstart()


        {
        for (int j = 0; j < level2signs.childCount; j++)
        {
            level2signs.GetChild(j).gameObject.SetActive(false);
        }

        // isLearning = PlayerPrefs.GetInt("SkipLearningScreenInt");
          Debug.Log("hh16 in learning as have key");

        if (isLearning == 0)
            {
                Debug.Log("hh17 in go to learning");

                Main.SetActive(false);
            //    TrainingLevel.SetActive(true);
                films.SetActive(false);
           //     terrain.SetActive(true);
                hospital.SetActive(false);
                tip.SetActive(false);
                phobia.SetActive(false);
            chat.SetActive(false);
            signs.SetActive(false);
            //shoot.SetActive(false);

           // MainCamera.transform.position = targetTrainingPos.transform.position;
            //    MainCamera.transform.SetParent(targetTrainingPos.transform);
                PlayerPrefs.DeleteKey("nextscene");
              //  PlayerPrefs.DeleteKey("stage");
            }
            else if (isLearning == 1)
            {
           Debug.Log("hh18 in final else");

           Debug.Log("hh19 in smallsigns");
            Main.SetActive(true);
            signs.SetActive(true);
          //  terrain.SetActive(true);
         
            //added 13/12 to try to get hospital to appear when moving through smoking stages

        //    TrainingLevel.SetActive(false);
        if ((behaviour =="") || (!PlayerPrefs.HasKey("behaviour")))
            { 
            films.SetActive(false);
            hospital.SetActive(false);
               tip.SetActive(false);
            phobia.SetActive(false);
            chat.SetActive(false);

            MainCamera.transform.position = targetMainSmall.transform.position;
            MainCamera.transform.SetParent(targetMainSmall.transform);
            }
            else
            {
                gotohospital();
            }
        //end of new changes
        }
         }
    public void gotohospital()
    {
            Debug.Log("hh20 in hospital function");

        behaviour = PlayerPrefs.GetString("behaviour");
        hospital.SetActive(true);

        Main.SetActive(false);
       // TrainingLevel.SetActive(false);
        films.SetActive(false);
    //    terrain.SetActive(true);
        tip.SetActive(false);
        phobia.SetActive(false);
        chat.SetActive(false);

        //  shoot.SetActive(false);
        if (behaviour == "alcohol")

        {
            alcohol.SetActive(true);
            smoking.SetActive(false);

            if (stage == 0)
            {
                      Debug.Log("hh21 alcohol.SetActive(true)");
                alcoholintro.SetActive(true);

                welcome.SetActive(false);
                xrayresults.SetActive(false);
                stopgoctscan.SetActive(false);
                CTresults.SetActive(false);
                alcoholfollow.SetActive(false);
                alcoholsolution.SetActive(false);
                alcoholfinish.SetActive(false);
                MainCamera.transform.position = targetalcohol1.transform.position;
                MainCamera.transform.SetParent(targetalcohol1.transform);

            }
            if (stage == 1)
            {
                            Debug.Log("hh22 in returntoscene hosp0");
                alcoholfollow.SetActive(true);

                welcome.SetActive(false);
                xrayresults.SetActive(false);
                stopgoctscan.SetActive(false);
                CTresults.SetActive(false);
                alcoholintro.SetActive(false);
                alcoholsolution.SetActive(false);
                alcoholfinish.SetActive(false);

                MainCamera.transform.position = targetalcohol2.transform.position;
                MainCamera.transform.SetParent(targetalcohol2.transform);

            }
            if (stage == 2)
            {
                              Debug.Log("hh23 in returntoscene hosp0");
                alcoholsolution.SetActive(true);

                welcome.SetActive(false);
                xrayresults.SetActive(false);
                stopgoctscan.SetActive(false);
                CTresults.SetActive(false);
                alcoholintro.SetActive(false);
                alcoholfollow.SetActive(false);
                alcoholfinish.SetActive(false);

                MainCamera.transform.position = targetalcohol3.transform.position;
                MainCamera.transform.SetParent(targetalcohol3.transform);

            }

            if (stage == 3)
            {
                               Debug.Log("hh24 in returntoscene hosp0");
                alcoholfinish.SetActive(true);
                welcome.SetActive(false);
                xrayresults.SetActive(false);
                stopgoctscan.SetActive(false);
                CTresults.SetActive(false);
                alcoholintro.SetActive(false);
                alcoholfollow.SetActive(false);
                alcoholsolution.SetActive(false);

                MainCamera.transform.position = targetalcohol4.transform.position;
                MainCamera.transform.SetParent(targetalcohol4.transform);

            }
            //starthosp.SetActive(false);
            //xraydone.SetActive(false);
            //ctscandone.SetActive(false);
            //alcoholintro.SetActive(true);
            //MainCamera.transform.position = targetalcohol1.transform.position;
            //MainCamera.transform.SetParent(targetalcohol1.transform);

        }
        else if (behaviour == "smoking")
        {
            smoking.SetActive(true);
            alcohol.SetActive(false);

            //Welcome to smoking
            if (stage == 0)
            {
                Debug.Log("hh25 5555 in returntoscene hosp0");

                welcome.SetActive(true);
                xrayresults.SetActive(false);
                stopgoctscan.SetActive(false);
                CTresults.SetActive(false);
                smokingDone.SetActive(false);
                MainCamera.transform.position = targethospital0.transform.position;
                MainCamera.transform.SetParent(targethospital0.transform);

            }
            //Get XRay Results
            else if (stage == 1)
            {
                Debug.Log("hh26 in returntoscene hosp1");

                welcome.SetActive(false);
                xrayresults.SetActive(true);
                stopgoctscan.SetActive(false);
                CTresults.SetActive(false);
                smokingDone.SetActive(false);
                MainCamera.transform.position = targethospital1.transform.position;
                MainCamera.transform.SetParent(targethospital1.transform);

            }

            //book CT Scan and go for scan when allowed
            else if (stage == 2)
            {
                      Debug.Log("hh27 in returntoscene hosp2");

                welcome.SetActive(false);
                xrayresults.SetActive(false);
                stopgoctscan.SetActive(true);
                CTresults.SetActive(false);
                smokingDone.SetActive(false);

                setCTdate = FindObjectOfType<setCTdate>();
                setCTdate.setScene();

                if (PlayerPrefs.GetInt("delaynotification") >= 0)
                {
                    Debug.Log("hh28 delaynotification greater or equal to zero");
                    MainCamera.transform.position = waitingtgt.transform.position;
                    MainCamera.transform.SetParent(waitingtgt.transform);
                }
                else
                {
                    Debug.Log("hh29 delaynotification less than or equal to zero");
                    MainCamera.transform.position = targethospital2.transform.position;
                MainCamera.transform.SetParent(targethospital2.transform);

                }
                Debug.Log("hh30 how about here llll");
            }

            //    PlayerPrefs.DeleteKey("nextscene");
            //     PlayerPrefs.DeleteKey("stage");


            // get CT scan results
            else if (stage == 3)
            {
                Debug.Log("hh31 reset sections llll");

                welcome.SetActive(false);
                xrayresults.SetActive(false);
                stopgoctscan.SetActive(false);
                CTresults.SetActive(true);
                smokingDone.SetActive(false);
                MainCamera.transform.position = targethospital3.transform.position;
                MainCamera.transform.SetParent(targethospital3.transform);

            }
           // Debug.Log("hh32 how about here llll");
           // PlayerPrefs.DeleteKey("nextscene");
            //     PlayerPrefs.DeleteKey("stage");
        
        else if (stage == 4)
        {
            Debug.Log("hh32 reset sections in done");

            welcome.SetActive(false);
            xrayresults.SetActive(false);
            stopgoctscan.SetActive(false);
            CTresults.SetActive(false);
            smokingDone.SetActive(true);
            MainCamera.transform.position = targethospital4.transform.position;
            MainCamera.transform.SetParent(targethospital4.transform);

        }
       // Debug.Log("hh32 how about here llll");
      //  PlayerPrefs.DeleteKey("nextscene");
        //     PlayerPrefs.DeleteKey("stage");
    }
}

    public void gotophobias()
    {
        //just uncommented; maybe recomment
        stage = PlayerPrefs.GetInt("stage");
        Main.SetActive(true);
       // TrainingLevel.SetActive(false);
        films.SetActive(false);
        hospital.SetActive(false);
    //    terrain.SetActive(true);
        tip.SetActive(false);
        phobia.SetActive(true);
        chat.SetActive(false);

        // shoot.SetActive(false);
        if (behaviour == "heights")
        {
            if (stage == 1)
            {
                //       Debug.Log("hh33 in returntoscene phobia1");

                MainCamera.transform.position = targetPhobias1.transform.position;
                MainCamera.transform.SetParent(targetPhobias1.transform);


            }
            else if (stage == 2)
            {
                //     Debug.Log("hh34 in returntoscene phobia2");

                MainCamera.transform.position = targetPhobias2.transform.position;
                MainCamera.transform.SetParent(targetPhobias2.transform);

            }
            else if (stage == 3)
            {
                //      Debug.Log("hh35 in nextscene phobia3");

                MainCamera.transform.position = targetPhobias3.transform.position;
                MainCamera.transform.SetParent(targetPhobias3.transform);
            }
        }

        else if (behaviour == "sharks")
        {
            //      Debug.Log("hh36 in nextscene phobia3");

            MainCamera.transform.position = targetSharks.transform.position;
            MainCamera.transform.SetParent(targetSharks.transform);
        }

        PlayerPrefs.DeleteKey("nextscene");
        PlayerPrefs.DeleteKey("behaviour");
       // PlayerPrefs.DeleteKey("stage");
    }

    /// <summary>
    /// new section for chat - commented out until I know more 
    /// </summary>
    public void goToChat()
    {
        Main.SetActive(false);
      //  TrainingLevel.SetActive(false);
        films.SetActive(false);
        hospital.SetActive(false);
      //  terrain.SetActive(true);
        tip.SetActive(false);
        phobia.SetActive(false);
        chat.SetActive(true);
        MainCamera.transform.position = chatTarget.transform.position;
        MainCamera.transform.SetParent(chatTarget.transform);


    }
}
