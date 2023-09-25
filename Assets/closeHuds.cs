using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeHuds : MonoBehaviour
{
    //HUD1
    public GameObject hudprimary1;
    public GameObject hudprimary2;
    public GameObject hudprimary3;
    public GameObject hudprimary4;
    public GameObject turnHudOn1;
    public GameObject turnHudOn2;
    public GameObject turnHudOn3;
    public GameObject turnHudOn4;
    public GameObject turnHudOff1;
    public GameObject turnHudOff2; 
    public GameObject turnHudOff3; 
    public GameObject turnHudOff4;
    public GameObject hudZones1;
    public GameObject hudZones2;
    public GameObject hudZones3;
    public GameObject hudZones4;
    public GameObject hudMove1;
    public GameObject hudMove2;
    public GameObject hudMove3;
    public GameObject hudMove4;
    public GameObject showWalk1;
    public GameObject showWalk2;
    public GameObject showWalk3;
    public GameObject showWalk4;
    public GameObject dontWalk1;
    public GameObject dontWalk2;
    public GameObject dontWalk3;
    public GameObject dontWalk4;
    // Start is called before the first frame update
    public void CloseHud()
    {
        Debug.Log("in the close hud bit");
        //hide the top tool bar
        hudprimary1.SetActive(false);
        hudprimary2.SetActive(false);
        hudprimary3.SetActive(false);
        hudprimary4.SetActive(false);
        //turn off the - minus sign
        turnHudOff1.SetActive(false);
        turnHudOff2.SetActive(false);
        turnHudOff3.SetActive(false);
        turnHudOff4.SetActive(false);
        //turn on the + plus sign
        turnHudOn1.SetActive(true);
        turnHudOn2.SetActive(true);
        turnHudOn3.SetActive(true);
        turnHudOn4.SetActive(true);
        //turn off the zones sub menu
        hudZones1.SetActive(false);
        hudZones2.SetActive(false);
        hudZones3.SetActive(false);
        hudZones4.SetActive(false);
        //turn off the move sub section
        hudMove1.SetActive(false);
        hudMove2.SetActive(false);
        hudMove3.SetActive(false);
        hudMove4.SetActive(false);
        //reset the walk button
        showWalk1.SetActive(true);
        showWalk2.SetActive(true);
        showWalk3.SetActive(true);
        showWalk4.SetActive(true);
        //reset the show/hide toggle to not showing
        dontWalk1.SetActive(false);
        dontWalk2.SetActive(false);
        dontWalk3.SetActive(false);
        dontWalk4.SetActive(false);
        // - do i need to reset showing?
    }
}
