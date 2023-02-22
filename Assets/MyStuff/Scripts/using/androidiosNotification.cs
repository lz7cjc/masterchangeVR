using System.Collections;
using System.Collections.Generic;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
#if UNITY_IOS
using Unity.Notifications.iOS;

#endif
using UnityEngine;
using System;
using UnityEngine.UI;


public class androidiosNotification : MonoBehaviour
{
    DateTime currentDate;
    public Text btnText;
    public GameObject hidebutton;
    public bool mousehover = false;
    public float Counter = 0;
    public float SecondsToDelay;

    // Start is called before the first frame update


    private void Start()
    {

        if (PlayerPrefs.GetInt("notificationsent") == 1)
        {

            btnText.text = "Notification Set";
            hidebutton.SetActive(false);
        }

    }




    void Update()
    {

        if (mousehover)
        {
            Counter += Time.deltaTime;
            if (Counter >= 3)
            {

                sendNotification();

                Counter = 0;

            }

        }


    }

    // mouse Enter event
    public void MouseHoverChangeScene()
    {
        Counter = 0;
        mousehover = true;


    }

    // mouse Exit Event
    public void MouseExit()
    {
        mousehover = false;
        Counter = 0;
    }
    public void sendNotification()
    {

#if UNITY_ANDROID
        //remove notifications
        AndroidNotificationCenter.CancelAllDisplayedNotifications();
        //Create Android Notification Channel
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "MasterChange CT Scan notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        //how many minutes to add
        //get the value from PlayerPrefs - it is a long string of numbers



        //Individual notification
        var notification = new AndroidNotification();
        notification.Title = "MasterChange Alert";
        notification.Text = "The technician is ready to conduct your CT scan. Please go back to MasterChange when you are ready. Good luck";

         notification.FireTime = System.DateTime.Now.AddMinutes(PlayerPrefs.GetInt("delaynotification"));
       // notification.FireTime = System.DateTime.Now.AddMinutes(1);
        //send notification
        AndroidNotificationCenter.SendNotification(notification, "channel_id");

        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }




#endif
 
#if UNITY_IOS

var timeTrigger = new iOSNotificationTimeIntervalTrigger()
{
   TimeInterval = new TimeSpan(0, 0, PlayerPrefs.GetInt("delaynotification")),
  //   TimeInterval = new TimeSpan(0, 0, 1),
    Repeats = false
};
      
        var notification = new iOSNotification()
{
    // You can specify a custom identifier which can be used to manage the notification later.
    // If you don't provide one, a unique string will be generated automatically.
    Identifier = "_notification_01",
    Title = "MasterChange Alert",
    Body = "Scheduled at: " + PlayerPrefs.GetInt("delaynotification") + " triggered in 5 seconds",
    Subtitle = "The technician is ready to conduct your CT scan. Please go back to MasterChange when you are ready. Good luck",
    ShowInForeground = true,
    ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
    CategoryIdentifier = "category_a",
    ThreadIdentifier = "thread1",
    Trigger = timeTrigger,
};

        iOSNotificationCenter.ScheduleNotification(notification);
        iOSNotificationCenter.RemoveDeliveredNotification(notification.Identifier);

     

#endif
        btnText.text = "Notification set";
        PlayerPrefs.SetInt("notificationsent", 1);
    }
}
