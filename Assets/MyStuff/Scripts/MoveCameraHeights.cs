using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraHeights : MonoBehaviour
{
    public GameObject carrierObject;
    public GameObject showsign;
    public bool mousehover = false;
    public GameObject showpulpit;
    public float Counter = 0;
    public Rigidbody player;
    public int stage;
    public Quaternion changeRotation;
    public bool useGravity = true;
    public string nextScene;
    public string behaviour;
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
                showpulpit.SetActive(true);
                if (!useGravity)
                {
                    player.useGravity = false;
                }
                player.transform.position = carrierObject.transform.position;
                Debug.Log("should be moving hte camer");
                PlayerPrefs.SetString("nextscene", nextScene);
                PlayerPrefs.SetString("behaviour", behaviour);
                //TargetObject.SetActive(true);
                PlayerPrefs.SetInt("stage", stage);
                player.transform.localRotation = changeRotation;
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
