using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LearnTips : MonoBehaviour
{
   
    public Text message1;
    public Text message2;
    private float numRiros;
    private int jcint;
    private justGetRiros justGetRiros;
    private bool youshallpass;


    public void Start()
    {
        //justGetRiros = FindObjectOfType<justGetRiros>();
        //justGetRiros.getRiros();
        
        numRiros = PlayerPrefs.GetInt("rirosBalance");
        jcint = PlayerPrefs.GetInt("JCP");
        
            youshallpass = PlayerPrefs.HasKey("dbuserid");
        

        if (!youshallpass)
        {
            message1.text = "So you jumped right in -that is what we would have done.But to get the most out of our world, you will need to tell us about yourself. Not all at once but there are areas you can't access without giving us some information, for example the hospital. Do tell us about yourself when you feel comfortable so we can better personalise your experience";
        }
        else
        {
          
            message1.text = "Thanks for registering. You will have seen you earnt some Riro$. There are plenty of other things you can tell us to further personalise your experience and earn more";
        }

        if (numRiros == 10000)
        {
            
            message2.text = "We gave you Riro$10,000 when you first joined our world. Riros are the in-world currency and you can either buy these or else earn through completing tasks, consultations and other interactions in the World of MasterChange";
        }
        else if (numRiros > 5000)

        {
            message2.text = "Your Riro balance is looking pretty healthy: Ro$" + numRiros + ". Riros are the in-world currency and you can either buy these or else earn through completing tasks, consultations and other interactions in the World of MasterChange";
        }

        else

        {
            message2.text = " Ro$" + numRiros + " . You can earn more Ro$ by adding more information or you can buy them. We will be adding more all the time so check back regularly when you start up the app.";
        }
       
    }




   



}