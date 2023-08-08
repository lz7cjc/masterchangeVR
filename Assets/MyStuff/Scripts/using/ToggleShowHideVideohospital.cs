using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ToggleShowHideVideohospital : MonoBehaviour
{
    public bool mousehover = false;
    public float counter = 0;
    //public string Switchscenename;
     public string VideoUrlLink;
    //  private int riroAmount;
    //  public Text noRiros;
    //  public GameObject registerCanvas;
    //   public Text registertext;
    // public GameObject hospital;
   // public GameObject filmstuff;
    // public GameObject terrain;
    // public GameObject main;
    // public GameObject training;
    // public GameObject voting;
    // public GameObject player;
    // public GameObject targetlevel0;
    // public GameObject targetlevel1;
    // public GameObject targetlevel2;
    public int stage;
    public string returnScene;
    public string nextscene;
    private showhide3d showhide3d;
    public string behaviour;
    private bool tempStop;
    private floorceilingmove floorceilingmove;
    private int habitsvalue;
    private int riros;
    private int stopFilm;
    public void Start()
    {
       

    }
    // Update is called once per frame
    void Update()
    {
        if (mousehover)
        {
            counter += Time.deltaTime;
            if (counter >= 3)
            {
                mousehover = false;
                counter = 0;

                habitsvalue = PlayerPrefs.GetInt("habitsdone");
                riros = PlayerPrefs.GetInt("rirosBalance");
                stopFilm = PlayerPrefs.GetInt("stopFilm");
                
                // name of scene which you want to load
                if (((habitsvalue != 1) && (behaviour == "smoking")) || (riros <= 50))
                   {
                    PlayerPrefs.SetInt("stopFilm", stopFilm);
                }
                else    if (VideoUrlLink != "")
                {
                    PlayerPrefs.SetString("VideoUrl", VideoUrlLink);
                    if (behaviour == "smoking")
                    {
                        PlayerPrefs.SetInt("stageSmoking", stage);
                    }
                   else if (behaviour == "alcohol")
                    {
                        PlayerPrefs.SetInt("stageAlcohol", stage);
                    }
                    if (behaviour == "heights")
                    {
                        PlayerPrefs.SetInt("stageHeights", stage);
                    }
                    if (behaviour == "sharks")
                    {
                        PlayerPrefs.SetInt("stageSharks", stage);
                    }
                    PlayerPrefs.SetString("nextscene", nextscene);
                    PlayerPrefs.SetString("returntoscene", returnScene);
                      PlayerPrefs.SetString("behaviour", behaviour);
                }
                showhide3d = FindObjectOfType<showhide3d>();
                showhide3d.ResetScene();
            }
        }
    }

    // mouse Enter event
    public void MouseHoverChangeScene()
    {
        startStopMove(tempStop = true);

        //   Debug.Log("setting scenename");
        //Switchscenename = Scenename;
        mousehover = true;
    }

    // mouse Exit Event
    public void MouseExit()
    {
       // Debug.Log("cancelling scene change");
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

   


