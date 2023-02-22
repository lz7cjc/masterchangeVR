using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;

public class votingstars : MonoBehaviour
{
    //remote
    string posturl = "http://masterchange.today/php_scripts/votingstars.php";
    //local
    //readonly string posturl = "http://localhost/php_scripts/votingstars.php";
    public string filmURL;
    private int good;
    private int bad;
    private int broken;
    public Image star1;
    public Image star2;
    public Image star3;
    private float likeratio;

    public void Start()
    {
        StartCoroutine(GetVotes1());
    }

    IEnumerator GetVotes1()
    {

        WWWForm form = new WWWForm();
        form.AddField("filmURL", filmURL);
        Debug.Log("filurl" + filmURL);
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
            Debug.Log("json is" + json);

            //assign json to object
            /*
             * 
             * In order to validate the JSON data, Instead of using the regular JsonUtility
             * class, we will use the CustomParser created to prevent this kind of errors
             * 
             */
            //var obj = JsonUtility.FromJson<Votes>("{\"data\":" + json + "}");

            JsonData<Votes> votesData = CustomParser.FromJson<Votes>("{\"data\":" + json + "}"); // The new parser, very similar to the old one
            Votes obj = new Votes(); // An ampty T object, to receive the data. Notice it will retain the name obj so we don't have to change anything else on your code

            if (votesData.success)
            {
                obj = votesData.json; // If success, means the data is valid. We can now put the new data into obj

                //foreach (var vote in obj.data)
                for (int i = 0; i < obj.data.Count; i++)
                {
                    Debug.Log(obj.data[i].count + "\n");
                    Debug.Log(obj.data[i].Voted + "\n");
                    // Debug.Log(vote.Voted + " : " + vote.count);
                    if (obj.data[i].Voted == "good")
                    {
                        good = obj.data[i].count;
                        Debug.Log("Good" + good);
                    }
                    else if (obj.data[i].Voted == "bad")
                    {
                        bad = obj.data[i].count;
                        Debug.Log("Bad" + bad);
                    }
                    else if (obj.data[i].Voted == "broken")
                    {
                        broken = obj.data[i].count;
                        Debug.Log("Broken  " + broken);

                    }
                }
                Debug.Log("Good" + good);
                Debug.Log("Bad" + bad);
                Debug.Log("Broken  " + broken);
            }
            else
            {
                Debug.LogWarning("Warning. Json data is invalid");
            }
        }

        // check the number of votes, good and bad - if either are zero then need to manually assign to avoid divide by 0 error
        //good and bad votes    
        if (bad > 0 && good > 0)
        {
            likeratio = good / bad;
            Debug.Log("likeratio  " + likeratio);
        }
        //no bad votes and between 1 and 20 good votes - so quite popular... manually assign likeratio
        else if (bad == 0 && good > 10 && good <= 20)
        {
            likeratio = 3;
            Debug.Log("likeratio  " + likeratio);

        }

        else if (bad == 0 && good > 20 && good <= 50)
        {
            likeratio = 8;
            Debug.Log("likeratio  " + likeratio);

        }
        else if (bad == 0 && good > 50)
        {
            likeratio = 12;
            Debug.Log("likeratio  " + likeratio);

        }




        //no need to worry about no good rating whilst having bad ratings as these will be removed if the number of bad ratings gets too high, otherwise displays no stars

        if ((likeratio > 1) && (likeratio <= 3))
        {

            star1.enabled = true;
            star2.enabled = false;
            star3.enabled = false;
            Debug.Log("in 1");
        }
        else if ((likeratio > 3) && (likeratio <= 5))
        {
            Debug.Log("2 star");
            star1.enabled = true;
            star2.enabled = true;
            star3.enabled = false;
            Debug.Log("in 3-5");
        }

        else if (likeratio > 5)
        {
            star1.enabled = true;
            star2.enabled = true;
            star3.enabled = true;
            Debug.Log("in over 5");
        }

        else
        {
            star1.enabled = false;
            star2.enabled = false;
            star3.enabled = false;
            Debug.Log("else else else no like ratio");


        }


        //numberofVotes loadedPlayerData = JsonUtility.FromJson<numberofVotes>(json);

        //// int randompick = RandomiserTip(toppick);
        //for (int i = 0; i < loadedPlayerData.data.Count; i++)
        //{

        //    Debug.Log(loadedPlayerData.data[i].jsonvoted + "\n");
        //    Debug.Log(loadedPlayerData.data[i].jsoncount + "\n");

        //}

        //Debug.Log("good votes" + goodvotes);
        //Debug.Log("bad votes" + badvotes);

    }



    // Use this for initialization







    public class Votes
    {
        public List<VoteInfo> data;
    }

    [System.Serializable]
    public class VoteInfo
    {
        public string Voted;
        public int count;
    }

}

