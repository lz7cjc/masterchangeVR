using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class photoscore : MonoBehaviour
{
    public bool mousehover = false;
     private float Counter;
    
    private int badgescore;
    public int PainMultiplier;
    private float addbadgescore;
    public Text score;

    public void Start()
    {
        badgescore = PlayerPrefs.GetInt("badges");

    }
    void Update()
    {

       if (mousehover)
        { 
            Counter += Time.deltaTime;
            Debug.Log("score " + Counter);
            //  mousehover = false;
            //Counter = 0;
            addbadgescore = Counter * PainMultiplier;
            addbadgescore = Mathf.Round(addbadgescore);
            badgescore = badgescore + (int)addbadgescore; 
            score.IsActive();
            score.text = badgescore.ToString();
        }
            
            
    }

    
    public void MouseHoverChangeScene()
    {
        mousehover = true;
    }

    // mouse Exit Event
    public void MouseExit()
    {
        Debug.Log("cancelling walk");
       // Markername = "";
        mousehover = false;
        addbadgescore = Counter * PainMultiplier;
        addbadgescore = Mathf.Round(addbadgescore);
        badgescore = badgescore + (int)addbadgescore;
                PlayerPrefs.SetInt("badgescore", badgescore);
       
        Counter = 0;
    }

   

}
