using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class countdowntimer : MonoBehaviour
{
    public float startTime = 30f; 
    private float timeRemaining;
    public Text displayTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  startTime = PlayerPrefs.GetFloat("startTime");
        timeRemaining -= startTime;
        Debug.Log("time left: " + timeRemaining);
        displayTime.text =  timeRemaining.ToString("hh':'mm':'ss");
    }
}
