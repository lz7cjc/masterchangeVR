//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public class vrerror : MonoBehaviour
//{
//    public GameObject panelerror;
//    public GameObject mainpanel;
//    private int VRerror;
//    public Text moneyoffer;
//    private justSetGetRiros justSetGetRiros;
//    private int rirosEarnt;
//    private int showMessage;
//    // Start is called before the first frame update
//    void Start()
//    {
//        VRerror = PlayerPrefs.GetInt("VRerror");
//        // showMessage = PlayerPrefs.GetInt("showMessage");
//        showMessage = globalvariables.Instance.f_VRmessage;
//        if (showMessage == 1)
//        {
//          //  Debug.Log("in the showmessage staatement");
//            if (VRerror == 0)
//            {
//                panelerror.SetActive(true);
//                mainpanel.SetActive(false);
//                moneyoffer.text = "We know this is frustrating, so we are crediting you with Ro$20,000 by way of apology";
//            }
//           else if (VRerror == 1)
//            {
//                panelerror.SetActive(true);
//                mainpanel.SetActive(false);
//                moneyoffer.text = "This time we don't payout Riros; otherwise it would be too easy to game the system";
//            }
//            else if (VRerror == 2)
//            {
//                panelerror.SetActive(true);
//                mainpanel.SetActive(false);
//                moneyoffer.text = "Sorry, we have this ongoing problem with getting back into VR. It is top of our priorities to fix";
//            }
//            else
//            {
//                panelerror.SetActive(true);
//                mainpanel.SetActive(false);
//                moneyoffer.text = "We would love to talk to you about your use of the app as you are clearly a power user. Get in touch power@masterchange.today";
//            }
//        }
//        else
//        {
//            mainpanel.SetActive(true);
//            panelerror.SetActive(false);
//        }
//    }

//    // Update is called once per frame
//    public void closePanel()
//    {
//        mainpanel.SetActive(true);
//        panelerror.SetActive(false);
//          if (VRerror == 0)
//          { 
//            if (PlayerPrefs.HasKey("dbuserid"))
//                {
//                    justSetGetRiros = FindObjectOfType<justSetGetRiros>();
//                    justSetGetRiros.toEarn();
//                }
//                else
//                {  
//                         rirosEarnt = PlayerPrefs.GetInt("rirosEarnt");
//                        PlayerPrefs.SetInt("rirosEarnt", rirosEarnt + 20000);
            
           
//                     //  int rirosBalance = PlayerPrefs.GetInt("rirosBalance");
//                        int rirosSpent = PlayerPrefs.GetInt("rirosSpent");
//                        int rirosBought = PlayerPrefs.GetInt("rirosBought");
//                        rirosEarnt = PlayerPrefs.GetInt("rirosEarnt");

//                        PlayerPrefs.SetInt("rirosBalance", rirosBought+rirosEarnt-rirosSpent);
//                }
            
//          }
//        PlayerPrefs.SetInt("VRerror", VRerror+1);
//        globalvariables.Instance.f_VRmessage = 0;

//    }

//}
