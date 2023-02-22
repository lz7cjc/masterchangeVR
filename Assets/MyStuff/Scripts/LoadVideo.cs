using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadVideo : MonoBehaviour
{
    public bool mousehover = false;
    public float counter = 0;
    public string Switchscenename;
    private object Scenename;
    public string VideoUrlLink;
    private int riroAmount;
    public Text noRiros;
    public GameObject registerCanvas;
    public Text registertext;

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
                if (riroAmount > 50)
                {
                    // name of scene which you want to load

                    if (VideoUrlLink != "")
                    {
                        PlayerPrefs.SetString("VideoUrl", VideoUrlLink);
                        print("---->>>" + PlayerPrefs.GetString("VideoUrl"));
                        registerCanvas.SetActive(false);
                        Debug.Log("should be switching" + Switchscenename);
                        SceneManager.LoadScene(Switchscenename);
                    }
                }

                else if (PlayerPrefs.HasKey("dbuserid"))

                {
                    noRiros.text = "R$:" + riroAmount + "You have run out of R$. You can earn more by answering some questions or else you can buy some (you will need to take off your headset)";
                     registertext.text = "Earn Riros";
                     registerCanvas.SetActive(true);
                  Debug.Log("already registered");
                   

                }
                else
                {
                    Debug.Log("not registered!");
                    noRiros.text = "R$:" + riroAmount + "You have insufficient funds for this experience.  Register now to earn more (you will need to take off your headset)";
                    registertext.text = "Register";
                    registerCanvas.SetActive(true);
                    


                }

            }
        }
    }

    // mouse Enter event
    public void MouseHoverChangeScene(string Scenename)
    {
        riroAmount = PlayerPrefs.GetInt("rirosP"); 
        Debug.Log("setting scenename");
        Switchscenename = Scenename;
        mousehover = true;
    }

    // mouse Exit Event
    public void MouseExit()
    {
       // Debug.Log("cancelling scene change");
        mousehover = false;
        counter = 0;
    }
           
}

   


