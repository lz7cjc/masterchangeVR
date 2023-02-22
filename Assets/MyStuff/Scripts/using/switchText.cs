using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class switchText : MonoBehaviour
{
    public TMP_Text instructText;
    //public Text postText;
    public bool mousehover = false;
    public float counter = 0;
    private floorceilingmove floorceilingmove;
    private bool tempStop;

    // Start is called before the first frame update
    public void Start() 
    {
        instructText.text  = "How to Navigate MasterChange \n You should see a green dot in the centre of your vision. As you look around, it will sometimes change to a circle. If that happens if means you can choose what you are looking at. Keep looking in the same place for 3 seconds to make your choice \n (HINT: you need to be quite close to an object to choose it) \n \n This sign is active but you need to get closer to it.To walk, look at any green or wooden floor, for three seconds. To stop look at the floor again \n When you get close enough you will be able to select it";
        instructText.color = Color.white;
    }
    void Update()

    {
        if (mousehover)
        {
            counter += Time.deltaTime;
            if (counter >= 3)
            {


                mousehover = false;
                counter = 0;
                instructText.color = Color.green;
                instructText.text = "Congratulations \n Now you can choose what to do in MasterChange \n\n Check out posters, signs and TVs as well as buttons to to explore our world";
            }
        }
    }



    // mouse Enter event
    public void MouseHoverChangeScene()
    {

        startStopMove(tempStop = true);
        mousehover = true;
    }

    // mouse Exit Event
    public void MouseExit()
    {

        mousehover = false;
        counter = 0;
    }
    private void startStopMove(bool tempStop)
    {
        if (tempStop)
        {
            floorceilingmove = FindObjectOfType<floorceilingmove>();
            floorceilingmove.stopTheCamera();

        }
    }
}
