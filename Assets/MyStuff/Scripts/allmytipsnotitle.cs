using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Globalization;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class allmytipsnotitle : MonoBehaviour
{
    
    public TMP_Text ContentBody;
  
    private int dbuserid;
    public int contenttype;
  //  public bool title;
    //remote
    string posturl = "http://masterchange.today/php_scripts/allmytips.php";

    //readonly string posturl = "http://localhost/php_scripts/allmytips.php";
    //private string userInt;

    /// <summary>
    ///  	1 	ShortTip with title 	Title 50 Body 300
	//      2 	No title Up to 200 chars
    //      3 	Large tip with title    Title 75, body 300 - 500
	//      4 	Medium tip without title 	200-350 chars
   //       5 	360 film
//          6 	2d film
//          7 	Image 	0
	     // 8 	Large tip 350 - 420 chars
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("dbuserid"))
        {
            dbuserid = PlayerPrefs.GetInt("dbuserid");
            CallRegisterCoroutine();
        }
        else
        {
            ContentBody.text = "Reserved for personalised content. Choose 'dashboard', then remove your headset, to tell us more about your personal circumstances";
        }    
    
    }


    // Update is called once per frame
    public void CallRegisterCoroutine()
    {
    //     Debug.Log("in the call register coroutine");
            StartCoroutine(GetUserTips());
      
    }
    IEnumerator GetUserTips()
    {
    //    Debug.Log("in the IEnumerator");

        WWWForm form = new WWWForm();
        form.AddField("contenttype", contenttype);
        form.AddField("userid", dbuserid);
        form.AddField("title", 0);
            

        UnityWebRequest www = UnityWebRequest.Post(posturl, form); // The file location for where my .php file is.
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
         //   Debug.Log(www.error);
            ContentBody.text  = www.error;
        }
        else
        {
            string json = www.downloadHandler.text;
      //       Debug.Log("first jspm frpm dpwm;apd" + json);
      
            if (json == "0 results")
                //&& !title)
            {
                ContentBody.text = "We only offer you content relevant to you. To get more tips tell us more about yourself (and earn riros at the same time)";
            }
            else 
            { 
     
                PlayerTipsJSON loadedPlayerData = JsonUtility.FromJson<PlayerTipsJSON>(json);
        //        Debug.Log("check abcn" + loadedPlayerData.data[0].ContentBody + "\n");
                //    Debug.Log(loadedPlayerData.data[0].ContentBody + "\n");
                ContentBody.text = loadedPlayerData.data[0].ContentBody;
            }
        }
    }

    private class UserData
    {
        public string User_id;

    }

    [Serializable]
    public class PlayerData
    {
       // public string fromJSONusername;
        public string ContentTitle;
        public string ContentBody;
      //  public int User_ID;
      //  public int value;
      //  public bool boolean;
    }

    [Serializable]
    public class PlayerTipsJSON
    {
        public List<PlayerData> data;
    }
}
