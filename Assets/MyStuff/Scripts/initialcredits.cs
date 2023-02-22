using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialcredits : MonoBehaviour
{
    private int creditsGiven;
    private int riros;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("creditsGiven"))
        {
            PlayerPrefs.SetInt("creditsGiven", 1);
            PlayerPrefs.SetInt("rirosEarnt", 5000);
            PlayerPrefs.SetInt("rirosBalance", 5000);
            PlayerPrefs.SetInt("rirosSpent", 0);
        }
        if (!PlayerPrefs.HasKey("SkipLearningScreenInt"))
            {
            PlayerPrefs.SetInt("SkipLearningScreenInt", 0);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
