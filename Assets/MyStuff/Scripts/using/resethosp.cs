using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resethosp : MonoBehaviour
{
    public bool mousehover = false;
    public float counter = 0;
    private showhide3d showhide3d;

    void Update()
    {
        if (mousehover)
        {
            counter += Time.deltaTime;
            if (counter >= 3)
            {
                PlayerPrefs.SetInt("stage", 0);
                PlayerPrefs.SetString("nextscene", "hospital");
                PlayerPrefs.SetString("behaviour", "alcohol");
                PlayerPrefs.DeleteKey("setCat");
                mousehover = false;
                counter = 0;


                    showhide3d = FindObjectOfType<showhide3d>();
                    showhide3d.ResetScene();


                }

            }
        }
    

    // mouse Enter event
    public void MouseHoverChangeScene()
    {
        Debug.Log("setting scenename");
        //Switchscenename = Scenename;
        mousehover = true;
    }

    // mouse Exit Event
    public void MouseExit()
    {
        // Debug.Log("cancelling scene change");
        mousehover = false;
        counter = 0;
    }

}
