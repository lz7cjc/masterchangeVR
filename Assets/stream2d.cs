using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Stream2d : MonoBehaviour
{
    public RawImage rawimage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVideo2d()
    {
        rawimage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
    }
}
