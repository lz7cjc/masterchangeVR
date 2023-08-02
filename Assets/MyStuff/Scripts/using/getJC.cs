using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getJC : MonoBehaviour
{
    private float JC;
    public TMP_Text jcValue; 
    // Start is called before the first frame update
    void Start()
    {
        JC = PlayerPrefs.GetFloat("JCP");
        jcValue.text = JC.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
