using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Xml.Schema;


//Used in welcome back
public class Riros : MonoBehaviour

{
    public Text textRiros;
    private justGetRiros justGetRiros;


    public void Start()
    {
        justGetRiros = FindObjectOfType<justGetRiros>();
        justGetRiros.getRiros();
        displayRiros();
       
    }
    public void displayRiros()
    {
        int rirobalance = PlayerPrefs.GetInt("rirosBalance");
        Debug.Log("riros xxx" + rirobalance);
        textRiros.text = rirobalance.ToString();
    }
  }
