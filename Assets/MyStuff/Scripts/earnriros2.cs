using UnityEngine;
using UnityEngine.UI;

public class earnriros2 : MonoBehaviour
{
    public Text notregistered;
    private int rirosEarnt;
    private int rirosBought;
    private int rirosSpent;
    private int rirosBalance;
    private int newRiros;

    //how much do you earn
    public int riroValue;
   
    //call the motherfunction
    private justSetRiros justSetRiros;

  

    // Start is called before the first frame update
    void Start()
    {
       
         if (!PlayerPrefs.HasKey("dbuserid"))
         { 
            notregistered.text = "You aren't registered/logged on. Your riros will only be saved on your phone and might be lost. Protect your Riros: Register";
           
         }
    }
    // Update is called once per frame
    public void EarntRiros()
    {
        rirosEarnt = PlayerPrefs.GetInt("rirosEarnt");
        rirosBought = PlayerPrefs.GetInt("rirosBought");
        rirosSpent = PlayerPrefs.GetInt("rirosSpent");
        newRiros = rirosEarnt + riroValue;
        PlayerPrefs.SetInt("rirosEarnt", newRiros);

        
        rirosBalance = rirosBought + newRiros - rirosSpent;
        PlayerPrefs.SetInt("rirosBalance", rirosBalance);
       

        //justSetRiros = FindObjectOfType<justSetRiros>();
        //    justSetRiros.pushRiros();
       

    }

  
}
