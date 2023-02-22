//using System.Collections;
//using System.Collections.Generic;
//using Unity.Notifications.Android;
//using UnityEngine;

//public class mobilemessaging : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {
//        //set up of the notification channel
//        var channel = new AndroidNotificationChannel()
//        {
//            Id = "channel_id",
//            Name = "Results",
//            Importance = Importance.Default,
//            Description = "Next appointment",
//        };
//        AndroidNotificationCenter.RegisterNotificationChannel(channel);

//        //this is the set up of the actual message
//        var notification = new AndroidNotification();
//        notification.Title = "Your results are in";
//        notification.Text = "Head back to MasterChange";
//        notification.FireTime = System.DateTime.Now.AddSeconds(15);

//        //send notification
//        AndroidNotificationCenter.SendNotification(notification, "channel_id");
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
