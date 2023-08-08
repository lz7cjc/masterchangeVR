using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

//this is used when coming from a different scene
public class showfilm : MonoBehaviour
{
    //moving camera
 //  public GameObject player;
   public Rigidbody Player;

    //targets
  
    public GameObject targetfilm;
    public GameObject targettip;
    public GameObject tipSection;
    public GameObject filmSection;

  //  private videocontrollerff videocontrollerff;
    public VideoPlayer VideoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component
                                    //public string SceneName;
    public VideoPlayer audioPlayer;
    public bool mousehover = false;
    public float counter = 0;
   // public GameObject Panel;

    public TMP_Text videoTime;
    public LightShaft.Scripts.YoutubePlayer youtubePlayer;
    private string videoURLPP;
    private string returntoscene;
    public GameObject mainCamera;
 

    private void Start()
    {
        //Player.useGravity = true;
        Debug.Log("^^^ start");
        
        tipSection.SetActive(false);
        filmSection.SetActive(true);
        playfilm();
    }


    
    private void playfilm()

    {
      

            Debug.Log("kkk6 playing film");
            Player.useGravity = false;
            PlayerPrefs.SetString("nextscene", "tip");
            
            RequestYoutubeStart();
            
          
        }
    public void RequestYoutubeStart()
    {
       
        videoURLPP = PlayerPrefs.GetString("VideoUrl");
          Debug.Log("in requestyoutubestart from start script " + videoURLPP);
        youtubePlayer = VideoPlayer.gameObject.GetComponent<LightShaft.Scripts.YoutubePlayer>();
        youtubePlayer.Play(videoURLPP);
    }
   
    
    public void tipping()
    {

        Debug.Log("in for tip");
        tipSection.SetActive(true);
        filmSection.SetActive(false);
        Player.useGravity = false;
        PlayerPrefs.SetString("nextscene", returntoscene);
        PlayerPrefs.DeleteKey("returntoscene");
        Debug.Log("^^^ tips");



        Player.transform.position = targettip.transform.position;
        Player.transform.SetParent(targettip.transform);

    }

}
