using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Globalization;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class testseries : MonoBehaviour
{

    //public Text ContentBody1;
    //public Text ContentBody2;
    private int dbuserid;

    private int formcoworkers = 1;
    private int formparents =0;
 //   private int formfriend = 0s;
    private int formpartner = 1;
    private int formalone =0;
    private int formwithnonsmokers =0;
    private int formwithsmokers = 0;

    private int coworkersID = 35;
    private int parentsID = 34;
    private int friendsID = 33;
    private int partnerID = 32;
    private int aloneID = 29;
    private int withnonsmokersID = 30;
    private int withsmokerIDs = 31;

    private string which;


    public void Start()
    {

        UserResults myEntries = new UserResults();
        // UserResults loadedPlayerData = userResults;

        myEntries.data[0].habitid = coworkersID;
        myEntries.data[0].Entry = formcoworkers;
        myEntries.data[0].which = "yesorno";
        string json = JsonUtility.ToJson(myEntries);


        Debug.Log("this is the json i created" + json);


    }  



    [Serializable]
    public class formResults
    {
       // public string fromJSONusername;
        public int habitid;
        public int Entry;
        public string which;
      //  public int value;
      //  public bool boolean;
    }

    [Serializable]
    public class UserResults
    {
        public List<formResults> data;
    }
}
