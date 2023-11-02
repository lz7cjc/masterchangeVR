using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class switchText : MonoBehaviour
{
   
    //public Text postText;
    public bool mousehover = false;
    public float counter = 0;
    private floorceilingmove floorceilingmove;
    private bool tempStop;
    public GameObject steps;
    public GameObject home;
    public GameObject location;
    public GameObject instructions2;
    public GameObject instructions3;
    public GameObject instructions1;
    public GameObject icons;
    private int whichInstruction;

    // Start is called before the first frame update
    public void Start() 
    {
        
        instructions3.SetActive(false);
        instructions2.SetActive(false);
        instructions1.SetActive(true);
        icons.SetActive(false);

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

                if (whichInstruction == 2)
                {
                    
                    
                    instructions2.SetActive(true);
                    instructions1.SetActive(false);
                    instructions3.SetActive(false);
                    icons.SetActive(false);
                }
                else if (whichInstruction ==3)
                {
                   
                    instructions2.SetActive(false);
                    instructions1.SetActive(false);
                    instructions3.SetActive(true);
                    icons.SetActive(true);
                }
            }
        }
    }



    // mouse Enter event
    public void MouseHoverChangeScene(int getInstruction)
    {

        startStopMove(tempStop = true);
        mousehover = true;
        whichInstruction = getInstruction;
    }

    // mouse Exit Event
    public void MouseExit()
    {

        mousehover = false;
        counter = 0;
    }
    private void startStopMove(bool tempStop)
    {
        if (tempStop)
        {
            floorceilingmove = FindObjectOfType<floorceilingmove>();
            floorceilingmove.stopTheCamera();

        }
    }
}
