using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class justGetContent : MonoBehaviour
{
    private int DBuser;
    private string ContentTitle;
    private string ContentDescription;


    //how much do you earn

    string posturl = "http://masterchange.today/php_scripts/getcontent.php";
    //local
    // readonly string posturl = "http://localhost/php_scripts/getcontent.php";


    // Start is called before the first frame update
    void Start()
    {
        getContent();

    }

    public void getContent()
    {
        if (PlayerPrefs.HasKey("dbuserid"))
        {
            DBuser = PlayerPrefs.GetInt("dbuserid");
            StartCoroutine(getContentDB());
        }
    }
    // Update is called once per frame

    IEnumerator getContentDB()
    {

        WWWForm form = new WWWForm();


        form.AddField("userid", DBuser);
        Debug.Log("userid" + DBuser);


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
            json = json.Trim('[', ']');
            Content loadedresults = JsonUtility.FromJson<Content>(json);
            ContentTitle = loadedresults.ContentTitle;
            ContentDescription = loadedresults.ContentDescription;
          
               Debug.Log("from php json" + json);
        }
    }

    private class Content
    {
        public string ContentTitle;
        public string ContentDescription;
      

    }
}
