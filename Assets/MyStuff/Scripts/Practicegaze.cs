using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Practicegaze : MonoBehaviour

{
    public bool mousehover = false;
    public float Counter = 0;
   // public string Markername;
    public Text MyText = null;
   // public AudioClip bcgMusic;

    //void Start()
    //{
    //    PlayerPrefs.SetInt("beeninworld",1);


    //}
    // Update is called once per frame

    void Update()
    {
        //Debug.Log("counter level" + Counter);
        if (mousehover)
        {

            Counter += Time.deltaTime;
                 
                    
                    
            if (Counter >= 3)

            {
                mousehover = false;
                Counter = 0;
                //put the action required here
                Debug.Log("triggered new message");
                MyText.text = "Congratulations, you can now choose things in this world. Now you have two choices. If you suffer from motion sickness, or understand how to choose things, we suggest you look behind you for the Skip Level sign. Otherwise look for a small sign to your right: Teleport to the Vehicles. Look at it for around 3 seconds to teleport to the vehicles";
              // AudioSource.PlayClipAtPoint(bcgMusic, transform.position);
            }
        }
    }

    // mouse Enter event
    public void MouseHoverChangeScene()
    {
       Debug.Log("setting look");
       // Markername = ObjectName;
        mousehover = true;
    }

    // mouse Exit Event
    public void MouseExit()
    {
        Debug.Log("cancelling look");
      //  Markername = "";
        mousehover = false;
        Counter = 0;
    }



}
