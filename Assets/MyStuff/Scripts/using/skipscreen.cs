using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class skipscreen : MonoBehaviour
{
    private int switchtoVR;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("switchtovr"))
        { 
        if (PlayerPrefs.GetInt("SwitchtoVR") == 0)
        {
            Debug.Log("redirect as skipping switchtovr");
            SceneManager.LoadScene("everything");
        }
           }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
