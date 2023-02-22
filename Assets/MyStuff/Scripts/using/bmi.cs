using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class bmi : MonoBehaviour
{
    public Slider height;
    public Slider weight;
    private float BMI;
    public Text BMIvalue;
    //BMI = kg/m2
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BMI = weight.value / ((height.value/100 * height.value/100));
        BMIvalue.text = "BMI: " + BMI.ToString();
        Debug.Log("BMI = " + BMIvalue);
    }
}
