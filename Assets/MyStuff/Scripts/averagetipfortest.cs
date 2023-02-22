using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System;

public class averagetipfortest : MonoBehaviour
{
    //remote
    string posturl = "http://masterchange.today/php_scripts/filmaveragescores.php";
    //local
  //  readonly string posturl = "http://localhost/php_scripts/filmaveragescores.php";
    public string filmURL;
    public Image star1;
    public Image star2;
    public Image star3;
    public Text score;
    //public Text errorMessage;
    private int average;
    // private float likeratio;

    public void Start()
    {
        StartCoroutine(GetVotes1());
    }

    IEnumerator GetVotes1()
    {

        WWWForm form = new WWWForm();
        form.AddField("filmURL", filmURL);
     // Debug.Log("filurl" + filmURL);
        UnityWebRequest www = UnityWebRequest.Post(posturl, form); // The file location for where my .php file is.
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            //errorMessage.text = "We hit a problem: (" + www.error + "). Please skip this screen until we have fixed it";

        }
        else
        {

            string json = www.downloadHandler.text;
             Debug.Log("vvvv json is " + json + "filurl:" + filmURL);
            averageTips loadedresults = JsonUtility.FromJson<averageTips>(json);

            {
               average = loadedresults.score;
               Debug.Log("llll average score is" + average);
            }
            score.text = average.ToString();

            if ((average > 250) && (average <= 450))
            {

                star1.enabled = true;
                star2.enabled = false;
                star3.enabled = false;
              //  Debug.Log("in 1");
            }
            else if ((average > 451) && (average <= 750))
            {
          //      Debug.Log("2 star");
                star1.enabled = true;
                star2.enabled = true;
                star3.enabled = false;
           //     Debug.Log("in 3-5");
            }

            else if (average > 750)
            {
                star1.enabled = true;
                star2.enabled = true;
                star3.enabled = true;
            //    Debug.Log("in over 5");
            }

            else
            {
                star1.enabled = false;
                star2.enabled = false;
                star3.enabled = false;
             

            }
              
      

        }
    }

    private class averageTips
    {
        public int score;

   
    }

}
