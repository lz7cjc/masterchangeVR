/////////////////////////////////
///legacy  now using just set riros and created isloggedon to check user first
///
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class earnriros : MonoBehaviour
{
    private int DBuser;
    public Text notregistered;
   
    //how much do you earn
    public int riroValue;
    private bool isUser;
    private justSetRiros justSetRiros;
    public string PPlabel;
    public GameObject Masterchange;
    public GameObject Register;
    public GameObject Logon;


    private bool payout;

    // Start is called before the first frame update
   public void checkuser()
    {
       
         if (PlayerPrefs.HasKey("dbuserid"))
        {
            DBuser = PlayerPrefs.GetInt("dbuserid");
            isUser = true;
            Register.SetActive(false);
            Logon.SetActive(false);
            Masterchange.SetActive(true);

        }
        else
        { 
        notregistered.text = "You aren't registered/logged on. Please register to continue";
            Register.SetActive(true);
            Logon.SetActive(true);
            Masterchange.SetActive(false);

            isUser = false;
        }

    //    if (PlayerPrefs.HasKey(PPlabel))
    //    {
    //       payout = false;
    //    }
    //    else
    //    {
    //        payout = true;
    //    }
    
    //if (payout)
    //    {
    //                    justSetRiros = FindObjectOfType<justSetRiros>();
    //            justSetRiros.pushRiros();
    //    }


   }

    
}
