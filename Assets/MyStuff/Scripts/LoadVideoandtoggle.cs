using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class LoadVideoandtoggle : MonoBehaviour
{
    public bool mousehover = false;
    public float counter = 0;
    public string Switchscenename;
    private object Scenename;
    public string VideoUrlLink;
    public int hospitalScene;
    public string returnScene;

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
                PlayerPrefs.SetInt("hospitalScene", hospitalScene);
                SceneManager.LoadScene(Switchscenename);
                if (VideoUrlLink != "")
                {
                    PlayerPrefs.SetString("VideoUrl", VideoUrlLink);
                    PlayerPrefs.SetString("returnToScene", returnScene);
                    print("---->>>" + PlayerPrefs.GetString("VideoUrl"));
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

   


