//using System.IO;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using UnityEngine.Networking;

//public class ReaDjAsONtEMpLATE : MonoBehaviour

//{
 

//    private void Start()
//    {
//        // File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
//        string json = File.ReadAllText(Application.dataPath + "/saveFile.json");

//        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
//        Cigsperday = loadedPlayerData.cigsPerDay.ToString();
//        YearsSmoked = loadedPlayerData.yearsSmoked.ToString();
//        QuitAttempts= loadedPlayerData.previousQuits.ToString();
//        NRT = loadedPlayerData.nrt;
//        Prequit = loadedPlayerData.prequit;
//        Quitting = loadedPlayerData.quitting;
//        NotStarted = loadedPlayerData.nodate;
//        TTFC = loadedPlayerData.ttfcless;

//        Debug.Log("111Cigsperday" + Cigsperday);
//        Debug.Log("111YearsSmoked" + YearsSmoked);
//        Debug.Log("QuitAttempts" + QuitAttempts);
//        Debug.Log("NRT" + NRT);
//        Debug.Log("Prequit" + Prequit);
//        Debug.Log("Quitting" + Quitting);
//        Debug.Log("NotStarted" + NotStarted);
//        Debug.Log("TTFC" + TTFC);

//    }


//    private class PlayerData
//    {
//        //Health factors
//        public bool ttfcless;
//        public bool ttfcmore;
//        public bool nrt;
//        public bool prequit;
//        public bool quitting;
//        public bool nodate;
//        public float cigsPerDay;
//        public float previousQuits;
//        public float yearsSmoked;

//        //progress
//        public bool learning;
//        public bool stacy;
//        public bool goodXray;
//        public bool badXray;
//        public bool goodCTscan;
//        public bool badCTscan;
//        public bool ctScan;

//        //scoring
//        public string badge;
//        public int score;
//        public string level;
//    }



//}
