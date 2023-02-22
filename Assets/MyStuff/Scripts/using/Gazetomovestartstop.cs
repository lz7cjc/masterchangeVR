 //basic stop start move item when the target is already sitting within the object
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gazetomovestartstop : MonoBehaviour
{
    public bool loop = false;
    public bool mouseHover = false;
    private bool move = false, toggler = false;
    public float counter = 0;
    public EditorPathScript PathToFollow;
    public int CurrentWayPointID = 0;
     private float speedSet = 0;
    public float speed;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 3.0f;
    //public string pathName;
    //start buggy after x seconds
    public float Delay;
    //stop buggy after x seconds
    public float DelayStop;
    void FixedUpdate()
    {
        if (mouseHover)
        {
            Debug.Log("777 speed is" + speedSet + " because I am moving:" + move);
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
                Debug.Log(" speedSet = speed" + speedSet);

            }
            else if (counter < DelayStop && move)
             
            {   Debug.Log("stopping counter < DelayStop && move");
                counter += Time.deltaTime;
            }
            else if (counter >= DelayStop && !toggler) 
            {
                Debug.Log("stop: counter >= DelayStop && !toggler");
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
        Debug.Log("777 mouse enter");
        mouseHover = true;
    }
    public void OnMouseExit()
    {
        Debug.Log("777 mouse exxt");
        mouseHover = false;
        toggler = !toggler;
        counter = 0;
    }
    public void LetsGo()
    {
        if ((CurrentWayPointID >= 0) && (CurrentWayPointID <= PathToFollow.path_objs.Count - 1))
        { 
      //  Debug.Log("waypoint" + PathToFollow.path_objs[CurrentWayPointID]);
        float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);
   //     transform.position = Vector3.Lerp(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);
        var rotation = Quaternion.LookRotation(PathToFollow.path_objs[CurrentWayPointID].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        if (distance <= reachDistance)
        {
           // Debug.Log("in  reach distaance");
            CurrentWayPointID++;

        }
        if (CurrentWayPointID > +PathToFollow.path_objs.Count -1)
        {
          //  Debug.Log("in  CurrentWayPointID");
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
