//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Purchasing;
//using UnityEngine.UI;
//using UnityEngine.Networking;

//public class payment : MonoBehaviour
//{
//    public int value;
//    public Text message;
//    private int newrirosBought;
//    private int oldrirosBought;
//    private int rirosBalance;
//    private int rirosEarnt;
//    private int rirosSpent;
//    private justSetRiros justSetRiros;
//    private bool isUser;
//    public int rirosValue;
//    string posturl = "http://masterchange.today/php_scripts/setriros.php";

//    // Start is called before the first frame update

//    private void UpdateRiros()
//    {
//        if (PlayerPrefs.HasKey("dbuserid"))
//        {
            
//            isUser = true;
//        }
//        else
//        {
//             isUser = false;
//        }
//        oldrirosBought = PlayerPrefs.GetInt("rirosBought");
//        newrirosBought = oldrirosBought + rirosValue;
//        PlayerPrefs.SetInt("rirosBought", newrirosBought);
//        ////if (value == 1)
//        //{
//        //    newrirosBought = oldrirosBought + 10000;

//        //}
//        //else if (value == 5)
//        //{
//        //    newrirosBought = oldrirosBought + 50000;
//        //    PlayerPrefs.SetInt("rirosBought", newrirosBought);
//        //}
//        //else if (value == 10)
//        //{
//        //    newrirosBought = oldrirosBought + 100000;
//        //    PlayerPrefs.SetInt("rirosBought", newrirosBought);
//        //}
//        //else if (value == 20)
//        //{
//        //    newrirosBought = oldrirosBought + 200000;
//        //    PlayerPrefs.SetInt("rirosBought", newrirosBought);
//        //}

//        //if (value == 1)
//        //{
//        //  //  newrirosBought = oldrirosBought + 10000;
//        //  rirosValue = 10000;
//        //}
//        //else if (value == 5)
//        //{
//        //    //  newrirosBought = oldrirosBought + 50000;
//        //    rirosValue = 50000;
//        //}
//        //else if (value == 10)
//        //{
//        //    //   newrirosBought = oldrirosBought + 100000;
//        //    rirosValue = 100000;
//        //}
//        //else if (value == 20)
//        //{
//        //    // newrirosBought = oldrirosBought + 200000;
//        //    rirosValue = 200000;
//        //}

//        //
//        //Debug.Log("newrirosBought for balance" + newrirosBought);

//        rirosEarnt = PlayerPrefs.GetInt("rirosEarnt");
//        rirosSpent = PlayerPrefs.GetInt("rirosSpent");
//    //    Debug.Log("rirosEarnt for balance" + rirosEarnt);
//   //     Debug.Log("rirosSpent for balance" + rirosSpent);
//  //      Debug.Log("newrirosBought for balance" + newrirosBought);
//        rirosBalance = rirosEarnt + newrirosBought - rirosSpent;
//        PlayerPrefs.SetInt("rirosBalance", rirosBalance);

//    }

//    public void OnPurchaseComplete(Product product)
//    {
//        oldrirosBought = PlayerPrefs.GetInt("rirosBought");
//  //      Debug.Log("oldrirosBought: " + oldrirosBought);
//     //   Debug.Log("rirosValue: " + rirosValue);

//        newrirosBought = oldrirosBought + rirosValue;
//    //    Debug.Log("newrirosBought: " + newrirosBought);
        
//        PlayerPrefs.SetInt("rirosBought", newrirosBought);
    
//    //    rirosEarnt = PlayerPrefs.GetInt("rirosEarnt");
//        Debug.Log("rirosEarnt for balance" + rirosEarnt);

//        rirosSpent = PlayerPrefs.GetInt("rirosSpent");
//      //  Debug.Log("rirosSpent for balance" + rirosSpent);
       
        
//          rirosBalance = rirosEarnt + newrirosBought - rirosSpent;
//    //      Debug.Log("rirosBalance for balance" + rirosBalance);
//          PlayerPrefs.SetInt("rirosBalance", rirosBalance);

//        //UpdateRiros();
//        message.text = "Purchase Successful - balance updated: Ro$" + rirosBalance;
//        StartCoroutine(setRirosDB());
//       //     justSetRiros = FindObjectOfType<justSetRiros>();
//       //    justSetRiros.toBuy(rirosValue);
//    }
//    IEnumerator setRirosDB()
//    {
//  //      Debug.Log("rirosEarnt for balance" + rirosEarnt);
//    //    Debug.Log("rirosSpent for balance" + rirosSpent);
//    //    Debug.Log("newrirosBought for balance" + newrirosBought);

//        WWWForm form = new WWWForm(); cold

//        // form.AddField("rirosEarnt", rirosEarnt);
//        form.AddField("rirosValue", newrirosBought);
//        form.AddField("description", "Purchase Riros");
//        form.AddField("riroType", "Bought");
//        int DBuser = PlayerPrefs.GetInt("dbuserid");
//        form.AddField("userid", DBuser);



//        UnityWebRequest www = UnityWebRequest.Post(posturl, form); // The file location for where my .php file is.
//        yield return www.SendWebRequest();
//        if (www.isNetworkError || www.isHttpError)
//        {
//       //     //Debug.Log(www.error);
//            //errorMessage.text = "We hit a problem: (" + www.error + "). Please skip this screen until we have fixed it";

//        }
//        else
//        {
//   //         //Debug.Log("from the pho" + www.downloadHandler.text);
//        }
//    }
//    public void OnPurchaseFailure(Product product, PurchaseFailureReason reason)
//    {
//        message.text = "Oops, purchase Failed: " + product.definition.id + "failed due to " + reason;
//    }
//}
