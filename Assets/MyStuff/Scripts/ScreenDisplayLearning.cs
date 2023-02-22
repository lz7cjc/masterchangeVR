using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ScreenDisplayLearning : MonoBehaviour
{
    public Toggle unityDontShowLearning;
     private int SkipLearningScreenInt;
    private int SkipSwitchScreenInt;
    private int healthcheck;
    private string whichchange;

    /// <summary>
    /// This is setting and checking the checkbox and reading/writing the screendisplaylearning.json file
    /// 
    /// </summary>
    public void Start()
    {
  

        SkipLearningScreenInt = PlayerPrefs.GetInt("SkipLearningScreenInt");
        SkipSwitchScreenInt = PlayerPrefs.GetInt("SwitchtoVR");
        whichchange = PlayerPrefs.GetString("nextscene"); 
        Debug.Log("///SkipLearningScreen in start from toggle//// " + SkipLearningScreenInt);
        Debug.Log("///SkipSwitchScreenInt in start from toggle//// " + SkipSwitchScreenInt);

        //if (whichchange == "welcome")
        //{
        //    SceneManager.LoadScene("welcome");
        //    PlayerPrefs.DeleteKey("returnToScene");
        //}
        //else
        //{

        
        if (SkipLearningScreenInt == 1)
        { unityDontShowLearning.isOn = true;
        }
        else
        {

            unityDontShowLearning.isOn = false;
        }


        }
    

public void onChangeDontShowLearning()
    {
        Debug.Log("SkipLearningScreenInt " + unityDontShowLearning.isOn);
        if (unityDontShowLearning.isOn)
        {
            PlayerPrefs.SetInt("SkipLearningScreenInt", 1);
            Debug.Log("the value in the if toggle function from player prefs is: " + PlayerPrefs.GetInt("SkipLearningScreenInt"));
        }
        else if (!unityDontShowLearning.isOn)
        {
            PlayerPrefs.SetInt("SkipLearningScreenInt", 0);
            Debug.Log("the value in the if not toggle function from player prefs is: " + PlayerPrefs.GetInt("SkipLearningScreenInt"));
        }
        Debug.Log("the value in the toggle function from player prefs is: " + PlayerPrefs.GetInt("SkipLearningScreenInt"));
    }

    public void toMasterChange()
    {
        SkipLearningScreenInt = PlayerPrefs.GetInt("SkipLearningScreenInt");
            Debug.Log("which button showSwitchScreenInt " + SkipSwitchScreenInt);

        Debug.Log("which button showTrainingSceneInt " + SkipLearningScreenInt);

      //  SkipSwitchScreenInt = PlayerPrefs.GetInt("SkipSwitchScreenInt");
       // SkipLearningScreenInt = PlayerPrefs.GetInt("SkipLearningScreenInt");
        Debug.Log("what is learning set to?" + SkipLearningScreenInt);
        Debug.Log("what is SkipSwitchScreenInt set to?" + SkipSwitchScreenInt);
       if (SkipSwitchScreenInt == 0)
        {
            SceneManager.LoadScene("switchtoVR");
        }
        
        else
        {
            SceneManager.LoadScene("everything");
        }



    }

  
   
    
}