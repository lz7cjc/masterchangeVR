using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Globalization;
using UnityEngine.UI;
using System;

public class reasonsforquitting : MonoBehaviour
{
    public Slider HealthCurrent;
    public Slider HealthFuture;
    public Slider MeorOthers;
    public Text TextHealthNow;
    public Text TextHealthFuture;
    public Text TextMevOthers;

    private int FormHealthCurrent;
    private int FormHealthFuture;
    private int FormMeorOthers;
    
    private int HealthCurrentID = 73;
    private int HealthFutureID = 74;
    private int MeorOthersID = 75;

    private int dbuserid;

    //remote
    string posturl = "http://masterchange.today/php_scripts/habitvaluesjson.php";
    string gethabits = "http://masterchange.today/php_scripts/gethabits.php";
    //local
    // readonly string posturl = "http://localhost/php_scripts/habitvaluesjson.php";
    public void Start()
    {
        dbuserid = PlayerPrefs.GetInt("dbuserid");
        StartCoroutine(getHabits());

    }

    IEnumerator getHabits()
    {
        Debug.Log("in the habits function");
        WWWForm form = new WWWForm();

        form.AddField("dbuserid", dbuserid);
        UnityWebRequest www1 = UnityWebRequest.Post(gethabits, form); // The file location for where my .php file is.
        yield return www1.SendWebRequest();
        if (www1.isNetworkError || www1.isHttpError)
        {
            Debug.Log(www1.error);
            // errorMessage = www.error;
        }
        else
        {

            Debug.Log("Got the user's habits");

            Debug.Log("this comes back" + www1.downloadHandler.text);
            string json = www1.downloadHandler.text;

            UserHabits loadedPlayerData = JsonUtility.FromJson<UserHabits>(json);
            Debug.Log("record count: " + loadedPlayerData.data.Count);
            for (int i = 0; i < loadedPlayerData.data.Count; i++)
            {
                if (loadedPlayerData.data[i].Habit_ID == HealthCurrentID)
                {
                    HealthCurrent.value = loadedPlayerData.data[i].amount;
                    Debug.Log("coworkers: " + loadedPlayerData.data[i].yesorno);
                }
                if (loadedPlayerData.data[i].Habit_ID == HealthFutureID)
                {
                    HealthFuture.value = loadedPlayerData.data[i].amount;
                    Debug.Log("parents: " + loadedPlayerData.data[i].yesorno);
                }
                if (loadedPlayerData.data[i].Habit_ID == MeorOthersID)
                {
                    MeorOthers.value = loadedPlayerData.data[i].amount;
                    Debug.Log("friends: " + loadedPlayerData.data[i].yesorno);
                }
                

            }



        }
    }

    public void WhatHealthNow(float value)
    {
        Debug.Log("New cost value" + HealthCurrent.value);
   

    }
    public void WhatHealthFuture(float value)
    {
        Debug.Log("New contrl Value " + HealthFuture.value);
    }

    public void ForWho(float value)
    {
        Debug.Log("New contrl Value " + MeorOthers.value);
    }

   
    public void sethabits()
    {
        FormHealthCurrent = Convert.ToInt32(HealthCurrent.value);
        FormHealthFuture = Convert.ToInt32(HealthFuture.value); ;
        FormMeorOthers = Convert.ToInt32(MeorOthers.value); ;
       
        StartCoroutine(pushhabits());
    }



    IEnumerator pushhabits()
    {
        WWWForm form = new WWWForm();
        UserHabitsPut obj = new UserHabitsPut();


        //label is either binary or value depending on type
        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = HealthCurrentID,
            amount = FormHealthCurrent,
            label = "value"
        });
        Debug.Log("check habit id: " + HealthCurrentID);
        Debug.Log("amount: " + FormHealthCurrent);
        Debug.Log("label: " + "binary");

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = HealthFutureID,
            amount = FormHealthFuture,
            label = "value"

        });

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = MeorOthersID,
            amount = FormMeorOthers,
            label = "value"
        });

        string json = JsonUtility.ToJson(obj);


        Debug.Log("this is the json i created" + json);
        form.AddField("user", dbuserid);
        form.AddField("cthearray", json);

        //UnityWebRequest www1 = UnityWebRequest.Post(posturl, form); // The file location for where my .php file is.
        //yield return www1.SendWebRequest();
        //if (www1.isNetworkError || www1.isHttpError)
        //{
        //    Debug.Log(www1.error);
        //    // errorMessage = www.error;
        //}
        //else
        //{

        //    Debug.Log("Form Upload Complete!");

        //    Debug.Log("this comes back" + www1.downloadHandler.text);


        //}


        UnityWebRequest www = UnityWebRequest.Post(posturl, form); // The file location for where my .php file is.
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            // errorMessage = www.error;
        }
        else
        {

            Debug.Log("Form Upload Complete!");

            Debug.Log("this comes back" + www.downloadHandler.text);
            //ChangesceneInc = FindObjectOfType<ChangesceneInc>();
            //ChangesceneInc.ChangeSceneNow(Switchscene);


        }

    }

    [Serializable]
    public class UserHabits
    {
        public List<habitinfo> data;
    }
    [System.Serializable]

    public class habitinfo
    {
        public int Habit_ID;
        //  public string label;
          public int amount;
        public bool yesorno;

    }

    [Serializable]
    public class habitinfoput
    {
        public int Habit_ID;
        public string label;
        public int amount;


    }

    [Serializable]
    public class UserHabitsPut
    {
        public List<habitinfoput> data1 = new List<habitinfoput>();
    }


}