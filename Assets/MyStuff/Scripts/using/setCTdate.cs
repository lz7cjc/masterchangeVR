using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class setCTdate : MonoBehaviour
{
    //DateTime setInitialDate;
    DateTime currentDate;
    DateTime apptDate;
    //DateTime oldDate;
  //  public GameObject exploreContent;
   // public GameObject movement;
    //public GameObject skateboardtgt;
    public GameObject MainCamera;
    public GameObject NotifSend;
    public GameObject TPtoFilm;
    public GameObject onWeGo;
  //  public GameObject waitingtgt;

    public Text displayCountdown;
    public int NotificationSet;
    public TMP_Text notificationMessage;
    //  private showhide3d showhide3d;

    private void Start()
    {
        setScene();
        // test notifcations - shorttime and regenerate each time start app
        // apptDate = DateTime.Now.AddMinutes(5);
        // PlayerPrefs.SetString("CTstartpoint", apptDate.ToBinary().ToString());
    }

    public void setReferenceDate()
    {
     if (!PlayerPrefs.HasKey("CTstartpoint"))
            {
            Debug.Log("xxx in set reference no ctstartpoint key");
                apptDate = DateTime.Now.AddMinutes(300);
               

                PlayerPrefs.SetString("CTstartpoint", apptDate.ToBinary().ToString());
            }
        Debug.Log("xxx in set reference no ctstartpoint key");

        setScene();
    }    

    public void setScene()
    {
       

        //Store the current time when it starts
        currentDate = System.DateTime.Now;
        Debug.Log("22222 in setScene function");
        //  currentDate2 = currentDate.AddDays(3);
        Debug.Log("PlayerPrefs.GetString(VideoUrl) " + PlayerPrefs.GetString("VideoUrl"));

        //did they get the good or bad video? If good then can ask to see bad

        if (PlayerPrefs.GetString("VideoUrl") == "https://youtu.be/1QSS32UG5p8")
        {
            Debug.Log("PlayerPrefs.GetString(VideoUrl2) " + PlayerPrefs.GetString("VideoUrl"));

            displayCountdown.text = "You must be very relieved. What a happy result. Feel free to explore MasterChange, there is plenty else to discover. If you want to see how it may have turned out, with a little less luck, choose to 'See a different path'";
            PlayerPrefs.DeleteKey("VideoUrl");
            NotifSend.SetActive(false);
            onWeGo.SetActive(true);
        }
        else
        {
            onWeGo.SetActive(false);
            //Grab the old time from the player prefs as a long
            if (PlayerPrefs.HasKey("CTstartpoint"))
            {
                //get the value from PlayerPrefs - it is a long string of numbers
                long setInitialDate = Convert.ToInt64(PlayerPrefs.GetString("CTstartpoint"));
                     Debug.Log("setInitialDate" + setInitialDate);
                //long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));

                //Convert the old time from binary to a DataTime variable
                DateTime displaystart = DateTime.FromBinary(setInitialDate);
                  print("displaystart " + displaystart);

                //calculate the number of days left until can unlock - saved date in PP vs current date
                TimeSpan timeleft = displaystart.Subtract(currentDate);
                int delaynotification = (int)timeleft.TotalMinutes;
                PlayerPrefs.SetInt("delaynotification", delaynotification);
                Debug.Log("timeleft" + timeleft.TotalMinutes);
                double timeformaths = timeleft.TotalDays;
                //  string format = @"dd\hh";

                //    print("timeleft: " + timeleft.ToString(format));


                //how do i get this maths comparison to work??
                if (timeformaths >= 0) 
                    {
                    //if (Application.platform == RuntimePlatform.Android)
                    //{
                    NotificationSet = PlayerPrefs.GetInt("notificationsent");
                    if (NotificationSet == 1)
                    {
                        displayCountdown.text = "You will be able to go for your CT Scan in: " + timeleft.ToString("dd") + " days and " + timeleft.ToString("hh") + " hours";
                        NotifSend.SetActive(false);
                        notificationMessage.text = "Whilst you wait for your CT scan, check out some of the other experiences within the World of Masterchange; perhaps visit a calming beach or take a trip through Venice. \n \n Alternatively head to the dashboard where you can tell us more about yourself, allowing us to better tailor your experiencee(you will need to take off your headset, when you get to the dashboard)";

                    }
                    //if notification hasn't been set
                    else
                    {
                        displayCountdown.text = "You will be able to go for your CT Scan in: " + timeleft.ToString("dd") + " days and " + timeleft.ToString("hh") + " hours. \n \n If you would like to set a notification, please look to your left for more information";
                        NotifSend.SetActive(true);
                        notificationMessage.text = "Would you like to receive a notification when we are ready for you? Don't worry you won't receive any other messages from us or anyone else. \n \n To opt in look at the button beneath this poster. \n \n Whilst you wait for your CT scan, check out some of the other experiences within the World of Masterchange; perhaps visit a calming beach or take a trip through Venice. \n \n Alternatively head to the dashboard where you can tell us more about yourself, allowing us to better tailor your experiencee(you will need to take off your headset, when you get to the dashboard)";
                    }
                    TPtoFilm.SetActive(false);
                }
                else
                {
                    displayCountdown.text = "The nurse is ready for you now. Please remove all metal objects and tell the nurse of any concerns before we start";
                      NotifSend.SetActive(false);
                    Debug.Log("am i in ");
                    TPtoFilm.SetActive(true);
             
                }
               
            }


         

        }



    }
}
