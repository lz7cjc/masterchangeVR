
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Globalization;
using UnityEngine.UI;
using System;

public class reasons2 : MonoBehaviour
{
    public Slider Cost;
    public Slider Control;
    public Toggle MedAdvice;
    public Text TextCost;
    public Text TextControl;

    private int FormCost;
    private int FormControl;
    private int FormMedAdvice;

    private int CostID = 70;
    private int ControlID = 71;
    private int MedAdviceID = 72;

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
                if (loadedPlayerData.data[i].Habit_ID == CostID)
                {
                    Cost.value = loadedPlayerData.data[i].amount;
                 }
                if (loadedPlayerData.data[i].Habit_ID == ControlID)
                {
                    Control.value = loadedPlayerData.data[i].amount;
                  }
                if (loadedPlayerData.data[i].Habit_ID == MedAdviceID)
                {
                    MedAdvice.isOn = loadedPlayerData.data[i].yesorno;
                }


            }



        }
    }

    public void WhatCost(float value)
    {
        Debug.Log("New cost value" + Cost.value);


    }
    public void WhatControl(float value)
    {
        Debug.Log("New contrl Value " + Control.value);
    }

    public void DocAdvice()
    {

    }



    public void sethabits()
    {
        FormCost = Convert.ToInt32(Cost.value);
        FormControl = Convert.ToInt32(Control.value); ;
        FormMedAdvice = Convert.ToInt32(MedAdvice.isOn); ;

        StartCoroutine(pushhabits());
    }



    IEnumerator pushhabits()
    {
        WWWForm form = new WWWForm();
        UserHabitsPut obj = new UserHabitsPut();


        //label is either binary or value depending on type
        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = CostID,
            amount = FormCost,
            label = "value"
        });
   
        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = ControlID,
            amount = FormControl,
            label = "value"

        });

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = MedAdviceID,
            amount = FormMedAdvice,
            label = "binary"
        });

        string json = JsonUtility.ToJson(obj);


        Debug.Log("this is the json i created" + json);
        form.AddField("user", dbuserid);
        form.AddField("cthearray", json);

    
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

   
