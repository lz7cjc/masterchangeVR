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

public class allquizquestions : MonoBehaviour
{
    public TMP_Text question;
    public TMP_Text behaviour;
    public TMP_Text behaviourAnswers;
    public TMP_Text behaviourFinish;
    public TMP_Text entryCost;
    public TMP_Text prize;
    public TMP_Text reviewQuestion;
    public TMP_Text repeatQuestion;
    public TMP_Text finalCost;
    public TMP_Text finalPrize;

  //  public GameObject goBtn;
    public GameObject newQuBtn;
   // public GameObject dashboardBtn;
    public GameObject entryFeeToHide;
    public GameObject prizeToHide;
    public GameObject questionSection;
    public GameObject NoQuestionsSection;
    //public Text ContentBody1;
    //public Text ContentBody2;
    //  private int dbuserid;
    //public int contenttype;
    //public bool title;
    //remote
      string posturl = "http://masterchange.today/php_scripts/quizquestions.php";

   // readonly string posturl = "http://localhost/php_scripts/quizquestions.php";
    //private string userInt;

    

    // Start is called before the first frame update
    void Start()
    {


        if (PlayerPrefs.HasKey("dbuserid"))
        {
           // dbuserid = PlayerPrefs.GetInt("dbuserid");
            CallRegisterCoroutine();
        }
        else
        {
            question.text = "Only available to account holders. Please register/login to get involved";
        }    
    
    }


    // Update is called once per frame
    public void CallRegisterCoroutine()
    {
     //    Debug.Log("in the call register coroutine");
            StartCoroutine(GetQuestions());
      
    }
    IEnumerator GetQuestions()
    {
       // Debug.Log("in the IEnumerator");

        WWWForm form = new WWWForm();
     //   form.AddField("contenttype", contenttype);
        //form.AddField("userid", dbuserid);
        
    

        UnityWebRequest www = UnityWebRequest.Post(posturl, form); // The file location for where my .php file is.
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
       //     Debug.Log(www.error);
            //errorMessage = www.error;
        }
        else
        {
            string json = www.downloadHandler.text;
          //  Debug.Log("questions returned" + json);



            AllQuestionsJSON loadQuestions = JsonUtility.FromJson<AllQuestionsJSON>(json);
            int n = loadQuestions.data.Count;
          //  Debug.Log("the rcord count ;;; " + n);
            if (n == 0)
            {
            //    Debug.Log("answered all the question ;;;;");
                questionSection.SetActive(false);
                NoQuestionsSection.SetActive(true);

            }
            else
            {


                System.Random random = new System.Random();
                int i = random.Next(n);
              //  Debug.Log("questions" + loadQuestions.data[i].question + "\n");
           //     Debug.Log("quiz_id ids" + loadQuestions.data[i].quiz_id + "\n");
            //    Debug.Log("prize" + loadQuestions.data[i].prize.ToString());
            //    Debug.Log("Behaviour_Description" + loadQuestions.data[i].Behaviour_Type);


            //    Debug.Log("random number: " + i);
                question.text = loadQuestions.data[i].question;
                reviewQuestion.text = loadQuestions.data[i].question;
                repeatQuestion.text = loadQuestions.data[i].question;
                behaviour.text = loadQuestions.data[i].Behaviour_Type;
                behaviourAnswers.text = loadQuestions.data[i].Behaviour_Type;
                behaviourFinish.text = loadQuestions.data[i].Behaviour_Type;
                PlayerPrefs.SetInt("quizPrize", loadQuestions.data[i].prize);

                finalCost.text = "You lost R$" + loadQuestions.data[i].cost.ToString() + "- learn more by exploring MasterChange";
                finalPrize.text = "Congratulations - you won R$ " + loadQuestions.data[i].prize.ToString() + "- knowledge is power; explore MasterChange for even more";
                entryCost.text = loadQuestions.data[i].cost.ToString();
                prize.text = loadQuestions.data[i].prize.ToString();
                PlayerPrefs.SetInt("questionID", loadQuestions.data[i].quiz_id);
                PlayerPrefs.SetInt("quizPrice", loadQuestions.data[i].cost);
            }
        }

    }
    

    //private class UserData
    //{
    //    public string User_id;

    //}

    [Serializable]
    public class EachQuestion
    {
        // public string fromJSONusername;
        public int quiz_id;
        public string question;
        public string Behaviour_Type;
        public int cost;
        public int prize;

      //  public int User_ID;
      //  public int value;
      //  public bool boolean;
    }

    [Serializable]
    public class AllQuestionsJSON
    {
        public List<EachQuestion> data;
    }
}

