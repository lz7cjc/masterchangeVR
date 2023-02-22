using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraAlt : MonoBehaviour
{
    public GameObject TargetObject;
    public bool mousehover = false;
    //public GameObject hidewhat;
    public float Counter = 0;
   // public bool childCamera;
    public GameObject player;
   // public GameObject cameratarget;
   
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
                TargetObject.SetActive(true);
                player.transform.position = TargetObject.transform.position;
                //TargetObject.SetActive(true);
                player.transform.SetParent(TargetObject.transform);
                
                

            }
        }
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
