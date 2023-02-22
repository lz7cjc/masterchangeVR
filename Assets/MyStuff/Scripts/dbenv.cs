using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Globalization;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

//do this when submitting the results from the second habits page
public class dbbenv : MonoBehaviour
{
    //remote
    string posturl = "http://masterchange.today/php_scripts/envinsert.php";
    string gethabits = "http://masterchange.today/php_scripts/gethabits.php";
    //local
    // readonly string posturl = "http://localhost/php_scripts/habit1insert.php";


    //public string errorMessage;
    //private bool doesExisthabits;
    private int dbuserid;
    public Toggle coworkers;
    public Toggle parents;
    public Toggle friends;
    public Toggle partner;
    public Toggle alone;
    public Toggle withnonsmokers;
    public Toggle withsmokers;
    public string Switchscene;
    private int skipvrscreen;

    private int formcoworkers;
    private int formparents;
    private int formfriends;
    private int formpartner;
    private int formalone;
    private int formwithnonsmokers;
    private int  formwithsmokers;

   
      private ChangesceneInc ChangesceneInc;

    //  public globalvariables globaltest;
    private void Start()
    {
        dbuserid = PlayerPrefs.GetInt("dbuserid");
        StartCoroutine(getHabits());
        Debug.Log("it is running");
        
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
            var myData = JsonUtility.FromJson<UserHabits>("{\"data\":" + json + "}");
            // Debug.Log(json);
            foreach (var habit in myData.data)
            {
             
                if (habit.Habit_ID == 35)
                {
                    coworkers.isOn = habit.yesorno;
                    Debug.Log("coworkers: " + habit.yesorno);
                }
                if (habit.Habit_ID == 34)
                {
                    parents.isOn = habit.yesorno;
                    Debug.Log("parents: " + habit.yesorno);
                }
                if (habit.Habit_ID == 33)
                {
                    friends.isOn = habit.yesorno;
                    Debug.Log("friends: " + habit.yesorno);
                }
                if (habit.Habit_ID == 32)
                {
                    partner.isOn = habit.yesorno;
                    Debug.Log("partner: " + habit.yesorno);
                }
                if (habit.Habit_ID == 29)
                {
                    alone.isOn = habit.yesorno;
                    Debug.Log("alone: " + habit.yesorno);
                }
                if (habit.Habit_ID == 30)
                {
                    withnonsmokers.isOn = habit.yesorno;
                    Debug.Log("withnonsmokers: " + habit.yesorno);
                }
                if (habit.Habit_ID == 31)
                {
                    withsmokers.isOn = habit.yesorno;
                    Debug.Log("withsmokers: " + habit.yesorno);
                }
            }


        }
        }


    public void changecoworker()
    {
         
        
    }
    public void changeparents()
    {
        
    }
    public void changefriends()
    {
      
    }
    public void changepartner()
    {

    }
    public void changealone()
    {

    }
    public void changewithnonsmokers()
    {


    }
    public void changewithsmokers()
    {


    }


    public void sethabits()
    {
        formcoworkers = Convert.ToInt32(coworkers.isOn);
        formparents = Convert.ToInt32(parents.isOn); ;
        formfriends = Convert.ToInt32(friends.isOn); ;
        formpartner = Convert.ToInt32(partner.isOn); ;
        formalone = Convert.ToInt32(alone.isOn); ;
        formwithnonsmokers = Convert.ToInt32(withnonsmokers.isOn); ;
        formwithsmokers = Convert.ToInt32(withsmokers.isOn); ;
        StartCoroutine(pushhabits());
    }



    IEnumerator pushhabits()
    {
         WWWForm form = new WWWForm();
         form.AddField("user", dbuserid);
        form.AddField("coworkers", formcoworkers);
        form.AddField("parents", formparents);
        form.AddField("friends", formfriends);
        form.AddField("partner", formpartner);
        form.AddField("alone", formalone);
        form.AddField("withnonsmokers", formwithnonsmokers);
        form.AddField("withsmokers", formwithsmokers);
       

        UnityWebRequest www1 = UnityWebRequest.Post(posturl, form); // The file location for where my .php file is.
        yield return www1.SendWebRequest();
        if (www1.isNetworkError || www1.isHttpError)
        {
            Debug.Log(www1.error);
            // errorMessage = www.error;
        }
        else
        {

            Debug.Log("Form Upload Complete!");

            Debug.Log("this comes back" + www1.downloadHandler.text);


        }


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
            ChangesceneInc = FindObjectOfType<ChangesceneInc>();
            ChangesceneInc.ChangeSceneNow(Switchscene);


        }

    }


    public class UserHabits
    { 
            public List<habitinfo> data;
    }
    [System.Serializable]

    public class habitinfo
    {
        public int Habit_ID;
        public int label;
        public int amount;
        public Text yesorno;
       
    }


   
}
