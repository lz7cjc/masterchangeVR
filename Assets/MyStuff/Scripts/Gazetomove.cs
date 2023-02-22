using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class Gazetomove : MonoBehaviour
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
    //public float rotationSpeed = 5.0f;
    public float rotationSpeed;
    //public string pathName;

    public float SecondsToDelay;

    Vector3 last_position;
    Vector3 current_position;

    void Start()
    {
        // PathToFollow = GameObject.Find(pathName).GetComponent<EditorPathScript>();

        //   last_position = transform.position;




    }
    // Update is called once per frame

    void Update()
    {

        if (mousehover)
        {
            Counter += Time.deltaTime;
            if (Counter >= SecondsToDelay)
            {



                LetsGo();

                // mousehover = false;
                //  Counter = 0;
                //put the action required here
                //    Debug.Log("in the mix");


            }

        }


    }

    // mouse Enter event
    public void MouseHoverChangeScene()
    {

        if (!move)
        {
            print("-111--->>");
            //Debug.Log("setting walk");
            Counter = 0;
            speed = speedset;
            mousehover = true;
            move = true;
        }
        else

        {
            print("-2222--->>");
            mousehover = false;
            speed = 0;
            move = false;
        }
    }

    // mouse Exit Event
    public void MouseExit()
    {
        //  Debug.Log("cancelling walk");

        //mousehover = false;
        Counter = 0;
    }

    public void LetsGo()
    {

        float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);
        var rotation = Quaternion.LookRotation(PathToFollow.path_objs[CurrentWayPointID].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        if (distance <= reachDistance)
        {
            Debug.Log("in  reach distaance");
            CurrentWayPointID++;

        }
        if (CurrentWayPointID > +PathToFollow.path_objs.Count - 1)
        {
            Debug.Log("in  CurrentWayPointID");
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