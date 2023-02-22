using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour
{
    public Transform vrCamera;
    public float speed = 3.0f;
    private bool moveNow = false;
    public bool mouseHover = false;
    public bool move = false;
    public float counter = 0;
    public float SecondsToDelay = 1;
    public float speedSet;
    public bool increaseSpeed;
    public bool decreaseSpeed;
    public GameObject stopSign;
    public GameObject faster;
    public GameObject slower;
    public GameObject startSign;
    //stop buggy after x seconds
    public float DelayStop;
    public float Delay;
    //stop buggy after x seconds
    private bool toggler = false;
private bool turnOff = false;
    private bool turnOn = false;
    public Rigidbody floor;
    public Rigidbody player;
    public void Update()
    {
        if (mouseHover)
        {
            //Debug.Log("speed is" + speedSet + " because I am moving:" + move);
            counter += Time.deltaTime;
            if (counter < Delay && !move)
            {
                counter += Time.deltaTime;
            }
            else if (counter >= Delay && !toggler)
            {
                toggler = !toggler;
                move = !move;
                speedSet = speed;

            }
            else if (counter < DelayStop && move)
            {
                counter += Time.deltaTime;
            }
            else if (counter >= DelayStop && !toggler)
            {
                toggler = !toggler;
                move = !move;

                speedSet = 0;

            }
        }
        if (speedSet > 0)
        {
            LetsGo();
        }
    }
    // mouse Enter event
    public void OnMouseEnter()
    {
        mouseHover = true;
    }
    public void OnMouseExit()
    {
        mouseHover = false;
        toggler = false;
        counter = 0;
    }

   

    public void SpeedUp()
    {
        turnOn = true;
        if (turnOn)
        {
            speed = speedSet + 0.2f;
            Debug.Log("speeding up is: " + speed);
        }
        turnOn = false;
    }
    public void SlowDown()
    {
        turnOn = true;
        if (turnOn)
        {
            speed = speedSet - 0.2f;
            Debug.Log("slowing down  is: " + speed);

        }
        turnOn = false;
    }
      
        public void LetsGo()
    {
        stopSign.SetActive(true);
        startSign.SetActive(false);
       // transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
       player.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;

        //}
    }

   
}

