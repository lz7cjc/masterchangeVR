using System.Collections;
using UnityEngine;
using UnityEngine.Networking;



public class registerRiros : MonoBehaviour
{
    //remote
    string posturl = "http://masterchange.today/php_scripts/updateRiros.php";
    //local
    //  readonly string posturl = "http://localhost/php_scripts/updateRiros.php";

  //  public Text errorMessage;
    public int rirosValue;
       private int rirosEarnt;
     private int newRiros;
     public string description;
    private int preRirosEarnt;
    private int preRirosSpent;




    public void firstFunction()
    {
        preRirosEarnt = PlayerPrefs.GetInt("rirosEarnt", preRirosEarnt);
        preRirosSpent = PlayerPrefs.GetInt("rirosSpent", preRirosSpent);
        StartCoroutine(riros());
      
    }


IEnumerator riros()
        {
          WWWForm form = new WWWForm();
         form.AddField("description", description);
         newRiros = preRirosEarnt - preRirosSpent + rirosValue;
        form.AddField("riros", newRiros);
        

    UnityWebRequest www = UnityWebRequest.Post(posturl, form); // The file location for where my .php file is.
        yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
              //  errorMessage.text = www.error;

            }
            else
            {
                string userString = www.downloadHandler.text;
                 Debug.Log("from php: " + userString);
                   Debug.Log("Form Upload Complete!");
             
         
            }
         }





}