using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnToHome : MonoBehaviour
{

    public bool mousehover = false;

    public float Counter = 0;

    public GameObject player;
    public GameObject cameratarget;
    
    private int getStage;

    public string behaviour;
    private showhide3d showhide3d;
    private int putStage;
    private int trainingDone;
    private floorceilingmove floorceilingmove;

    public SpriteRenderer spriterenderer;
    public Sprite spriteDefault;
    public Sprite spriteSwitch;

    //////
    /// <summary>
    /// Option 1 - Return to Start
    /// Option 2 - Back one Step
    /// Option 3 - Go to experiences
    /// Option 3 - Go to reception
    /// 
    /// </summary>
    [Tooltip("Option 1 - Return to Start of BC | Option 2 - Back one Step | Option 3 - Go to Main Experiences Room | Option 4 - go back to reception | Option 5 - cancel BCT")]
        public int chooseOption;

    private void Start()
    {
        trainingDone = PlayerPrefs.GetInt("trainingDone");
        Debug.Log("eee button option1 : " + trainingDone);
        Debug.Log("eee chooseOption : " + chooseOption);
        //getStage = PlayerPrefs.GetInt("stage");
        //behaviour = PlayerPrefs.GetString("behaviour");
        Debug.Log("trainingDone: " + trainingDone);
    }

    void Update()
    {
   
        if (mousehover)
        {
            floorceilingmove = FindObjectOfType<floorceilingmove>();
            floorceilingmove.stopTheCamera();
            Counter += Time.deltaTime;
            if (Counter >= 3)
            {    
                
                mousehover = false;
                Counter = 0;
                //Return to Start of BC
                if (chooseOption == 1)
                    //return to start
                {
                    PlayerPrefs.SetInt("trainingDone", 1);
                    PlayerPrefs.SetInt("stage", 0);
                    PlayerPrefs.DeleteKey("CTStartPoint");
                    PlayerPrefs.DeleteKey("delaynotification");
                   
                }
                else if (chooseOption == 2)
                //back one step
                {
                    PlayerPrefs.SetInt("trainingDone", 1);
                    getStage = PlayerPrefs.GetInt("stage");
                    putStage = getStage - 1;
                    PlayerPrefs.SetString("nextscene", "hospital");
                    PlayerPrefs.SetInt("stage", putStage);
                }
                //go to activity centre and cancel behaviour
                else if  (chooseOption == 3)
                {
                    PlayerPrefs.SetInt("trainingDone", 1);
                    PlayerPrefs.DeleteKey("stage");
                    PlayerPrefs.DeleteKey("behaviour");
                    PlayerPrefs.DeleteKey("nextscene");
                    PlayerPrefs.DeleteKey("returntoscene");
                }
                // go to reception
                else if (chooseOption == 4)
                {
                    PlayerPrefs.SetInt("trainingDone", 0);
                    PlayerPrefs.DeleteKey("stage");
                    PlayerPrefs.DeleteKey("behaviour");
                    PlayerPrefs.DeleteKey("nextscene");
                    PlayerPrefs.DeleteKey("returntoscene");
                }

               
                Debug.Log("button option : " + trainingDone);

                showandhide();

            }
        }
    }

    // mouse Enter event
    public void MouseHoverChangeScene()
    {
     //   Debug.Log("setting walk");
        // Markername = ObjectName;
        mousehover = true;

    }
    public void MouseHoverChangeSceneHud()
    {
        //   Debug.Log("setting walk");
        // Markername = ObjectName;
        mousehover = true;
        spriterenderer.sprite = spriteSwitch;
    }


    // mouse Exit Event
    public void MouseExit()
    {
     //   Debug.Log("cancelling walk");
       // Markername = "";
        mousehover = false;
        Counter = 0;
    }

    public void MouseExitHUD()
    {
        //   Debug.Log("cancelling walk");
        // Markername = "";
        mousehover = false;
        Counter = 0;
        spriterenderer.sprite = spriteDefault;
    }
    private void showandhide()
    {
        Debug.Log("calling showhide3d kkk");
        //    TargetObject.SetActive(true);
        player.transform.position = cameratarget.transform.position;
        //TargetObject.SetActive(true);
        player.transform.SetParent(cameratarget.transform);
        showhide3d = FindObjectOfType<showhide3d>();
        showhide3d.ResetScene();


    }
   

}
