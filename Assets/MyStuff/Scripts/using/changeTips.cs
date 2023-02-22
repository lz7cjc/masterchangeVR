using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class changeTips : MonoBehaviour
{

    public bool mousehover = false;
    public float counter = 0;
    private string Switchscenename;
    private allmytips allmytips;
    private int contenttype1;
    public TMP_Text whichsign;
    private void Start()
    {
        //if (PlayerPrefs.HasKey("returnToScene"))
        //{
        //    Switchscenename = PlayerPrefs.GetString("returnToScene");
        //    PlayerPrefs.DeleteKey("returnToScene");
        //}
        //else
        //{ 
        //    Switchscenename = "otherlandscape";
        //}
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
                Debug.Log("contenttype1 in last function: " + contenttype1);
                // name of scene which you want to load
                //      Debug.Log("should be switching" + Switchscenename);
                allmytips = FindObjectOfType<allmytips>();
                  allmytips.contenttype = contenttype1;
                allmytips.ContentBody = whichsign;
                  allmytips.CallRegisterCoroutine();


            }

        }
    }

    // mouse Enter event
    public void MouseHoverChangeScene(int contentType)
    {
    //    Debug.Log("setting scenename");
         mousehover = true;
        contenttype1 = contentType;
        Debug.Log("contenttype: " + contentType);
        Debug.Log("contenttype1: " + contenttype1);
    }

    // mouse Exit Event
    public void MouseExit()
    {
        // Debug.Log("cancelling scene change");
        mousehover = false;
        counter = 0;
    }



}