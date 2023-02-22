using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class tips_welcome : MonoBehaviour
{

  //  public Text textJC;
    public Text textnrt;
    private bool doesExisthabits;
    //private Text textRiros;


    public void Start()
    {
        string habits = Application.persistentDataPath + "/habit1.json";
        doesExisthabits = File.Exists(habits);
    if (doesExisthabits)
        {

        string json = File.ReadAllText(Application.persistentDataPath + "/habit1.json");
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
            if (loadedPlayerData.nrt)
            {

             textnrt.text = "You told us you are using NRT. Follow the directions and keep using it until the end of the course. This will help you enormously with cravings";

            }
            else if (loadedPlayerData.ttfcless)
            {

                textnrt.text = "Smoking within 30 minutes of waking is a sign that you are a heavy smoker. Try taking Nicotine Replacement Therapy to help with your cravings";

            }
            else
            {

                textnrt.text = "Not smoking within 30 minutes of waking, suggests that you are a lighter smoker. But giving up can still be tough. Increase your chance of success by using Nicotine Replacement Products";

            }


        }

    

    }




    private class PlayerData
    {
       //Health factors
        public bool ttfcless;
        public bool ttfcmore;
        public bool nrt;
        
    }




}