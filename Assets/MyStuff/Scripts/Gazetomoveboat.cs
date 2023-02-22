using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazetomoveboat : MonoBehaviour
{
    public bool loop = false;
    public bool mouseHover = false;
    public float counter = 0;
    public EditorPathScript PathToFollow;
    public int CurrentWayPointID = 0;
    public float speedSet;
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
    public float Delay;
    private bool move = false, toggler = false;


    //start buggy after x seconds
    public float SecondsToDelayStart; 
    public float DelayStop;

    Vector3 last_position;
    Vector3 current_position;
    //private void Start()
    //{
    ////    pulpitPosition = pulpit.transform.position;
    ////}
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
            player.transform.position = preTargetObject.transform.position;
            //TargetObject.SetActive(true);
            player.transform.SetParent(preTargetObject.transform);

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
        if ((CurrentWayPointID >= 0) && (CurrentWayPointID <= PathToFollow.path_objs.Count - 1))
        {
            Debug.Log("waypoint" + PathToFollow.path_objs[CurrentWayPointID]);
            float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);
            //     transform.position = Vector3.Lerp(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);
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
                    mouseHover = false;
                }
            }
        }
    }
}


