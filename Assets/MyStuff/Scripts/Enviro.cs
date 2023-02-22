using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class Enviro : MonoBehaviour
{
    public string Switchscene;

    public Toggle alone;
    public Toggle withnonsmokers;
    public Toggle withsmokers;
    public Toggle partner;
    public Toggle friends;
    public Toggle parents;
    public Toggle coworkers;
    public Text errormessage;

    private int dbuserid;

    private int formcoworkers;
    private int formparents;
    private int formfriends;
    private int formpartner;
    private int formalone;
    private int formwithnonsmokers;
    private int formwithsmokers;

    private int coworkersID = 35;
    private int parentsID = 34;
    private int friendsID = 33;
    private int partnerID = 32;
    private int aloneID = 29;
    private int withnonsmokersID = 30;
    private int withsmokerIDs = 31;

    private justSetRiros justSetRiros;

    //private ChangesceneInc ChangesceneInc;

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
                     string json = www1.downloadHandler.text;

            UserHabits loadedPlayerData = JsonUtility.FromJson<UserHabits>(json);
            Debug.Log("record count: " + loadedPlayerData.data.Count);
            for (int i = 0; i < loadedPlayerData.data.Count; i++)
            {
                 if (loadedPlayerData.data[i].Habit_ID == coworkersID)
                {
                    coworkers.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("coworkers: " + loadedPlayerData.data[i].yesorno);
                }
                if (loadedPlayerData.data[i].Habit_ID == parentsID)
                {
                    parents.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("parents: " + loadedPlayerData.data[i].yesorno);
                }
                if (loadedPlayerData.data[i].Habit_ID == friendsID)
                {
                    friends.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("friends: " + loadedPlayerData.data[i].yesorno);
                }
                if (loadedPlayerData.data[i].Habit_ID == partnerID)
                {
                    partner.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("partner: " + loadedPlayerData.data[i].yesorno);
                }
                if (loadedPlayerData.data[i].Habit_ID == aloneID)
                {
                    alone.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("alone: " + loadedPlayerData.data[i].yesorno);
                }
                if (loadedPlayerData.data[i].Habit_ID == withnonsmokersID)
                {
                    withnonsmokers.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("withnonsmokers: " + loadedPlayerData.data[i].yesorno);
                }
                if (loadedPlayerData.data[i].Habit_ID == withsmokerIDs)
                {
                    withsmokers.isOn = loadedPlayerData.data[i].yesorno;
                    Debug.Log("withsmokers: " + loadedPlayerData.data[i].yesorno);
                }

            }

          

            }
        }

     

    public void OnChangeLiving()
    {
     }



    public void OnChangePartner()
    {

    }

    public void OnChangeFriends()
    {
 
    }
    public void OnChangeParentChild()
    {

    }
    public void OnChangeCoWorker()
    {
   
    }

  public void sethabits(string nextScene)
    {
        formcoworkers = Convert.ToInt32(coworkers.isOn);
        formparents = Convert.ToInt32(parents.isOn); ;
        formfriends = Convert.ToInt32(friends.isOn); ;
        formpartner = Convert.ToInt32(partner.isOn); ;
        formalone = Convert.ToInt32(alone.isOn); ;
        formwithnonsmokers = Convert.ToInt32(withnonsmokers.isOn); ;
        formwithsmokers = Convert.ToInt32(withsmokers.isOn); ;
        globalvariables.Instance.nextScene = nextScene;
        Switchscene = globalvariables.Instance.nextScene;

        StartCoroutine(pushhabits());
    }



    IEnumerator pushhabits()
    {
        WWWForm form = new WWWForm();

        UserHabitsPut obj = new UserHabitsPut();

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = coworkersID,
            amount = formcoworkers,
            label = "binary"
        });
        Debug.Log("check habit id: " + coworkersID);
        Debug.Log("amount: " + formcoworkers);
        Debug.Log("label: " + "binary");

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = parentsID,
            amount = formparents,
            label = "binary"

        });

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = friendsID,
            amount = formfriends,
            label = "binary"
        });

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = partnerID,
            amount = formpartner,
            label = "binary"
        });

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = aloneID,
            amount = formalone,
            label = "binary"
        });

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = withnonsmokersID,
            amount = formwithnonsmokers,
            label = "binary"
        });

        obj.data1.Add(new habitinfoput()
        {
            Habit_ID = withsmokerIDs,
            amount = formwithsmokers,
            label = "binary"
        });
        string json = JsonUtility.ToJson(obj);


        form.AddField("user", dbuserid);
        form.AddField("cthearray", json);



        UnityWebRequest www = UnityWebRequest.Post(posturl, form); // The file location for where my .php file is.
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
           // errormessage.text = "Oops, sorry but that didn't work. Can you email us at bugs@masterchange.today; tell us what you were trying to do and the error message that follows and if we can replicate you will receive 1000 riros: <b>" + www.error + "</b>";
        }
        else
        {
            string dowepay = www.downloadHandler.text;
            newInfo newInfo = JsonUtility.FromJson<newInfo>(dowepay);
            string dopay = newInfo.reward;
            Debug.LogWarning("dopay is: " + dopay);
            if (dopay == "1")
            {
                timeToPay();
            }
            else
            {

                SceneManager.LoadScene(Switchscene);
            }

        }
   } 
        public void timeToPay()
        {
            Debug.LogWarning("time tp pay function");
            justSetRiros = FindObjectOfType<justSetRiros>();
            justSetRiros.toPayOut();

        }
    


    public class newInfo
    {
        public string reward;
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
      //  public int amount;
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


