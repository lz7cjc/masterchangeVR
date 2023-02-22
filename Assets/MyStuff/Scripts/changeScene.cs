using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;
public class changeScene : MonoBehaviour
{

    public bool mousehover = false;
    public bool toForms;
    public float counter = 0;
    private string Switchscenename;
  

   
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
                //      Debug.Log("should be switching" + Switchscenename);

             //   if (toForms)
            //    { 
                    StopXR();
            //    }
                
                SceneManager.LoadScene(Switchscenename);
            }   
            
        }
    }

    // mouse Enter event
    public void MouseHoverChangeScene(string Scenename)
    {
    //    Debug.Log("setting scenename");
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

    public void StopXR()
    {
        XRGeneralSettings.Instance.Manager.StopSubsystems();
       // XRGeneralSettings.Instance.Manager.DeinitializeLoader();

        //var xrManager = XRGeneralSettings.Instance.Manager;
        //if (!xrManager.isInitializationComplete)
        //    return; // Safety check
        //xrManager.StopSubsystems();
        // xrManager.DeinitializeLoader();
    }


}