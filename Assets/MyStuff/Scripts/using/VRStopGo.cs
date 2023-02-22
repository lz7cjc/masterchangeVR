 //basic stop start move item when the target is already sitting within the object
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VRStopGo : MonoBehaviour
{
    public bool loop = false;
    public bool mouseHover = false;
    private bool move = false, toggler = false;
    private float counter=0;
    private float speedSet;
    // public GameObject walk;
    //public GameObject stopWalking;
    //public GameObject run;
    //public GameObject sprint;


    public float Delay;

    public float DelayStop;

    private bool turnOn = false;
    public Rigidbody floor;
    public Rigidbody player;
 //   public GameObject hud;

    public GameObject maincamera;




 public   void Update()
    {
        if (mouseHover)
        {

            counter += Time.deltaTime;
            if (counter < Delay && !move)
            {
                counter += Time.deltaTime;
            }
            else if (counter >= Delay && !toggler)
            {
                toggler = !toggler;
                move = !move;
             //  speedSet = speedSetInEditor;

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
    public void OnMouseEnter(int speedFromEditor)
    {
        speedSet = speedFromEditor;
        mouseHover = true;
        Debug.Log("new speedset: " + speedSet);
    }
    public void OnMouseExit()
    {
        mouseHover = false;
        toggler = false;
        counter = 0;
    }


    public void LetsGo()
    {

        // = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        // transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;

        Debug.Log("speed in letsgo: " + speedSet);
        player.position = transform.position + Camera.main.transform.forward * speedSet * Time.deltaTime;
        //Debug.Log("hud position " + hud.transform.position);


    }
}
    

