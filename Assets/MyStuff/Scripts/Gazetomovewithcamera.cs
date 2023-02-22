using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazetomovewithcamera : MonoBehaviour
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

   //start buggy after x seconds
    public float SecondsToDelayStart;
    //stop buggy after x seconds
    public float SecondsToDelayStop;

   // public GameObject TargetObject;
    public GameObject player;
    public GameObject cameratarget;

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
            if (Counter >= SecondsToDelayStart)
            {
                move = true;
                  player.transform.position = cameratarget.transform.position;
                player.transform.SetParent(cameratarget.transform); 
                LetsGo();
               



            }

        }


    }

    // mouse Enter event
    public void MouseHoverChangeScene()
    {

        Counter = 0;
        if (!move)
        {
            mousehover = true;
            speed = speedset;
           
        }
        else
        {
            //enter in else even time
            //stop moving
            print("Going from moving to stationary");

            //speed = 0;
            // move = false;

            // to delay in seconds we use "StartCoroutine" method
            StartCoroutine(StopBuggyAfterSecond());
        }
    }


    IEnumerator StopBuggyAfterSecond()
    {
        yield return new WaitForSeconds(SecondsToDelayStop);
        // Execute after x seconds here x = SecondsToDelayStop
        mousehover = false;
        speed = 0;
        move = false;     

    }
    ////mouse Exit Event
    //public void MouseExit()
    //{
    //    //  Debug.Log("cancelling walk");

    //    //mousehover = false;
    //    Counter = 0;
    //}

    public void LetsGo()
    {

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
            }
        }
    }
}