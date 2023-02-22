using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathtomoveinctarget : MonoBehaviour
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
    //public string pathName;
   // public GameObject movetarget;

   //start buggy after x seconds
    public float SecondsToDelayStart;


    Vector3 last_position;
    Vector3 current_position;

    public GameObject player;
    public GameObject cameratarget;



    void Update()
    {

        if (mousehover)
        {
            Counter += Time.deltaTime;
            if (Counter >= SecondsToDelayStart)
            {
              
                player.transform.position = cameratarget.transform.position;
                player.transform.SetParent(cameratarget.transform);
                float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position) - 1;
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
                    }
                }



            }

        }


    }

    // mouse Enter event
    public void MouseHoverChangeScene()
    {

       // Counter = 0;
        // enter in if condition odd time 
        //start moving
       
            print("Going from stationary to moving");
            //Debug.Log("setting walk");
            mousehover = true;
          
           
    }



    public void LetsGo()
    {

        
    }
}