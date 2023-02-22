using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanTP : MonoBehaviour
{
//    public GameObject TargetObject;
    public bool mousehover = false;
 //   public GameObject hidewhat;
    public float Counter = 0;
   // public bool childCamera;
    public GameObject player;
    public GameObject cameratarget;
    //private matchfav matchfav;
    //  private getfav getfav;

    //   public GameObject showThis;
    //   public Transform level2signs;
    private floorceilingmove floorceilingmove;
    void Update()
    {

        if (mousehover)
        {
            floorceilingmove = FindObjectOfType<floorceilingmove>();
            floorceilingmove.stopTheCamera();

            Counter += Time.deltaTime;
            if (Counter >= 3)
            {
                mousehover = false;
                Counter = 0;

                showandhide();

            }
        }
    }

    // mouse Enter event
    public void MouseHoverChangeScene()
    {
     //   Debug.Log("setting walk");
        // Markername = ObjectName;
        mousehover = true;
          
       
    
    }

    // mouse Exit Event
    public void MouseExit()
    {
     //   Debug.Log("cancelling walk");
       // Markername = "";
        mousehover = false;
        Counter = 0;
    }

    private void showandhide()
    {

        //for (int j = 0; j < level2signs.childCount; j++)
        //{
        //    level2signs.GetChild(j).gameObject.SetActive(false);
        //}

      //  showThis.SetActive(true);

    //    TargetObject.SetActive(true);
        player.transform.position = cameratarget.transform.position;
        //TargetObject.SetActive(true);
        player.transform.SetParent(cameratarget.transform);

     //   hidewhat.SetActive(false);
    //    getfav = FindObjectOfType<getfav>();
    //    getfav.favReset();

    }
   

}
