using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Globalization;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class onerandomtip : MonoBehaviour
{
    public Text ContentBody;
    //public Text ContentBody1;
    //public Text ContentBody2;
    private int dbuserid;
    //remote
    string posturl = "http://masterchange.today/php_scripts/allmytips.php";

    //readonly string posturl = "http://localhost/php_scripts/allmytips.php";
    //private string userInt;



    // Start is called before the first frame update
    void Start()
    {

        dbuserid =  PlayerPrefs.GetInt("dbuserid");
        //Debug.Log("userid = " + dbuserid);
      if (dbuserid.ToString() == "")
        {
             ContentBody.text = "Reserved for personalised content. Choose 'dashboard', then remove your headset, to tell us more about your personal circumstances";
        }
        else
        { 
        CallRegisterCoroutine();
        }    
    
     }


    // Update is called once per frame
    public void CallRegisterCoroutine()
    {
         Debug.Log("in the call register coroutine");
            StartCoroutine(GetUserTips());
      
    }
    IEnumerator GetUserTips()
    {
        Debug.Log("in the IEnumerator");

        WWWForm form = new WWWForm();
       form.AddField("userid", dbuserid);


        UnityWebRequest www = UnityWebRequest.Post(posturl, form); // The file location for where my .php file is.
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
             //errorMessage = www.error;
        }
        else
        {
            string json = www.downloadHandler.text;
            PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
         
            Debug.Log("json for tips: " + json);
            Debug.Log("content body" + loadedPlayerData.ContentBody);


            Debug.Log("content title" + loadedPlayerData.ContentTitle);
        }
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


}
