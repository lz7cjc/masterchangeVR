using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Networking;

using UnityEngine.SceneManagement;

public class addavatar : MonoBehaviour
{

    public Text avatarURL;
    private string postURL = "https//masterchange.today/php_scripts/addavatar.php";
    private string url;
    public Text errormessage;
    private void addAvatar()
    {
        StartCoroutine(tips());
    }

    IEnumerator tips()
    {
        //write to the filmvotes table via filmvote.php

        url = avatarURL.text;
        int userid = PlayerPrefs.GetInt("dbuserid");
        //   Debug.Log("credit url" + creditURL);

        WWWForm formTips = new WWWForm();
        formTips.AddField("avatar", url);
        formTips.AddField("userid", userid);
        UnityWebRequest www = UnityWebRequest.Post(postURL, formTips); // The file location for where my .php file is.
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            //      Debug.Log(www.error);
            errormessage.text = "We hit a problem: (" + www.error + "). Please continue";

        }
        else
        {
            string json = www.downloadHandler.text;
            //     Debug.Log("from php for film votes: " + json);
        }

    }
}
