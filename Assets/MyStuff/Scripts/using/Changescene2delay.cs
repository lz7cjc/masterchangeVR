using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Changescene2delay : MonoBehaviour
{
    public float delayTime;
    private float counter=0;
    private bool delay;
    private showText showText;

    void Update()
    {
        Debug.Log("delaying call to function. Delay is:" + delayTime + " counter is: " + counter);
        if (delay)
        {
            counter += Time.deltaTime;
            if (counter >= delayTime)
            {
                ChangeSceneNow1();
            }
        }
    }

    // Update is called once per frame

    public void starthere()
    {
        if ((PlayerPrefs.HasKey("SwitchtoVR") && PlayerPrefs.GetInt("SwitchtoVR") == 1))
        {
                Debug.Log("loading switchtovrscreen");
                SceneManager.LoadScene("switchtovr");
        }
        else if (!PlayerPrefs.HasKey("SwitchtoVR"))
        {
            SceneManager.LoadScene("switchtovr");
        }
        else
        {
            showText = FindObjectOfType<showText>();
            showText.ShowText();
            delay = true;

        }
        
    }
    public void ChangeSceneNow1()
    {
         SceneManager.LoadScene("everything");
    
    }
    

   
}