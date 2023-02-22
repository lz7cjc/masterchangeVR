using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazetomovepulpit : MonoBehaviour
{
    public bool loop = false;
    public bool mousehover = false;
    public bool move = false;
    public float Counter = 0;
    public EditorPathScript PathToFollow;
    public int CurrentWayPointID = 0;
    public float speedset;
    private float speed;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public GameObject hidesign;
    public GameObject pulpit;
    public GameObject postTargetObject;
    public GameObject preTargetObject;
    public GameObject player;
    private bool canstillcancel = true;
    private Vector3 pulpitPosition;


    //start buggy after x seconds
    public float SecondsToDelayStart;

    Vector3 last_position;
    Vector3 current_position;
    private void Start()
    {
        pulpitPosition = pulpit.transform.position;
    }
    void Update()
    {

        if (mousehover)
        {
            Counter += Time.deltaTime;
            if (Counter >= SecondsToDelayStart)
            {
             //   move = true;
                  player.transform.position = preTargetObject.transform.position;
                //TargetObject.SetActive(true);
                player.transform.SetParent(preTargetObject.transform);
                LetsGo();
         
            }

        }


    }

    // mouse Enter event
    public void MouseHoverChangeScene()
    {

        Counter = 0;
        // enter in if condition odd time 
        //start moving
       // if (!move)
       // {
          //  print("Going from stationary to moving");
            //Debug.Log("setting walk");
            mousehover = true;
            speed = speedset;
           
       // }
       
    }


   
    //mouse Exit Event
    public void MouseExit()
    {
        //  Debug.Log("cancelling walk");

        //mousehover = false;
        if (canstillcancel)
        {
            mousehover = false;
            Counter = 0;
            canstillcancel = true;
        }
    }

    public void LetsGo()
    {
        canstillcancel = false;
       // mousehover = false;

        float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position)-1;
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);
        var rotation = Quaternion.LookRotation(PathToFollow.path_objs[CurrentWayPointID].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        if (distance <= reachDistance)
        {
           
            // Debug.Log("in  reach distaance");
            CurrentWayPointID++;
        }

        if (CurrentWayPointID > +PathToFollow.path_objs.Count - 1)
        {
            //Debug.Log("in  CurrentWayPointID");
            if (loop)
            {
                CurrentWayPointID = 0;
            }
            else
            {
                mousehover = false;
                Counter = 0;
                player.transform.position = postTargetObject.transform.position;
                //TargetObject.SetActive(true);
                player.transform.SetParent(postTargetObject.transform);

                pulpit.transform.position = pulpitPosition;
                pulpit.SetActive(false);
                hidesign.SetActive(false);
                CurrentWayPointID = 0;
            }
        }
    }

   
}