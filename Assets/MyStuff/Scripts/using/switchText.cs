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
    public GameObject steps;
    public GameObject home;
    public GameObject location; 

    // Start is called before the first frame update
    public void Start() 
    {
        instructText.text  = "How to Navigate MasterChange \n \u2022 Choose things using the green dot in the centre of your vision \n \u2022 Anything selectable will result in it turning to a green circle \n \u2022 It will only change to circle if you are quite close \n \u2022 Look at the object for 3 seconds to choose it(you need to keep steady) \n This sign is active so try it now \n \u2022 Above you is a heads up display(HUD) \n \u2022 The feet icon allows you to walk \n \u2022 Look at it for 3 seconds and move towards this sign";
        home.SetActive(false);
        steps.SetActive(true);
        location.SetActive(false);
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
                instructText.text = "Congratulations \n Now you can choose what to do in MasterChange \n\n Check out posters, signs and TVs as well as the three buttons in the heads up display (HUD) above you, to to explore our world \n \n The HUD: The home icon will bring you back here, and the middle icon will open up a menu of all the main zones in MasterChange, so you can teleport directly to them";
                home.SetActive(true);
                steps.SetActive(false);
                location.SetActive(true);

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
