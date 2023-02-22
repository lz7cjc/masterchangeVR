using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class basicscenechange : MonoBehaviour
{

    //public bool mousehover = false;
   // public float counter = 0;
  //  public string Switchscene;



    // Update is called once per frame
    public void ChangeSceneNow(string Switchscene)
    {

        SceneManager.LoadScene(Switchscene);
    }    

   
}