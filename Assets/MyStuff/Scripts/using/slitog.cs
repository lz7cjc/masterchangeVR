using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

//do this when submitting the results from the second habits page
public class slitog : MonoBehaviour
{

    //remote
    string inserthabits = "http://masterchange.today/php_scripts/habitvaluesjson.php";
    string gethabits = "http://masterchange.today/php_scripts/gethabits.php";
    //local
    // readonly string posturl = "http://localhost/php_scripts/habit1insert.php";
    private int dbuserid;
    private string Switchscene;
    private int habitID_U;
    private int habitValue_U;

    public Text errormessage;

    private justSetGetRiros justSetGetRiros;

    private float BMI;
    private IEnumerable<object> sliders;
    private string json;

    //  public globalvariables globaltest;
    private void Start()
    {
        dbuserid = PlayerPrefs.GetInt("dbuserid");
        StartCoroutine(getHabits());

    }

    IEnumerator getHabits()
    {
        WWWForm forma = new WWWForm();

        forma.AddField("dbuserid", dbuserid);
        UnityWebRequest wwwa = UnityWebRequest.Post(gethabits, forma); // The file location for where my .php file is.
        yield return wwwa.SendWebRequest();
        if (wwwa.isNetworkError || wwwa.isHttpError)
        {

        }
        else
        {

            string json = wwwa.downloadHandler.text;
            Debug.Log("initial user habits from JSON: " + json);
            UserHabits loadedPlayerData = JsonUtility.FromJson<UserHabits>(json);
            var toggles = GameObject.FindObjectsOfType<Toggle>();
            var sliders = GameObject.FindObjectsOfType<Slider>();
            var texter = GameObject.FindObjectsOfType<Text>();
          //  Debug.Log("111. record count: " + loadedPlayerData.data.Count);

            //sliders
            foreach (var sliderIs in sliders)
            {
                var slidervalue = sliderIs.value;
                  var nameofslider = sliderIs.name;

             //  Debug.Log("3333. name of slider:" + nameofslider + "value of slider: " + slidervalue);
                int numbernameofslider = Convert.ToInt32(nameofslider);

                for (int i = 0; i < loadedPlayerData.data.Count; i++)
                {
                //    Debug.Log("4444. should be each ID of habits: " + loadedPlayerData.data[i].Habit_ID);
                    if (loadedPlayerData.data[i].Habit_ID == numbernameofslider)
                    {
              //          Debug.Log("5555 value of slider: " + sliderIs.value);
                        sliderIs.value = loadedPlayerData.data[i].amount;
                    }
                }
            }


            //toggles
            foreach (var toggleIs in toggles)
            {
                //these are the inital values on the form
                // var togglevalue = toggleIs.isOn;
                var nameoftoggle = toggleIs.name;

                int numbernameoftoggle = Convert.ToInt32(nameoftoggle);

                for (int y = 0; y < loadedPlayerData.data.Count; y++)
                {
                    if (loadedPlayerData.data[y].Habit_ID == numbernameoftoggle)
                    {
                      Debug.Log("787878 loadedPlayerData.data[y].yesorno " + loadedPlayerData.data[y].yesorno);
                        if (loadedPlayerData.data[y].yesorno == 1)
                        {
                            toggleIs.isOn = true;
                        }
                    }
                }

            }

          

            
        }
    }


    public void changeValue()
    {
       
    }

    // void BMIcalc()
    // {

    // //    BMI = (Weight.value / Mathf.Pow(Height.value / 100, 2));
    // //    TextBMI.text = BMI.ToString();
    //}

    public void sethabits(string nextScene)
    {
            globalvariables.Instance.nextScene = nextScene;
        Switchscene = globalvariables.Instance.nextScene;

        var toggles2 = GameObject.FindObjectsOfType<Toggle>();
        var sliders2 = GameObject.FindObjectsOfType<Slider>();

        //get the values of each slider
        //get the label for each slider
        //set the obj to loop until count is finished
        //set the the global variable for next scene
         UserHabitsPut obj = new UserHabitsPut();
           foreach (var sliderIs2 in sliders2)
        {
            var habitValue = sliderIs2.value;
            habitValue_U = Convert.ToInt32(habitValue);
            var habitID = sliderIs2.name;
            habitID_U = Convert.ToInt32(habitID);
            //Debug.Log("aaaaa. is it on habitValue_U" + habitValue_U);
            //Debug.Log("bbbb. name of slider habitID_U:" + habitID_U);

            //add to JSON
            obj.data1.Add(new habitinfoput()
            {
                Habit_ID = habitID_U,
                amount = habitValue_U,
                label = "slider"
            });
           
        }

         foreach (var toggleIs2 in toggles2)
        {
            var habitValue = toggleIs2.isOn;
          int  habitToggle_U = Convert.ToInt32(habitValue);
            var habitID = toggleIs2.name;
            habitID_U = Convert.ToInt32(habitID);
           // Debug.Log("aaaaa. is it on habitValue_U" + habitValue_U);
            Debug.Log("bbbb. name of toggle:" + habitID + "value of toggle" + habitToggle_U);

            //add to JSON
            obj.data1.Add(new habitinfoput()
            {
                Habit_ID = habitID_U,
                amount = habitToggle_U,
                label = "toggle"
            });

        }
        json = JsonUtility.ToJson(obj);
        Debug.Log("json is: " + json);
        StartCoroutine(pushhabits());
    }

    IEnumerator pushhabits()
    {
      //   Debug.Log("thectarrya: " + json);
   //    Debug.Log("instide posting");
        WWWForm form = new WWWForm();
         form.AddField("user", dbuserid);
        form.AddField("cthearray", json);
        UnityWebRequest www = UnityWebRequest.Post(inserthabits, form); // The file location for where my .php file is.
   
          yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
             errormessage.text = "Oops, sorry but that didn't work. Please can you email us at bugs@masterchange.today; tell us what you were trying to do and the error message that follows and if we can replicate you will receive 1000 riros: <b>" + www.error + "</b>";
        }
        else
        {
            string dowepay = www.downloadHandler.text;
            Debug.Log("do we pay" + dowepay);
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
       // Debug.LogWarning("time tp pay function" + Switchscene);
        justSetGetRiros = FindObjectOfType<justSetGetRiros>();
        justSetGetRiros.toPayOut();

    }


    public class newInfo
    {
        public string reward;
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
        public int yesorno;
       
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

