using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class moveShowHide : MonoBehaviour
{
    
    public bool mousehover = false;
    public float Counter = 0;
    public GameObject player;
    public GameObject TargetObject;

   
    public GameObject alcoholintro;
    public GameObject alcoholfollow;
    public GameObject alcoholsolution;
    public GameObject alcoholfinish;
    
    
    public GameObject welcome;
    public GameObject xrayresults;
    public GameObject stopgoctscan;
    public GameObject CTresults;
    public GameObject smokingDone;

    //variables for playerprefs
    private int stage;
    private string nextscene;
    private string returntoscene;
    private int isLearning;
    private bool gotnextscene;
    private string behaviour;

 

    void Update()
    {

        if (mousehover)
        {

            Counter += Time.deltaTime;
            if (Counter >= 3)
            {
                mousehover = false;
                Counter = 0;
                //   hidewhat.SetActive(false);
                stage = PlayerPrefs.GetInt("stage");

                behaviour = PlayerPrefs.GetString("behaviour");
                if (behaviour == "alcohol")
                {
                    if (stage == 0)
                    {
                        alcoholintro.SetActive(true);
                        alcoholfollow.SetActive(false);
                        alcoholsolution.SetActive(false);
                        alcoholfinish.SetActive(false);
                    }
                    if (stage == 1)
                        alcoholintro.SetActive(false);
                    alcoholfollow.SetActive(true);
                    alcoholsolution.SetActive(false);
                    alcoholfinish.SetActive(false);
                }
                if (stage == 2)
                {
                    alcoholintro.SetActive(false);
                    alcoholfollow.SetActive(false);
                    alcoholsolution.SetActive(true);
                    alcoholfinish.SetActive(false);
                }
                if (stage == 3)
                {
                    alcoholintro.SetActive(false);
                    alcoholfollow.SetActive(false);
                    alcoholsolution.SetActive(false);
                    alcoholfinish.SetActive(true);
                }
            }

            if (behaviour == "smoking")
            {
                if (stage == 0)
                {
                    welcome.SetActive(true);
                    xrayresults.SetActive(false);
                    stopgoctscan.SetActive(false);
                    CTresults.SetActive(false);
                    smokingDone.SetActive(false);
                }
                else if (stage == 1)
                    welcome.SetActive(false);
                xrayresults.SetActive(true);
                stopgoctscan.SetActive(false);
                CTresults.SetActive(false);
                smokingDone.SetActive(false);
            }
            else if (stage == 2)
            {
                welcome.SetActive(false);
                xrayresults.SetActive(false);
                stopgoctscan.SetActive(true);
                CTresults.SetActive(false);
                smokingDone.SetActive(false);
            }
            else if (stage == 3)
            {
                welcome.SetActive(false);
                xrayresults.SetActive(false);
                stopgoctscan.SetActive(false);
                CTresults.SetActive(true);
                smokingDone.SetActive(false);
            }
            else if (stage == 4)
            {
                welcome.SetActive(false);
                xrayresults.SetActive(false);
                stopgoctscan.SetActive(false);
                CTresults.SetActive(false);
                smokingDone.SetActive(true);
            }
        }
                TargetObject.SetActive(true);
                player.transform.position = TargetObject.transform.position;
                //TargetObject.SetActive(true);
                player.transform.SetParent(TargetObject.transform);
                
               

           
    }
    

    // mouse Enter event
    public void MouseHoverChangeScene()
    {
        //Debug.Log("setting walk");
        // Markername = ObjectName;
        mousehover = true;
          
       
    
    }

    // mouse Exit Event
    public void MouseExit()
    {
      //  Debug.Log("cancelling walk");
       // Markername = "";
        mousehover = false;
        Counter = 0;
    }

   

}
