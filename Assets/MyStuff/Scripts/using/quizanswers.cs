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

public class quizanswers : MonoBehaviour
{
    public TMP_Text answer1;
    public TMP_Text answer2;
    public TMP_Text answer3;
    public TMP_Text answer4;
    public TMP_Text correctAnswer;
    public TMP_Text explanation;

    //public Text ContentBody1;
    //public Text ContentBody2;
    //  private int dbuserid;
    //public int contenttype;
    //public bool title;
    //remote
    //  string posturl = "http://masterchange.today/php_scripts/quizanswers.php";

    readonly string posturl = "http://localhost/php_scripts/quizanswers.php";
    //private string userInt;

    

    // Start is called before the first frame update
    void Start()
    {
        //if (PlayerPrefs.HasKey("dbuserid"))
        //{
        //   // dbuserid = PlayerPrefs.GetInt("dbuserid");
            CallRegisterCoroutine();
        //}
        //else
        //{
        //    question.text = "Only available to account holders. Please register/login to get involved";
        //}    
    
    }


    // Update is called once per frame
    public void CallRegisterCoroutine()
    {
         Debug.Log("in the call register coroutine");
            StartCoroutine(GetAnswers());
      
    }
    IEnumerator GetAnswers()
    {
        Debug.Log("in the IEnumerator");

        WWWForm form = new WWWForm();
        form.AddField("questionId", PlayerPrefs.GetInt("questionID"));
        //form.AddField("userid", dbuserid);



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
            Debug.Log("answers returned" + json);



            AllAnswersJSON loadAnswers = JsonUtility.FromJson<AllAnswersJSON>(json);

            Debug.Log("loadAnswers" + loadAnswers.data[0].answer + "\n");
            Debug.Log("loadAnswers" + loadAnswers.data[1].answer + "\n");
            Debug.Log("loadAnswers" + loadAnswers.data[2].answer + "\n");
            Debug.Log("loadAnswers" + loadAnswers.data[3].answer + "\n");
            //Debug.Log("prize" + loadAnswers.data[0].prize.ToString());
            //Debug.Log("Behaviour_Description" + loadAnswers.data[0].Behaviour_Description); 

            answer1.text = loadAnswers.data[0].answer;
            answer2.text = loadAnswers.data[1].answer;
            answer3.text = loadAnswers.data[2].answer;
            answer4.text = loadAnswers.data[3].answer;

            

            for (int i = 0; i < loadAnswers.data.Count; i++)
            {
                 if (loadAnswers.data[i].correct == 1)
                {
                    PlayerPrefs.SetInt("correctAnswer", i);
                    correctAnswer.text = loadAnswers.data[i].answer;
                    explanation.text = loadAnswers.data[i].explanation;
                }
            }
        }

    }
    

    //private class UserData
    //{
    //    public string User_id;

    //}

    [Serializable]
    public class EachAnswer
    {
        // public string fromJSONusername;
        public string answer;
        public int correct;
        public string explanation;
        //  public int User_ID;
        //  public int value;
        //  public bool boolean;
    }

    [Serializable]
    public class AllAnswersJSON
    {
        public List<EachAnswer> data;
    }
}

