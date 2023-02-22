
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class reasons_old : MonoBehaviour
{
    public Slider Cost;
    public Slider Control;
    public Toggle MedAdvice;
    public Text TextCost;
    public Text TextControl;


   
    public void Start()
    {
        string reasons2 = Application.persistentDataPath + "/reasons2.json";
        bool doesExistReasons2 = File.Exists(reasons2);

        if (doesExistReasons2)
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/reasons2.json");
            Debug.Log(Application.persistentDataPath + "/reasons2.json");
            PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);


            //set the variables for the form
            Cost.value = loadedPlayerData.cost;
            Control.value = loadedPlayerData.control;
            MedAdvice.isOn = loadedPlayerData.docadvice;
           
        }
    }

    public void WhatCost(float value)
    {
        Debug.Log("New cost value" + Cost.value);
   

    }
    public void WhatControl(float value)
    {
        Debug.Log("New contrl Value " + Control.value);
    }
    public void DocAdvice()
    {
     
    }

    void Update()
    {
        // Debug.Log("starting  + Playerinfo.Start");
        PlayerData playerData = new PlayerData();

        playerData.cost = Cost.value;
        playerData.control = Control.value;
        playerData.docadvice = MedAdvice.isOn;
        TextControl.text = Control.value.ToString();
        TextCost.text = Cost.value.ToString(); 
    


        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.persistentDataPath + "/reasons2.json", json);
         WWWForm form = new WWWForm();
        
        
    }

    private class PlayerData
    {
        //Health factors
        public float cost;
        public float control;
        public bool docadvice;
      
    }



}