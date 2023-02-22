using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Networking;
using System.IO;
using System.Globalization;

using System;
using UnityEngine.SceneManagement;

public class filmvotes : MonoBehaviour
{

    //remote
   string posturllive = "http://masterchange.today/php_scripts/filmvote.php";
    //local
    readonly string posturldev = "http://localhost/php_scripts/filmvote.php";
    readonly private Boolean live = true;

    //public Button Yes;
    //public Button No;
    //public Button Skipped;
    //public Button Register;
    public Text errorMessage;
    private string whichresolution;
    public bool mousehover = false;
    public float counter = 0;
    //public string buttonname;
    private bool tip1000;
    private bool  tip750;
    private bool  tip500;
    private bool  tip250;
    private bool  tip100;
    private bool voteSkip;
    private bool goRegister;
   // public string filmid;
    private int userid;
    private bool userexists;
    private string videoUrl;
    private string Switchscenename;
    private int rirosPay;
    private int rirosPre;
    private int rirosPost;
    public Text printURL;




    // Start is called before the first frame update
    void Start()
    {
 
        videoUrl = PlayerPrefs.GetString("VideoUrl");
        printURL.text = videoUrl;
        if (PlayerPrefs.HasKey("dbuserid"))
            userid = PlayerPrefs.GetInt("dbuserid");
        Debug.Log("first userid from player prefs" + userid);
            userexists = true;
        
        if (PlayerPrefs.HasKey("returnToScene"))
        {
            Switchscenename = PlayerPrefs.GetString("returnToScene");
        }
        else
        {
            Switchscenename = "otherlandscape";
        }

        rirosPre = PlayerPrefs.GetInt("rirosP");
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

               
                if (goRegister)
                {
                    SceneManager.LoadScene("Register");
                }
                else
                {
                    StartCoroutine(tips());
                }
            }
        }
    }


    IEnumerator tips()
    {

        WWWForm form = new WWWForm();
        form.AddField("filmid", videoUrl);

        if (tip1000)
        {
            form.AddField("voteis", "1000");
        }

        else if (tip750)
        {
            form.AddField("voteis", "750");
        }
        else if (tip500)
        {
            form.AddField("voteis", "500");
        }
        else if (tip250)
        {
            form.AddField("voteis", "250");
        }
        else if (tip100)
        {
            form.AddField("voteis", "100");
        }
        else if (voteSkip)
        {
            form.AddField("voteis", "error");
        }
        
         if (userexists)
            {
            form.AddField("userid", userid);
            form.AddField("newRiros", (rirosPre - rirosPay));
        }
        if (live)
        {
            Debug.Log("we are live");
            form.AddField("live", 1);
            UnityWebRequest www = UnityWebRequest.Post(posturllive, form); // The file location for where my .php file is.
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                errorMessage.text = "We hit a problem: (" + www.error + "). Please skip this screen until we have fixed it";

            }
            else
            {

                // Debug.Log(www.downloadHandler.text);
                 Debug.Log("userID" + userid);
                Debug.Log("Form Upload Complete!");
                rirosPost = rirosPre - rirosPay;
                PlayerPrefs.SetInt("rirosP", rirosPost);
                SceneManager.LoadScene(Switchscenename);
            }
        }
        else
        {
            Debug.Log("we are devving");
            form.AddField("live", 0);
            UnityWebRequest www = UnityWebRequest.Post(posturldev, form); // The file location for where my .php file is.
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                errorMessage.text = "We hit a problem: (" + www.error + "). Please skip this screen until we have fixed it";

            }
            else
            {

                // Debug.Log(www.downloadHandler.text);
                // Debug.Log("userID" + userid);
                Debug.Log("Form Upload Complete!");
                rirosPost = rirosPre - rirosPay;
                PlayerPrefs.SetInt("rirosP", rirosPost);
                SceneManager.LoadScene(Switchscenename);
            }
        }
        
        
    }






    // mouse Enter event
    public void MouseHoverChangeSceneError()
    {
        // Debug.Log("setting");
        // Markername = ObjectName;
        mousehover = true;
        tip1000 = false;
        tip750 = false;
        tip500 = false;
        tip250 = false;
        tip100 = false;
        voteSkip = true;
        goRegister = false;
        //rirosPay = 1000;
    }
    public void MouseHoverChangeScene1000()
    {
       // Debug.Log("setting");
        // Markername = ObjectName;
        mousehover = true;
        tip1000 = true;
        tip750 = false;
        tip500 = false;
        tip250 = false;
        tip100 = false;
        voteSkip = false;
        goRegister = false;
        rirosPay = 1000;
    }
    public void MouseHoverChangeScene750()
    {
        // Debug.Log("setting");
        // Markername = ObjectName;
        mousehover = true;
        tip1000 = false;
        tip750 = true;
        tip500 = false;
        tip250 = false;
        tip100 = false;
        voteSkip = false;
        goRegister = false;
        rirosPay = 750;
    }
    public void MouseHoverChangeScene500()
    {
        // Debug.Log("setting");
        // Markername = ObjectName;
        mousehover = true;
        tip1000 = false;
        tip750 = false;
        tip500 = true;
        tip250 = false;
        tip100 = false;
        voteSkip = false;
        goRegister = false;
        rirosPay = 500;
    }
    public void MouseHoverChangeScene250()
    {
        // Debug.Log("setting");
        // Markername = ObjectName;
        mousehover = true;
        tip1000 = false;
        tip750 = false;
        tip500 = false;
        tip250 = true;
        tip100 = false;
        voteSkip = false;
        goRegister = false;
        rirosPay = 250;
    }

    public void MouseHoverChangeScene100()
    {
        // Debug.Log("setting 1000");
        // Markername = ObjectName;
        mousehover = true;
        tip1000 = false;
        tip750 = false;
        tip500 = false;
        tip250 = false;
        tip100 = true;
        voteSkip = false;
        goRegister = false;
        rirosPay = 100;
    }

    public void MouseHoverChangeSceneSkip()
    {
        // Debug.Log("setting");
        // Markername = ObjectName;
        mousehover = true;
        tip1000 = false;
        tip750 = false;
        tip500 = false;
        tip250 = false;
        tip100 = false;
        voteSkip = true;
        goRegister = false;
        
    }

    public void MouseHoverChangeSceneRegister()
    {
        // Debug.Log("setting");
        // Markername = ObjectName;
        mousehover = true;
        tip1000 = false;
        tip750 = false;
        tip500 = false;
        tip250 = false;
        tip100 = false;
        voteSkip = false;
        goRegister = true;
        
    }
    
// mouse Exit Event
public void MouseExit()
    {
     //   Debug.Log("cancelling");
        // Markername = "";
        mousehover = false;
        counter = 0;
    }
}
