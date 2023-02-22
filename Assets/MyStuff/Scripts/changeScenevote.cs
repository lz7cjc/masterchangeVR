using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScenevote : MonoBehaviour
{

    public bool mousehover = false;
    public float counter = 0;
    public string Switchscenename;
    private object Scenename;
    public bool getfromPP;
    

    private void Start()
    {
        if (getfromPP)
        {
            Switchscenename = PlayerPrefs.GetString("nextscene");
            Debug.Log("ghghgh");
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (mousehover)
        {
            counter += Time.deltaTime;
            if (counter >= 3)
            {
                mousehover = false;
                counter = 0;

                SceneManager.LoadScene(Switchscenename);
                if (getfromPP)
                {
                    PlayerPrefs.DeleteKey("nextscene");
                }
            }
        }
    }

    // mouse Enter event
    public void MouseHoverChangeScene()
    {
        Debug.Log("setting scenename");
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