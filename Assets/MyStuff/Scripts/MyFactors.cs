using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;
using System;

public class MyFactors : MonoBehaviour
{
    public Toggle drugsNever;
    public Toggle drugNoLonger;
    public Toggle drugOccasional;
    public Toggle drugHeavy;
    public Toggle noStressRelief;
    public Toggle meditation;
    public Toggle mindfulness;
    public Toggle yoga;
    public Slider exercise;

    private int dbuserid;

    private int formdrugsNever;
    private int formdrugNoLonger;
    private int formdrugOccasional;
    private int formdrugHeavy;
    private int formnoStressRelief;
    private int formmeditation;
    private int formmindfulness;
    private int formyoga;
    private int formexercise;

    private int drugsNeverID = 37;
    private int drugNoLongerID = 38;
    private int drugOccasionalID = 39;
    private int drugHeavyID = 40;
    private int noStressReliefID = 41;
    private int meditationID = 43;
    private int mindfulnessID = 42;
    private int yogaID = 44;
    private int exerciseID = 45;

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
                if (loadedPlayerData.data[i].Habit_ID == drugsNeverID)
                {
                    Debug.Log("drugsNeverID" + loadedPlayerData.data[i].yesorno);

                    drugsNever.isOn = loadedPlayerData.data[i].yesorno;
                }
                if (loadedPlayerData.data[i].Habit_ID == drugNoLongerID)
                {
                    Debug.Log("drugNoLongerID" + loadedPlayerData.data[i].yesorno);

                    drugNoLonger.isOn = loadedPlayerData.data[i].yesorno;
                 }
                if (loadedPlayerData.data[i].Habit_ID == drugOccasionalID)
                {
                    drugOccasional.isOn = loadedPlayerData.data[i].yesorno;
                 }
                if (loadedPlayerData.data[i].Habit_ID == drugHeavyID)
                {
                    drugHeavy.isOn = loadedPlayerData.data[i].yesorno;
                 }
                if (loadedPlayerData.data[i].Habit_ID == noStressReliefID)
                {
                    noStressRelief.isOn = loadedPlayerData.data[i].yesorno;
                  }
                if (loadedPlayerData.data[i].Habit_ID == meditationID)
                {
                    meditation.isOn = loadedPlayerData.data[i].yesorno;
                }
                if (loadedPlayerData.data[i].Habit_ID == mindfulnessID)
                {
                    mindfulness.isOn = loadedPlayerData.data[i].yesorno;
                  }
                if (loadedPlayerData.data[i].Habit_ID == yogaID)
                {
                    yoga.isOn = loadedPlayerData.data[i].yesorno;
             }
                if (loadedPlayerData.data[i].Habit_ID == exerciseID)
                {
                    exercise.value = loadedPlayerData.data[i].amount;

                }

            }
        }

    }

    public void OnChangeNeverDrugs()
    {
    }
    public void OnChangeNolongerDrugs()
    {
    }
    public void OnChangeOccDrugs()
    {
    }
    public void OnChangeRegsDrugs()
    {
    }

    public void OnChangeNoStressRelief()
        {
    
        }

        public void OnChangeMeditation()
        {
     
        }
        public void OnChangeMindfulness()
        {
  
        }
        public void OnChangeYoga()
        {
     
        }


        public void OnChangeExercise()
        {
            Debug.Log("exercise: " + exercise.value);

        }
       

    


public void sethabits()
{
    formdrugsNever = Convert.ToInt32(drugsNever.isOn);
    formdrugNoLonger = Convert.ToInt32(drugNoLonger.isOn); 
        formdrugOccasional = Convert.ToInt32(drugOccasional.isOn); 
        formdrugHeavy = Convert.ToInt32(drugHeavy.isOn); 
        formnoStressRelief = Convert.ToInt32(noStressRelief.isOn); 
        formmeditation = Convert.ToInt32(meditation.isOn); 
        formmindfulness = Convert.ToInt32(mindfulness.isOn); 
        formyoga = Convert.ToInt32(yoga.isOn); 
        formexercise = Convert.ToInt32(exercise.value); 
        StartCoroutine(pushhabits());
}



IEnumerator pushhabits()
{
    WWWForm form = new WWWForm();

    UserHabitsPut obj = new UserHabitsPut();

    obj.data1.Add(new habitinfoput()
    {
        Habit_ID = drugsNeverID,
        amount = formdrugsNever,
        label = "binary"
    });
   
    obj.data1.Add(new habitinfoput()
    {
        Habit_ID = drugNoLongerID,
        amount = formdrugNoLonger,
        label = "binary"

    });

    obj.data1.Add(new habitinfoput()
    {
        Habit_ID = drugOccasionalID,
        amount = formdrugOccasional,
        label = "binary"
    });

    obj.data1.Add(new habitinfoput()
    {
        Habit_ID = drugHeavyID,
        amount = formdrugHeavy,
        label = "binary"
    });

    obj.data1.Add(new habitinfoput()
    {
        Habit_ID = noStressReliefID,
        amount = formnoStressRelief,
        label = "binary"
    });

    obj.data1.Add(new habitinfoput()
    {
        Habit_ID = meditationID,
        amount = formmeditation,
        label = "binary"
    });

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = mindfulnessID,
            amount = formmindfulness,
            label = "binary"
        });

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = yogaID,
            amount = formyoga,
            label = "binary"
        });
        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = exerciseID,
            amount = formexercise,
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