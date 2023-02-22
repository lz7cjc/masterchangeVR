using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Globalization;
using UnityEngine.UI;
using System;

public class triggers : MonoBehaviour
{
    string posturl = "http://masterchange.today/php_scripts/habitvaluesjson.php";
    string gethabits = "http://masterchange.today/php_scripts/gethabits.php";
    //local
    // readonly string posturl = "http://localhost/php_scripts/habitvaluesjson.php";

    // Start is called before the first frame update

    public Toggle Meal;
    public Toggle Driving;
    public Toggle Alcohol;
    public Toggle Stress;
    public Toggle SmellSmoke;
    public Toggle Anxious;
    public Toggle TeaCoffee;
    public Toggle Sad;
    public Toggle Bored;
    public Toggle Phone;
    public Toggle SocialMedia;

   
    private int formMeal;
    private int formDriving;
    private int formAlcohol;
    private int formStress;
    private int formSmellSmoke;
    private int formAnxious;
    private int formTeaCoffee;
    private int formSad;
    private int formBored;
    private int formPhone;
    private int formSocialMedia;

    private int MealID = 83;
    private int DrivingID = 84;
    private int AlcoholID = 85;
    private int StressID = 86;
    private int SmellSmokeID =87;
    private int AnxiousID =88;
    private int TeaCoffeeID = 89;
    private int SadID = 90;
    private int BoredID = 91;
    private int PhoneID = 92;
    private int SocialMediaID = 93;



    private int dbuserid;
    void Start()
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
                if (loadedPlayerData.data[i].Habit_ID == MealID)
                {
                    Meal.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("coworkers: " + loadedPlayerData.data[i].yesorno);
                }
                if (loadedPlayerData.data[i].Habit_ID == DrivingID)
                {
                    Driving.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("parents: " + loadedPlayerData.data[i].yesorno);
                }
                if (loadedPlayerData.data[i].Habit_ID == AlcoholID)
                {
                    Alcohol.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("friends: " + loadedPlayerData.data[i].yesorno);
                }
                if (loadedPlayerData.data[i].Habit_ID == StressID)
                {
                    Stress.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("partner: " + loadedPlayerData.data[i].yesorno);
                }
                if (loadedPlayerData.data[i].Habit_ID == SmellSmokeID)
                {
                    SmellSmoke.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("alone: " + loadedPlayerData.data[i].yesorno);
                }
                if (loadedPlayerData.data[i].Habit_ID == AnxiousID)
                {
                    Anxious.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("withnonsmokers: " + loadedPlayerData.data[i].yesorno);
                }
                if (loadedPlayerData.data[i].Habit_ID == TeaCoffeeID)
                {
                    TeaCoffee.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("withsmokers: " + loadedPlayerData.data[i].yesorno);
                }

                if (loadedPlayerData.data[i].Habit_ID == SadID)
                {
                    Sad.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("withsmokers: " + loadedPlayerData.data[i].yesorno);
                }

                if (loadedPlayerData.data[i].Habit_ID == BoredID)
                {
                    Bored.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("withsmokers: " + loadedPlayerData.data[i].yesorno);
                }

                if (loadedPlayerData.data[i].Habit_ID == PhoneID)
                {
                    Phone.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("withsmokers: " + loadedPlayerData.data[i].yesorno);
                }

                if (loadedPlayerData.data[i].Habit_ID == SocialMediaID)
                {
                    SocialMedia.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("withsmokers: " + loadedPlayerData.data[i].yesorno);
                }

            }



        }
    }



    public void onChangeMeal()
    {
        //post new value to the DB

    }
    public void onChangeDriving()
    {

    }
    public void onChangeAlcohol()
    {

    }
    public void onChangeStress()
    {

    }
    public void onChangeSmellSmoke()
    {


    }
    public void onChangeAnxious()
    {


    }
    public void onChangeTeaCoffee()
    {


    }
    public void onChangeSad()
    {

    }
    public void onChangeSocialMedia()
    {

    }
    public void onChangeBored()
    {


    }
    public void onChangePhone()
    {

    }


    public void sethabits()
    {
        formMeal = Convert.ToInt32(Meal.isOn);
        formDriving = Convert.ToInt32(Driving.isOn); 
        formAlcohol = Convert.ToInt32(Alcohol.isOn); 
        formStress = Convert.ToInt32(Stress.isOn); 
        formSmellSmoke = Convert.ToInt32(SmellSmoke.isOn); 
        formAnxious = Convert.ToInt32(Anxious.isOn); 
        formTeaCoffee = Convert.ToInt32(TeaCoffee.isOn); 
        formSad = Convert.ToInt32(Sad.isOn); 
        formBored = Convert.ToInt32(Bored.isOn); 
        formPhone = Convert.ToInt32(Phone.isOn); 
        formSocialMedia = Convert.ToInt32(SocialMedia.isOn); 
        StartCoroutine(pushhabits());
    }



    IEnumerator pushhabits()
    {
        WWWForm form = new WWWForm();

           UserHabitsPut obj = new UserHabitsPut();

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = MealID,
            amount = formMeal,
            label = "binary"
        });


        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = DrivingID,
            amount = formDriving,
            label = "binary"

        });

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = AlcoholID,
            amount = formAlcohol,
            label = "binary"
        });

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = StressID,
            amount = formStress,
            label = "binary"
        });

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = SmellSmokeID,
            amount = formSmellSmoke,
            label = "binary"
        });

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = AnxiousID,
            amount = formAnxious,
            label = "binary"
        });

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = TeaCoffeeID,
            amount = formTeaCoffee,
            label = "binary"
        });
        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = SadID,
            amount = formSad,
            label = "binary"
        });
        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = BoredID,
            amount = formBored,
            label = "binary"
        });
        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = PhoneID,
            amount = formPhone,
            label = "binary"
        });
        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = SocialMediaID,
            amount = formSocialMedia,
            label = "binary"
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