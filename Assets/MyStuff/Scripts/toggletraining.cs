using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggletraining : MonoBehaviour
{
    public bool mousehover = false;
    public float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (mousehover)
        {
            counter += Time.deltaTime;
            if (counter >= 3)
            {
                mousehover = false;
                counter = 0;
                PlayerPrefs.SetInt("SkipLearningScreenInt", 1);

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


