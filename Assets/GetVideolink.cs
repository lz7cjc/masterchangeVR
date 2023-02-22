using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GetVideolink : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<VideoPlayer>().source = VideoSource.Url;
        GetComponent<VideoPlayer>().url = PlayerPrefs.GetString("VideoUrl");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
