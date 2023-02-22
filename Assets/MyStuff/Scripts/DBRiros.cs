using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Globalization;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;



//Used in welcome back and JCriros
public class DBRiros : MonoBehaviour
{
    private int DisplaySkipTraining;
    public Text textUsername;
    public Text textJC;
    private bool doesExisthabits;
    private bool doesExistbio;
    private bool doesExistfactors;
    private bool doesExistenviro;
    private bool doesExistfood;
    private bool doesExisthealth;
    private bool doesExistquiz1;
    private bool doesExistquiz2;
    private bool doesExistquiz3;
    private bool doesExistquiz4;
    private bool doesExistUserInfo;
    public Text textRiros;
    private int riros = 0;
    private string scriptuserid;
    private string scriptusername;
    private string scriptfname;
    public GameObject skiptraining;
    private float Cigsperday;
    private float YearsSmoked;
    private float QuitAttempts;
    private bool Prequit;
    private bool Quitting;
    private bool NotStarted;
    private bool NRT;
    private bool TTFCLess;
    private float JC = 0;


    public void Start()
    {
        //check whether to display the skip training checkbox
       // DisplaySkipTraining = PlayerPrefs.GetInt("beeninworld");
        Debug.Log("DisplaySkipTraining" + DisplaySkipTraining);
 
        if (PlayerPrefs.GetInt("HideTraining")==1)
        {
            skiptraining.SetActive(false);
        }
        
        //get user info ***THIS WILL NEED UPDATING TO DISCOUNT RIROS ONCE WE START CHARGING FOR CONTENT
        string json = File.ReadAllText(Application.persistentDataPath + "/userinfo.json");

        string userfileexists = Application.persistentDataPath + "/userinfo.json";
        doesExistUserInfo = File.Exists(userfileexists);

        if (doesExistUserInfo)
        { 
        //json = json.Trim('[', ']');
        Debug.Log("json" + json);
        UserData loadedUserData = JsonUtility.FromJson<UserData>(json);
             scriptuserid = loadedUserData.User_id;
            Debug.Log("scriptuserid" + scriptuserid);
            scriptusername = loadedUserData.Username;
            Debug.Log("scriptusername" + scriptusername);
            scriptfname = loadedUserData.Fname;
            Debug.Log("scriptfname" + scriptfname);
            //JC = loadedUserData.JSONJC;
            Debug.Log("JC" + JC);
            //riros = loadedUserData.JSONRiros;
            Debug.Log("riros" + riros);
            if (scriptfname == "")
            {
                textUsername.text = scriptusername;
            }
            else if (scriptusername != "")
            {
                textUsername.text = scriptfname;
            }
        }
        else
        {
            textUsername.text = "";
        }

        
       
        //calculate the JC based on habit info from JSON file 
        //habit info

        string habits = Application.persistentDataPath + "/habit1.json";
        doesExisthabits = File.Exists(habits);
        if (doesExisthabits)
        {
            string jsonHabits = File.ReadAllText(Application.persistentDataPath + "/habit1.json");

            PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(jsonHabits);
            Cigsperday = loadedPlayerData.JSONcigsPerDay;
            YearsSmoked = loadedPlayerData.JSONyearsSmoked;
            QuitAttempts = loadedPlayerData.JSONpreviousQuits;
            NRT = loadedPlayerData.JSONnrt;
            Prequit = loadedPlayerData.JSONprequit;
            Quitting = loadedPlayerData.JSONquitting;
            NotStarted = loadedPlayerData.JSONnodate;
            TTFCLess = loadedPlayerData.JSONttfcless;

            Debug.Log("JeopardyCoefficent pre" + JC);

            //taking NRT
            if (!NRT)
            {
                JC = JC + 10;
            }
            Debug.Log("JeopardyCoefficent after nrt" + JC);

            //cigs per day - max 10
            if (Cigsperday < 5)
            {
                JC = JC + 1;
            }

            else if (Cigsperday >= 5 && Cigsperday < 10)
            {
                JC = JC + 3;
            }

            else if (Cigsperday >= 10 && Cigsperday < 20)
            {
                JC = JC + 4;
            }

            else if (Cigsperday >= 20 && Cigsperday < 40)
            {
                JC = JC + 6;
            }

            else if (Cigsperday >= 40)
            {
                JC = JC + 10;
            }
            Debug.Log("JeopardyCoefficent Cigsperday" + JC);

            //years smoked - max 10
            if (YearsSmoked < 1)
            {
                JC = JC + 1;
            }

            else if (YearsSmoked >= 1 && YearsSmoked < 3)
            {
                JC = JC + 2;
            }

            else if (YearsSmoked >= 3 && YearsSmoked < 8)
            {
                JC = JC + 4;
            }

            else if (YearsSmoked >= 8 && YearsSmoked < 15)
            {
                JC = JC + 6;
            }

            else if (YearsSmoked >= 15)
            {
                JC = JC + 10;
            }
            Debug.Log("JeopardyCoefficent YearsSmoked" + JC);
            //ttfc - max 5
            if (TTFCLess)
            {
                JC = JC + 5;
            }
            else
            {
                JC = JC + 3;
            }
            Debug.Log("JeopardyCoefficent TTFC" + JC);
            //take away number of quit attempts
            JC = JC - (QuitAttempts / 2);
            Debug.Log("Final JeopardyCoefficent" + JC);
            //Max score 35

            JC = (JC / 35 * 100);

            Debug.Log("JeopardyCoefficent end of function" + JC + JC.GetType());
            //end of JC calculation
            textJC.text = Mathf.Round(JC).ToString();

        }
        
        //Calculate number of riros based on files that exist
        //string habits = Application.persistentDataPath + "/habit1.json";
        string bio = Application.persistentDataPath + "/Bio.json";
        string enviro = Application.persistentDataPath + "/environment.json";
        string food = Application.persistentDataPath + "/food.json";
        string health = Application.persistentDataPath + "/health.json";
        string factors = Application.persistentDataPath + "/factors.json";
        string quiz1 = Application.persistentDataPath + "/quiz1.json";
        string quiz2 = Application.persistentDataPath + "/quiz2.json";
        string quiz3 = Application.persistentDataPath + "/quiz3.json";
        string quiz4 = Application.persistentDataPath + "/quiz4.json";


        doesExisthabits = File.Exists(habits);
        doesExistbio = File.Exists(bio);
        doesExistenviro = File.Exists(enviro);
        doesExistfood = File.Exists(food);
        doesExisthealth = File.Exists(health);
        doesExistfactors = File.Exists(factors);
        doesExistquiz1 = File.Exists(quiz1);
        doesExistquiz2 = File.Exists(quiz2);
        doesExistquiz3 = File.Exists(quiz3);
        doesExistquiz4 = File.Exists(quiz4);
       
            if (doesExistUserInfo)
            {
                riros = riros + 5000;
            }
            if (doesExisthabits)
            {
                riros = riros +  2000;
            }

            if (doesExistbio)
            {
                riros = riros + 500;
            }

            if (doesExistenviro)
            {
                riros = riros + 1200;
            }
            if (doesExistfood)
            {
                riros = riros + 900;
            }
            if (doesExistfactors)
            {
                riros = riros + 1500;
            }
            if (doesExisthealth)
            {
                riros = riros + 1500;
            }
            if (doesExistquiz1)
            {
                riros = riros + 300;
            }
            if (doesExistquiz2)
            {
                riros = riros + 500;
            }
            if (doesExistquiz3)
            {
                riros = riros + 600;
            }
            if (doesExistquiz4)
            {
                riros = riros + 800;
            }
        int feedback = PlayerPrefs.GetInt("feedback");
        riros = riros + (feedback * 500);
        int voted = PlayerPrefs.GetInt("voted");
        riros = riros + (voted * 500);


        textRiros.text = riros.ToString();

        //Write Riros and JC to userinfo
        
        //JeopardyCoefficent = loadedUserData.JSONJC;
        textJC.text = Mathf.Round(JC).ToString();

        //}
        //else
        // {
        //JeopardyCoefficent = 0;
        //textJC.text = JeopardyCoefficent.ToString();


        //WRITE TO JSON

        UserData userData = new UserData();

        userData.User_id = scriptuserid;
        userData.Username = scriptusername;
        userData.Fname = scriptfname;
        userData.JSONJC = JC;
        userData.JSONRiros = riros;

              string newUserInfo = JsonUtility.ToJson(userData);
            File.WriteAllText(Application.persistentDataPath + "/userinfo.json", newUserInfo);
  
    }

    private class UserData
    {
        public string User_id;
        public string Username;
        public string Fname;
        public float JSONJC;
        public int JSONRiros;

    }

    private class PlayerData
    {
        //Health factors
        public bool JSONttfcless;
        // public bool JSONttfcmore;
        public bool JSONnrt;
        public bool JSONprequit;
        public bool JSONquitting;
        public bool JSONnodate;
        public float JSONcigsPerDay;
        public float JSONpreviousQuits;
        public float JSONyearsSmoked;
    }
}
