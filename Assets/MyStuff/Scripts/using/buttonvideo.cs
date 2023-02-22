//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking;
//using UnityEngine.UI;
//using TMPro;

//public class buttonvideo : MonoBehaviour
//{
//    public bool optionSelected = false;
//    public float counter = 0;
//    public string Switchscenename;
//    public string VideoUrlLink;
//    private int riroAmount;
//    public TMP_Text TMP_title;
    
//    public string returntoscene;
//    public string nextscene;
//    public int returnstage;
//    public string behaviour;
 
//   // private GameObject cameraTarget;
//    private showhide3d showhide3d;
//    private riroStopGo riroStopGo;
//  //  private Rigidbody player;
//      public void Start()
//    {

//        riroAmount = PlayerPrefs.GetInt("rirosBalance");
//        Debug.Log("riro balance" + riroAmount);
   
//    }
            

//    // Update is called once per frame


//    public void mainFunction()
//    {
//        PlayerPrefs.SetString("returntoscene", returntoscene);
//        PlayerPrefs.SetString("behaviour", behaviour);
//        PlayerPrefs.SetInt("stage", returnstage);
//        if (riroAmount > 50)
//        {

//            PlayerPrefs.SetString("VideoUrl", VideoUrlLink);
//            print("---->>>" + PlayerPrefs.GetString("VideoUrl"));
//            PlayerPrefs.SetString("nextscene", "film");
//            //      player.useGravity = false;

//            showhide3d = FindObjectOfType<showhide3d>();
//            showhide3d.ResetScene();

//        }

//        else
//        {
//            riroStopGo = FindObjectOfType<riroStopGo>();
//            riroStopGo.setButtons();
//            //   player.MovePosition(cameraTarget.transform.position);
//            //   player.transform.SetParent(cameraTarget.transform);

//        }
//    }
//    // mouse Enter event
//    public void selectButton()
//    {
//        //riroAmount = PlayerPrefs.GetInt("rirosbalance"); 
//        Debug.Log("xxx setting scenename");
//        //   Switchscenename = Scenename;
//      optionSelected = true;
//        TMP_title.color = Color.green;


//    }

//    public void deselectButton()
//    {
//        //riroAmount = PlayerPrefs.GetInt("rirosbalance"); 
//        Debug.Log("xxx setting scenename");
//        //   Switchscenename = Scenename;
//        optionSelected = false;
//        TMP_title.color = Color.white;


//    }


//    // mouse Exit Event
//    public void letsGo()
//    {
//         Debug.Log("cancelling scene change");
//      if (optionSelected)
//        {
//            mainFunction();
//        }
//    }
           
//}

   


