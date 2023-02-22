 //basic stop start move item when the target is already sitting within the object

using UnityEngine;

public class VRWalking : MonoBehaviour
{
    public bool loop = false;
    public bool mouseHover = false;
    private bool move = false, toggler = false;
    private float counter = 0;
    public float speedSet;
    public string statusMove;
    private string status;
    //public bool stopWalking;
    //public bool run;
    //public bool sprint;
    //private int speedFromEditor;
    private int posReset;
    public float Delay;

    public float DelayStop;
  //  public GameObject resetMarker;
    private Vector3 coordsMarker;
    private Vector3 hudPosition;
    private Vector3 playerPosition;
    private bool turnOn = false;
    public Rigidbody floor;
    public Rigidbody player;
    public Rigidbody hudsDown;
    public Rigidbody hudsUp;
    public Rigidbody playerMarker;

    // public GameObject maincamera;
    public void Start()
    {
        //set the coordinates for the player to return to
        coordsMarker = player.transform.position;
        Debug.Log("player coords for marker xxx" + coordsMarker);
        // hudMarker = huds.transform.position;
    }

    void Update()
    {
        Debug.Log("speedset = ");
        if (mouseHover)
        {
          
            Debug.Log("player coords for marker start" + coordsMarker + "position of player" + player.position);
            counter += Time.deltaTime;
            if (counter < Delay && !move)
            {
                counter += Time.deltaTime;
            }
            else if (counter >= Delay && !toggler)
            {
                toggler = !toggler;
                move = !move;
                //  speedSet = speedSetInEditor;

            }
            else if (counter < DelayStop && move)
            {
                counter += Time.deltaTime;
            }
            else if (counter >= DelayStop && !toggler)
            {
                toggler = !toggler;
                move = !move;

                speedSet = 0;

            }
        }
        if ((speedSet > 0)|| (posReset ==1))
        {
            //   speedSet = (float)speedFromEditor;
            Debug.Log("posreset call LetsGo " + posReset);
            LetsGo();
        }
    }

    // mouse Enter event



    //public void OnMouseExit()
    //{
    //    mouseHover = false;
    //    toggler = false;
    //    counter = 0;
    //}

    public void chosenState(string status)
    {
       // statusMove = status;
        Debug.Log("what am i doing" + statusMove);

        if (status == "walk")
        {
            speedSet = 0.005f;
            posReset = 0;
        }
        else if (status == "run")
        {
            speedSet = 0.005f;
            posReset = 0;
        }
        else if (status == "sprint")
        {
            speedSet = 0.005f;
            posReset = 0;
        }
        else if (status == "stop")
        {
            speedSet = 0;
            posReset = 0;
        }
        else if (status == "goback")
        {
          //  speedSet = 0;
            posReset = 1;
            Debug.Log("posreset number " + posReset);
        }
        mouseHover = true;
      //  OnMouseEnter();
    }
   

    public void LetsGo()
    {

        Debug.Log("posreset in LetsGo " + posReset);

        //reset position or start/stop
        if (posReset == 1)
        {
            speedSet = 0;
            Debug.Log("posreset ");
            Debug.Log("speed is  " + speedSet);
            player.position = coordsMarker;
            //move hud relative to the player
            playerPosition = player.position;
            //new for 2 huds
            hudsDown.position = new Vector3(playerPosition.x + 0.6207275f, playerPosition.y - 5.377f, playerPosition.z+ 0.4719771f);
            hudsUp.position = new Vector3(playerPosition.x, playerPosition.y + 3f, playerPosition.z);
        }
        else if (posReset == 0)
        {
            Debug.Log("speed is  " + speedSet);

            player.MovePosition(transform.position + Camera.main.transform.forward * speedSet * Time.deltaTime);

            playerPosition = player.position;
            //move hud relative to the player
            //new for two huds
            hudsDown.position = new Vector3(playerPosition.x + 0.6207275f, playerPosition.y - 5.377f, playerPosition.z + 0.4719771f);
            hudsUp.position = new Vector3(playerPosition.x, playerPosition.y + 3f, playerPosition.z);
            //   huds.rotation = ;
            //  hudPosition = playerPosition - Vector3(0f,5f,0f);
            // hudPosition = huds.position;

            Debug.Log("player position is xxx: " + playerPosition + "huds position is " + hudPosition);
   
        }
    }
}
    

