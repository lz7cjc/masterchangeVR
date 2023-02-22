using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InterSkipSwitchToVr : MonoBehaviour
{
    private bool doesExist;
   private bool showTrainingScene;
    private bool doesExistTraining;
    private bool showSwitchScreen;


    /// <summary>
    /// This will skip the switchvr screen is checked the don't sow this screen again box
    /// 
    /// </summary>
    public void Start()
    {
        Debug.Log("////start of start function//// ");

        //read the JSON file. Should we be skipping this screen - if set to True then check whether to skip learning and go straight to VR
        string existsPath = Application.persistentDataPath + "/ScreenDisplay.json";

    //doesExist = PathFileExists(StringBuilder existsPath);

        // file exists, what does it say
        if (doesExist)
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/ScreenDisplay.json");
            PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
            showSwitchScreen = loadedPlayerData.jsonDontShowVRScreenDisplay;
            //showTrainingScene = loadedPlayerData.jsonDontShowLearning;
       //     Debug.Log("jsonDontShowVRScreenDisplay " + showSwitchScreen);

            //skipping this screen; now decide where to go

            if (showSwitchScreen)
            {
                Debug.Log("in the function to skip the screen");
                string existsPathLearning = Application.persistentDataPath + "/ScreenDisplayLearning.json";
             
                bool existsPathLearningTrue = File.Exists(existsPathLearning);
                if (existsPathLearningTrue)
                {
           //         Debug.Log("in the function to decide whether to skip the learning");

                    string json1 = File.ReadAllText(Application.persistentDataPath + "/ScreenDisplayLearning.json");
                    PlayerData loadedPlayerData1 = JsonUtility.FromJson<PlayerData>(json1);
                    showTrainingScene = loadedPlayerData1.jsonDontShowLearning;
      //              Debug.Log("do we show showTrainingScene" + showTrainingScene);

                }
                else
                {
        //            Debug.Log("in the function to go to the learning");

                    showTrainingScene = false;
                }

            
                if (showTrainingScene)
                {
                    SceneManager.LoadScene("startup");
                }

                else
                {
                    SceneManager.LoadScene("learning");
                }

            }


        }
    //    Debug.Log("////end of start function//// ");

    }
       
   

    private class PlayerData
    {
        //VRinstructions
        public bool jsonDontShowVRScreenDisplay;
         public bool jsonDontShowLearning;

    
}
 
   
    
}