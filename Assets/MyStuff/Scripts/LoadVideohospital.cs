using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadVideohospital : MonoBehaviour
{
    public bool mousehover = false;
    public float counter = 0;
    public string Switchscenename;
    private object Scenename;
    public string VideoUrlLink;
    

    public void Start()
    {
        
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

                    if (VideoUrlLink != "")
                    {
                        PlayerPrefs.SetString("VideoUrl", VideoUrlLink);
                        print("---->>>" + PlayerPrefs.GetString("VideoUrl"));
                        Debug.Log("should be switching" + Switchscenename);
                        SceneManager.LoadScene(Switchscenename);
                    }
                

               

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
           
}

   


