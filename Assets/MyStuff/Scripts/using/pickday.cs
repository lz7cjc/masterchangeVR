using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class pickday : MonoBehaviour
{
    public Button today;
    public Button yesterday;
    public Button days2;
    public Button days4;
    public Button days3;
    

    // Start is called before the first frame update

    private void Start()
    {
        if (PlayerPrefs.HasKey("dbuserid"))
        {
            today.interactable = true;
            yesterday.interactable = true;
            days2.interactable = true;
            days4.interactable = true;
            days3.interactable = true;

        }
    }
    // Update is called once per frame
    public void onChooseDay0()
    {

        PlayerPrefs.SetInt("whichday", 0);
        SceneManager.LoadScene("drinkrecord");

    }
    public void onChooseDay1()
    {
      
        PlayerPrefs.SetInt("whichday", 1 );
        SceneManager.LoadScene("drinkrecord");

    }
    public void onChooseDay2()
    {

        PlayerPrefs.SetInt("whichday", 2);
        SceneManager.LoadScene("drinkrecord");

    }
    public void onChooseDay3()
    {

        PlayerPrefs.SetInt("whichday", 3);
        SceneManager.LoadScene("drinkrecord");

    }
    public void onChooseDay4()
    {

        PlayerPrefs.SetInt("whichday", 4);
        SceneManager.LoadScene("drinkrecord");

    }
}
