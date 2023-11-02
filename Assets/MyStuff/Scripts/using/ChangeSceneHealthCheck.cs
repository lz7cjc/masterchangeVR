using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeSceneHealthCheck : MonoBehaviour
{

    public bool mousehover = false;
    public float counter = 0;
    private showhide3d showhide3d;
    private bool youshallpass;
    public string behaviour;
    private string whichScene;
    private bool form;
    public int stage;
    private int habitsvalue;
    private bool tempStop;
    private floorceilingmove floorceilingmove;
    private float stopCounter;
    private int riros;
   // private int typeBehaviour;
    private int stopFilm;
   // private string nextScene;
    // public GameObject hospital;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (mousehover)
        {
            Debug.Log("ttt script running");
            youshallpass = PlayerPrefs.HasKey("habitsdone");
            habitsvalue = PlayerPrefs.GetInt("habitsdone");
          //  PlayerPrefs.SetString("nextscene", "hospital");
            Debug.Log("behaviour is " + behaviour);
            riros = PlayerPrefs.GetInt("rirosBalance");
            //if alcohol then go straight to hospital 

            if ((behaviour == "alcohol") && (riros >= 50))
            {
                form = false;
                //stopFilm = 2;

            }
            //else if ((behaviour == "alcohol") && (riros <= 50))
            //{
            //    form = false;
            //    stopFilm = 2;

            //}
            else if ((habitsvalue == 1) && (behaviour == "smoking") && (riros >= 50))
            {
               
                form = false;
                Debug.Log("ooo form value should be able to move forward = " + form);
            }

            else
            {   stopFilm = 1;
                form = true;
                Debug.Log("ooo form value should NOT be able to move forward = " + form);
            }
            Debug.Log("form value = " + form);
            counter += Time.deltaTime;
            if (counter >= 3)
            {
                Debug.Log("ttt in mousehover" + stage);
                PlayerPrefs.SetString("behaviour", behaviour);
                behaviour = PlayerPrefs.GetString("behaviour");
                PlayerPrefs.SetString("returntoscene", "hospital");
                //needed to go back a step, does this screw up normal operation?
                if (behaviour == "smoking")
                {

                
                if (!PlayerPrefs.HasKey("stageSmoking"))
                { 
                    PlayerPrefs.SetInt("stageSmoking", stage);
                }
                mousehover = false;
                counter = 0;
                    // name of scene which you want to load
                }
               else if (behaviour == "alcohol")
                {


                    if (!PlayerPrefs.HasKey("stageAlcohol"))
                    {
                        PlayerPrefs.SetInt("stageAlcohol", stage);
                    }
                    mousehover = false;
                    counter = 0;
                    // name of scene which you want to load
                }
                if ((!form) && (!PlayerPrefs.HasKey("stopFilm")))
                {
                    Debug.Log("55555 in !form");
                  Debug.Log("Stage from PP" + PlayerPrefs.GetInt("stage"));
                      if (!PlayerPrefs.HasKey("stage") && (behaviour == "smoking"))
                    {
                        PlayerPrefs.SetInt("stageSmoking", stage);
                    }
                    else if (!PlayerPrefs.HasKey("stageAlcohol") && (behaviour == "alcohol"))
                    {
                        PlayerPrefs.SetInt("stageAlcohol", stage);
                    }

                    PlayerPrefs.SetString("nextscene", "hospital");
                    //    hospital.SetActive(true);
                }
                else

                {
                    PlayerPrefs.SetInt("stopFilm", stopFilm);
                    Debug.Log("have set stop to film ooo");
                }
                
              
               
                showhide3d = FindObjectOfType<showhide3d>();
                showhide3d.ResetScene();
            }
        }
    }



    // mouse Enter event
    public void MouseHoverChangeScene()
    {
        //  Debug.Log("setting scenename");
        // Debug.Log("behaviour to begin with: " + Behaviour);
        startStopMove(tempStop = true);
        mousehover = true;
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
            stopCounter += Time.deltaTime;
            Debug.Log("stopcounter jjj" + stopCounter);
            if (stopCounter >=.01)
            { 
                floorceilingmove = FindObjectOfType<floorceilingmove>();
                floorceilingmove.stopTheCamera();
            }


        }

        //else if (!tempStop)
        //{
        //    floorceilingmove = FindObjectOfType<floorceilingmove>();
        //    floorceilingmove.LetsGo();
        //}
    }



}