using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraAlt2 : MonoBehaviour
{
    public GameObject carrierObject;
    public GameObject showsign;
    public bool mousehover = false;
    //public GameObject hidewhat;
    public float Counter = 0;
   // public bool childCamera;
    public GameObject player;
    // public GameObject cameratarget;
   // public int returnlevel;
   // public string nextscene;
  //  public string postfilmscene;

    void Update()
    {

        if (mousehover)
        {

            Counter += Time.deltaTime;
            if (Counter >= 3)
            {
                showsign.SetActive(true);

                mousehover = false;
                Counter = 0;
                showsign.SetActive(true);
                player.transform.position = carrierObject.transform.position;
                Debug.Log("should be moving hte camer");
                //TargetObject.SetActive(true);
                player.transform.SetParent(carrierObject.transform);
             //   PlayerPrefs.SetInt("stage", returnlevel);
                //if (nextscene != null)
                //{
                //    PlayerPrefs.SetString("nextscene", nextscene);
                //}

                //PlayerPrefs.SetString("returntoscene", postfilmscene);

            }
        }
    }

    // mouse Enter event
    public void MouseHoverChangeScene()
    {
        Debug.Log("setting walk");
        // Markername = ObjectName;
        mousehover = true;
       


    }

    // mouse Exit Event
    public void MouseExit()
    {
        Debug.Log("cancelling walk");
       // Markername = "";
        mousehover = false;
        Counter = 0;
    }

   

}
