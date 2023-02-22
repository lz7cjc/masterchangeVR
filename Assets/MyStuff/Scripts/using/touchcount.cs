using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Networking;

using UnityEngine.SceneManagement;

public class touchcount : MonoBehaviour

{
    // public Text textmessage;
    private int touches;
    public Text touchcounti;
    private int touchcounter;
    // Start is called before the first frame update
  
    
    public void touchesr()
    {
       touches = Input.touches.Length;
        Debug.Log("input touches" + touches);
        touchcounter = touchcounter + touches ;
        Debug.Log("running count: " + touchcounter);
        
        touchcounti.text = "the number of touches is: " + touchcounter.ToString();
      
    }

    void Update()
    {
        var fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
            }
        }
        if (fingerCount > 0)
        {
            print("User has " + fingerCount + " finger(s) touching the screen");
        }

    }


}
