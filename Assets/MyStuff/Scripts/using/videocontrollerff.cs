using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEditor;
using UnityEngine.Events;

public class videocontrollerff : MonoBehaviour

{
    public VideoPlayer VideoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component
                                    //public string SceneName;
    public VideoPlayer audioPlayer;
     public bool mousehover = false;
    public float counter = 0;
    public GameObject Panel;
    private bool pause;
    private bool play;
    private bool ff;
    private bool stop;
    private bool ffff;
    public Text videoTime;
   private int totalfilmlength;
    private showfilm showfilm;
    private LightShaft.Scripts.YoutubePlayer youtubePlayer;
    private string videoURLPP;
    public GameObject loadingAssets;
   



    void Update()
    {
        
        youtubePlayer = VideoPlayer.gameObject.GetComponent<LightShaft.Scripts.YoutubePlayer>();
        if (VideoPlayer.isPrepared)
        {
            loadingAssets.SetActive(false);
            totalfilmlength = System.Convert.ToInt32(VideoPlayer.length);

            var tFFormat = TimeSpan.FromSeconds(totalfilmlength);

            var vTFormat = TimeSpan.FromSeconds(VideoPlayer.time);
            videoTime.text = string.Format("{0:00}:{1:00}", vTFormat.TotalMinutes, vTFormat.Seconds) + "/" + string.Format("{0:00}:{1:00}", tFFormat.TotalMinutes, tFFormat.Seconds); ;



        }
        else
        {
            videoTime.text = "Getting video info";
            loadingAssets.SetActive(true);
        }

    
        if (mousehover)
        {
            counter += Time.deltaTime;
            if (counter >= 3)
            {
                mousehover = false;
                counter = 0;
                //onNewFrame();
                // onNewFrame(frameStamp.value);
                if (VideoPlayer.canSetPlaybackSpeed)
                {
                    Panel.gameObject.SetActive(true);
                    if (pause)
                    {
                        VideoPlayer.playbackSpeed = 0f;
                        audioPlayer.playbackSpeed = 0f;
                        Debug.Log("in pause mouseover");
                        pause = false;
                    }
                    else if (play)
                    {

                        VideoPlayer.playbackSpeed = 1f;
                        audioPlayer.playbackSpeed = 1f;
                        play = false;
                        //Debug.Log("in the play settings but");
                    }
                    else if (ff)
                    {

                        VideoPlayer.playbackSpeed = 2f;
                        audioPlayer.playbackSpeed = 2f;
                        ff = false;
                    }
                    else if (ffff)
                    {

                        VideoPlayer.playbackSpeed = 3f;
                        audioPlayer.playbackSpeed = 3f;
                        ffff = false;
                    }
                    else if (stop)
                    {
                        Debug.Log("in stop");
                          PlayerPrefs.SetString("nextscene", "tip");
                        youtubePlayer.Stop();
                        PlayerPrefs.DeleteKey("VideoUrl");
                        //added when split scene 24/12
                        //    SceneManager.LoadScene("everything");
                        showfilm = FindObjectOfType<showfilm>();
                        showfilm.tipping();
                        //SceneManager.LoadScene("videoVote");  
                        stop = false;
                  
                    }

                }
            }
        }
    }

    
    
    void LoadScene(VideoPlayer vp)
    {
       // SceneManager.LoadScene(vp);

        //4/1/2021
        //SceneManager.LoadScene("videovote");
        //Screen.orientation = ScreenOrientation.AutoRotation;
    }


    // mouse Enter event
    public void MouseHoverChangeScene()
    {
        //Debug.Log("setting walk");
        // Markername = ObjectName;
        mousehover = true;
        
    }
    public void onPause()
    {
        pause = true;
        Debug.Log("choose onPause");
        mousehover = true;
    }
    public void onFF()
    {
        pause = false;
        ff = true;
        Debug.Log("choose ff");
        mousehover = true;
    }
    public void onFFFF()
    {
        ffff = true;
        Debug.Log("choose onPause");
        mousehover = true;
    }

    public void onPlay()
    {
        play = true;
        mousehover = true;
        Debug.Log("choose onPlay");
    }

    public void onStop()
    {
        Debug.Log("choose onStop"); 
        stop = true;
        mousehover = true;
        
    }

    public void stopDirect()
    {
        Debug.Log("in stopDirect");
        PlayerPrefs.SetString("nextscene", "tip");
        youtubePlayer.Stop();
        PlayerPrefs.DeleteKey("VideoUrl");
        showfilm = FindObjectOfType<showfilm>();
        showfilm.tipping();
     
        stop = false;

    }


    // mouse Exit Event
    public void MouseExit()
    {
        //Debug.Log("cancelling walk");
        // Markername = "";
        mousehover = false;
        counter = 0;
        stop = false;
    
        pause = false;
      
        play = false;
}

}
