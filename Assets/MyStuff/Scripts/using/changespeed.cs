//basic stop start move item when the target is already sitting within the object

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

using UnityEngine.SceneManagement;


public class changespeed : MonoBehaviour
{
    public bool loop = false;
    public bool mouseHover = false;
    private float counter = 0;
    private float speedSet;
    public float Delay;
    public Rigidbody player;
    public TMP_Text speedvalue;

    public int deltaSpeed;
  
    public void Update()
    {
        if (mouseHover)
        {
            Debug.Log("hhh1 old  speed is" + speedSet + "deltaSpeed" + deltaSpeed + "new speed:" + speedSet);

            counter += Time.deltaTime;
         
            //waiting to hit threshold to trigger walking
            if (counter >= Delay)
            {
                //        Debug.Log("hhh2");
                speedSet = speedSet + deltaSpeed;
               
                  
                Debug.Log(" speedSet = speed" + speedSet);
                 LetsGo();
                


            }

        }

    }
    
   

    // mouse Enter event
    public void OnMouseEnter()
    {
        Debug.Log("what is the initial speed" + speedSet);
        mouseHover = true;
       
        
         
    }
    public void OnMouseExit()
    {
        
        mouseHover = false;
        
        counter = 0;
    }
    public void LetsGo()
    {
   Debug.Log("in letsgo speed is  " + speedSet + mouseHover);

            player.MovePosition(transform.position + Camera.main.transform.forward * speedSet * Time.deltaTime);
            speedvalue.text = speedSet.ToString();
    }
  
}

    

