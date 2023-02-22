using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonswap : MonoBehaviour
{
    public GameObject register;
    public GameObject habits;
    public Text line1;
   
    public Text line3;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("dbuserid"))
        {
            habits.SetActive(true);
            line1.text = "It looks like you decided not to fill out the information about your smoking habits";
            
        }
        else
        {
            register.SetActive(true);
            line1.text = "It looks like you decided not to register and fill out the information about your smoking habits";
           
            line3.text = "You need to register so we can save your profile information so it can be used in the future";
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
