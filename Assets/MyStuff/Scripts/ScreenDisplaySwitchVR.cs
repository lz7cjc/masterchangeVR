using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ScreenDisplaySwitchVR : MonoBehaviour
{
    public Toggle unityDontShowVRScreenDisplay;
    //public Text textJC;
    //public Text textRiros;
    //private float numRiros;
  //  public string Switchscenename;

    private bool doesExist;


    public void Start()
    {
        string existsPath = Application.persistentDataPath + "/ScreenDisplay.json";

        doesExist = File.Exists(existsPath);

        //read the JSON file
        if (doesExist)
            { 
                //read Json file
                string json = File.ReadAllText(Application.persistentDataPath + "/ScreenDisplay.json");
  
            PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
            unityDontShowVRScreenDisplay.isOn = loadedPlayerData.jsonDontShowVRScreenDisplay;
        
            //if (unityDontShowVRScreenDisplay)
            //{
            //    SceneManager.LoadScene(Switchscenename);

            //}
        }
       
    }

    public void onChangeShowVRScreenDisplay(bool value)
    {
        Debug.Log("unityDontShowVRScreenDisplay " + unityDontShowVRScreenDisplay.isOn);

    }

    public void Update()
    {
        PlayerData playerData = new PlayerData();
    
        playerData.jsonDontShowVRScreenDisplay = unityDontShowVRScreenDisplay.isOn;
       


        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText(Application.persistentDataPath + "/ScreenDisplay.json", json);


    }

    private class PlayerData
    {
        //VRinstructions
        public bool jsonDontShowVRScreenDisplay;


        ////Jeopardy Coefficient
        //public float jeopardyCoefficient;
    }
 
   
    
}