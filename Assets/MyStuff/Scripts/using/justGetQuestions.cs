//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;
//using UnityEngine.UI;
//using TMPro;

//public class justGetQuestions : MonoBehaviour
//{
//    private int DBuser;
//    private int entryFee;

//    //for json
//    private int prize;
//    private string question;
//    private string behaviour;

//    //for screen
//    public TMP_Text yourQuestionIs;
//    public TMP_Text costToEnterIs;
//    public TMP_Text prizeIs;
//    public TMP_Text behaviourIs;


//    private justGetRiros justGetRiros;


//    //how much do you earn

//    //string posturl = "http://masterchange.today/php_scripts/getriros.php";
//    //local
//  //  readonly string posturl = "http://localhost/php_scripts/getriros.php";
//    //string posturl = "http://masterchange.today/php_scripts/quizquestions.php";
//    //local
//    readonly string posturl = "http://localhost/php_scripts/quizquestions.php";


//    // Start is called before the first frame update
//    void Start()
//    {
//        justGetRiros = FindObjectOfType<justGetRiros>();
//        justGetRiros.fromPPorDB();
//        DBuser = PlayerPrefs.GetInt("dbuserid");
//        callQuestions();
//    }

//    void callQuestions()
//    {
//        StartCoroutine(GetQuestions());
//    }

//    IEnumerator GetQuestions()
//    {
//        WWWForm form = new WWWForm();
//        form.AddField("userid", DBuser);

//        UnityWebRequest www = UnityWebRequest.Post(posturl, form); // The file location for where my .php file is.
//        yield return www.SendWebRequest();
//        if (www.isNetworkError || www.isHttpError)
//        {
//            Debug.Log("there was a yyy" + www.error);
//            //errorMessage.text = "We hit a problem: (" + www.error + "). Please skip this screen until we have fixed it";

//        }
//        else
//        {
//            //update the player prefs
//            string json = www.downloadHandler.text;
//            questions questions = JsonUtility.FromJson<questions>(json);
//            Debug.Log("ocming back: " + json);
//            // riros loadedresults = JsonUtility.FromJson<riros>(json);
         
//            yourQuestionIs = questions.question;
//            behaviourIs = questions.behaviour;
//            costToEnterIs = questions.cost;
//            prizeIs = questions.value;

//            Debug.LogWarning("question" + question);
//            Debug.LogWarning("behaviour" + behaviour);
//            Debug.LogWarning("entryFee" + entryFee);
//            Debug.LogWarning("prize" + prize);



//            //PlayerPrefs.SetInt("rirosEarnt", rirosEarnt);
//            //PlayerPrefs.SetInt("rirosBought", rirosBought);
//            //PlayerPrefs.SetInt("rirosSpent", rirosSpent);
//            //PlayerPrefs.SetInt("rirosBalance", rirosBought + rirosEarnt - rirosSpent);
//            //rirosValue.text = PlayerPrefs.GetInt("rirosBalance").ToString();

//        }
//    }
//    //public class payout
//    //{
//    //    public int paythem;
//    //}
//    private class questions
//    {
//        public int cost;
//        public int value;
//        public string behaviour;
//        public string question;


//    }

//}





