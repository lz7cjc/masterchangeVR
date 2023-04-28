using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEditor;
using UnityEngine.Events;
using TMPro;

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
    public TMP_Text videoTime;
   private int totalfilmlength;
    private showfilm showfilm;
    private LightShaft.Scripts.YoutubePlayer youtubePlayer;
    private string videoURLPP;
    public GameObject loadingAssets;

    public SpriteRenderer spriterendererPlay;
    public SpriteRenderer spriterendererPause;
    public SpriteRenderer spriterendererStop;
    public SpriteRenderer spriterendererFF;
    public SpriteRenderer spriterendererFFFF;
  //  public SpriteRenderer spriterendererRewindToZero;
  //  public SpriteRenderer spriterendererRewind30s;

    public Sprite spriteDefaultPause;
    public Sprite spriteHoverPause;

    public Sprite spriteDefaultStop;
    public Sprite spriteHoverStop;

    public Sprite spriteDefaultPlay;
    public Sprite spriteHoverPlay;

    public Sprite spriteDefaultFF;
    public Sprite spriteHoverFF;

    public Sprite spriteDefaultFFFF;
    public Sprite spriteHoverFFFF;

    public Sprite spriteRewindTo0;
    public Sprite spriteHoverRewindTo0;

    public Sprite spriteRewind30s;
    public Sprite spriteHoverRewind30s;

    public void Start()
    {

        Debug.Log("script starting");
    }

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
                        spriterendererPause.sprite = spriteHoverPause;
                    }
                    else if (play)
                    {

                        VideoPlayer.playbackSpeed = 1f;
                        audioPlayer.playbackSpeed = 1f;
                        play = false;
                        //Debug.Log("in the play settings but");
                        spriterendererPlay.sprite = spriteHoverPlay;
                    }
                    else if (ff)
                    {

                        VideoPlayer.playbackSpeed = 2f;
                        audioPlayer.playbackSpeed = 2f;
                        ff = false;
                        spriterendererFF.sprite = spriteHoverFF;
                    }
                    else if (ffff)
                    {

                        VideoPlayer.playbackSpeed = 3f;
                        audioPlayer.playbackSpeed = 3f;
                        ffff = false;
                        spriterendererFFFF.sprite = spriteHoverFFFF;
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
        ff = false;
        ffff = false;
        stop = false;
        play = false;

        Debug.Log("choose onPause");
        mousehover = true;
        spriterendererPause.sprite = spriteHoverPause;
    }
    public void onFF()
    {
        pause = false;
        ff = true;
        ffff = false;
        stop = false;
        play = false;
        Debug.Log("choose ff");
        mousehover = true;
        spriterendererFF.sprite = spriteHoverFF;
    }
    public void onFFFF()
    {
        ffff = true;
        stop = false;
        play = false;
        ff = false;
        pause = false;
        Debug.Log("choose onFFFF");
        mousehover = true;
        spriterendererFFFF.sprite = spriteHoverFFFF;
    }

    public void onPlay()
    {
        play = true;
        ffff = false;
        stop = false;
        ff = false;
        pause = false;
        mousehover = true;
        Debug.Log("choose onPlay");
        spriterendererPlay.sprite = spriteHoverPlay;
    }

    public void onStop()
    {
        Debug.Log("choose onStop"); 

        stop = true;
        play = false;
        ffff = false;
        ff = false;
        pause = false;
        mousehover = true;
        spriterendererStop.sprite = spriteHoverStop;

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
        spriterendererPlay.sprite = spriteDefaultPlay;
        spriterendererPause.sprite = spriteDefaultPause;
        spriterendererStop.sprite = spriteDefaultStop;
        spriterendererFF.sprite = spriteDefaultFF;
        spriterendererFFFF.sprite = spriteDefaultFFFF;
    }

}
