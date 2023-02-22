//using System.Collections;
//using System.Collections.Generic;
//using Unity.Notifications.Android;
//using UnityEngine;
//using System;
//using UnityEngine.UI;

//public class androidNotification : MonoBehaviour
//{
//    DateTime currentDate;
//    public Text btnText;
//    public bool mousehover = false;
//    public float Counter = 0;
//    public float SecondsToDelay;

//    // Start is called before the first frame update


//    private void Start()
//    {

//            if (PlayerPrefs.GetInt("notificationsent") == 1)
//            {

//            btnText.text = "Notification Set";
           
//            }
           
//        }
    



//    void Update()
//    {

//        if (mousehover)
//        {
//            Counter += Time.deltaTime;
//            if (Counter >= 3)
//            {



//                Counter = 0;
            
//            }

//        }


//    }

//    // mouse Enter event
//    public void MouseHoverChangeScene()
//    {
//                Counter = 0;
//            mousehover = true;
           
      
//    }

//    // mouse Exit Event
//    public void MouseExit()
//    {
//        mousehover = false;
//           Counter = 0;
//    }
//    public void sendNotification()
//    {

//        //remove notifications
//        AndroidNotificationCenter.CancelAllDisplayedNotifications();
//        //Create Android Notification Channel
//        var channel = new AndroidNotificationChannel()
//        {
//            Id = "channel_id",
//            Name = "Default Channel",
//            Importance = Importance.Default,
//            Description = "MasterChange CT Scan notifications",
//        };
//        AndroidNotificationCenter.RegisterNotificationChannel(channel);

//        //how many minutes to add
//        //get the value from PlayerPrefs - it is a long string of numbers
      


//        //Individual notification
//        var notification = new AndroidNotification();
//        notification.Title = "MasterChange Alert";
//        notification.Text = "When you are ready, the technician is ready to conduct your CT scan. Good luck";

//        notification.FireTime = System.DateTime.Now.AddMinutes(PlayerPrefs.GetInt("delaynotification"));

//        //send notification
//        AndroidNotificationCenter.SendNotification(notification, "channel_id");

//        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");
//        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled)
//        {
//            AndroidNotificationCenter.CancelAllNotifications();
//            AndroidNotificationCenter.SendNotification(notification, "channel_id");
//        }

//        btnText.text = "Notification set";
//        PlayerPrefs.SetInt("notificationsent", 1);
      
//    }


//}
