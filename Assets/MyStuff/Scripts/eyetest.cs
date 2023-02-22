using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eyetest : MonoBehaviour
{
    // Start is called before the first frame update
    public string goodeyes;

    // Update is called once per frame
   public void seteyesight()
    {
        if (goodeyes == "1")
        {
            PlayerPrefs.SetInt("EyesGood", 1);
        }
        else
        {
            PlayerPrefs.SetInt("EyesGood", 0);
        }    
    }
}
