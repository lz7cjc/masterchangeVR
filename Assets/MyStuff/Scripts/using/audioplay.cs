using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioplay : MonoBehaviour
{
    public AudioSource audiofile;
    // Start is called before the first frame update
    public bool mousehover = false;
    public float Counter = 0;
 

    void Update()
    {

        if (mousehover)
        {

            Counter += Time.deltaTime;
            audiofile.Play();
                mousehover = false;
                Counter = 0;
              
            
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
        audiofile.Pause();

        mousehover = false;
        Counter = 0;
    }

}
