 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class newPathGazetoMove : MonoBehaviour
{
    #region Enums
    public enum MovementType  //Type of Movement
    {
        MoveTowards,
        LerpTowards
    }
    #endregion //Enums

    #region Public Variables
    public MovementType Type = MovementType.MoveTowards; // Movement type used
    public MovementPath MyPath; // Reference to Movement Path Used
    public float Speed; // Speed object is moving
    public float MaxDistanceToGoal = .1f; // How close does it have to be to the point to be considered at point

    public bool loop = false;
    public bool mouseHover = false;
    private bool move = false, toggler = false;
    public float counter = 0;
    //public EditorPathScript PathToFollow;
    public int CurrentWayPointID = 0;
    //public float speed;
    public float rotationSpeed = 3.0f;
    //public string pathName;
    //start buggy after x seconds
    public float Delay;
    //stop buggy after x seconds
    public float DelayStop;

    #endregion //Public Variables

    #region Private Variables
    private float reachDistance = 1.0f;
    private IEnumerator<Transform> pointInPath; //Used to reference points returned from MyPath.GetNextPathPoint
    private float speedSet = 0;
    #endregion //Private Variables

    void FixedUpdate()
    {
        if (mouseHover)
        {
            Debug.Log("speed is" + speedSet + " because I am moving:" + move);
            counter += Time.deltaTime;
            if (counter < Delay && !move)
            {
                counter += Time.deltaTime;
            }
            else if (counter >= Delay && !toggler)
            {
                toggler = !toggler;
                move = !move;
                speedSet = Speed;

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
    public void LetsGo()
    {
        if (MyPath == null)
        {
            Debug.LogError("Movement Path cannot be null, I must have a path to follow.", gameObject);
            return;
        }

        //Sets up a reference to an instance of the coroutine GetNextPathPoint
        pointInPath = MyPath.GetNextPathPoint();
        Debug.Log(pointInPath.Current);
        //Get the next point in the path to move to (Gets the Default 1st value)
        pointInPath.MoveNext();
        Debug.Log(pointInPath.Current);

        //Make sure there is a point to move to
        if (pointInPath.Current == null)
        {
            Debug.LogError("A path must have points in it to follow", gameObject);
            return; //Exit Start() if there is no point to move to
        }

        //Set the position of this object to the position of our starting point
        transform.position = pointInPath.Current.position;

        if (pointInPath == null || pointInPath.Current == null)
        {
            return; //Exit if no path is found
        }

        if (Type == MovementType.MoveTowards) //If you are using MoveTowards movement type
        {
            //Move to the next point in path using MoveTowards
            transform.position =
                Vector3.MoveTowards(transform.position,
                                    pointInPath.Current.position,
                                    Time.deltaTime * speedSet);
        }
        else if (Type == MovementType.LerpTowards) //If you are using LerpTowards movement type
        {
            //Move towards the next point in path using Lerp
            transform.position = Vector3.Lerp(transform.position,
                                                pointInPath.Current.position,
                                                Time.deltaTime * speedSet);
        }

        //Check to see if you are close enough to the next point to start moving to the following one
        //Using Pythagorean Theorem
        //per unity suaring a number is faster than the square root of a number
        //Using .sqrMagnitude 
        var distanceSquared = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal) //If you are close enough
        {
            pointInPath.MoveNext(); //Get next point in MovementPath
        }
    }
}