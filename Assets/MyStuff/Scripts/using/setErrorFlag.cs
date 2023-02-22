using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class setErrorFlag : MonoBehaviour
{

    public bool mousehover = false;
    public float counter = 0;
    int vrcount;
    // Start is called before the first frame update
    int showMessage;

    void Update()

    {
        if (mousehover)
        {
            counter += Time.deltaTime;
            if (counter >= 2.8)
            {

               // Debug.Log("fired");
                globalvariables.Instance.f_VRmessage = 1;
                //PlayerPrefs.SetInt("showMessage", 1);
                mousehover = false;
                counter = 0;
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

        mousehover = false;
        
        counter = 0;
    }

}
