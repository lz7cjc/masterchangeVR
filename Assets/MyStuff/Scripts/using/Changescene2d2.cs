//using System.IO;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using UnityEngine.Networking;

//public class Changescene2d2 : MonoBehaviour
//{

//    //public bool mousehover = false;
//   // public float counter = 0;
//    public string Switchscene1;
//    private int skipvrscreen1;

//    public void ChangeSceneNow1()
//    {
//        Debug.Log("in teh function ");
//        if (PlayerPrefs.HasKey("SwitchtoVR"))
//        {
//            skipvrscreen1 = PlayerPrefs.GetInt("SwitchtoVR");
//        }

//        if (Switchscene == "switchtovr")
//        {
//            if (skipvrscreen1 == 0)
//            {
//                SceneManager.LoadScene("everything");

//            }
//            else
//            {
//                SceneManager.LoadScene(Switchscene1);
//            }
//        }
//        else
//        {
//            SceneManager.LoadScene(Switchscene1);
//        }
       
        
       

//    }
    

   
//}