using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showText : MonoBehaviour
{
    public GameObject theText;

    // Start is called before the first frame update
    
    public void ShowText()
    {
        theText.SetActive(true);
    }
}
