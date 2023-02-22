
using UnityEngine;
using System;

public class CTscancountdown : MonoBehaviour
{
    DateTime currentDate;
    DateTime apptDate;
    //DateTime oldDate;
   
  
    public void countdown()
    {
        long setInitialDate = Convert.ToInt64(PlayerPrefs.GetString("CTstartpoint"));
        Debug.Log("setInitialDate" + setInitialDate);
        //long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));

        //Convert the old time from binary to a DataTime variable
        DateTime displaystart = DateTime.FromBinary(setInitialDate);
        print("displaystart " + displaystart);

        //calculate the number of days left until can unlock - saved date in PP vs current date
        TimeSpan timeleft = displaystart.Subtract(currentDate);
        string format = @"mm";

        Debug.Log("timeleft: " + timeleft.ToString(format));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
