 //basic stop start move item when the target is already sitting within the object

using UnityEngine;

public class floorceilingmove : MonoBehaviour
{
    public bool loop = false;
    public bool mouseHover = false;
    private bool move = false;
    private bool toggler = false;
    private float counter = 0;
    public float speed;
    private float speedSet;
    private string status;
    public float Delay;
   public float DelayStop;
    private bool turnOn = false;
    public Rigidbody player;


    public SpriteRenderer spriterenderer;
    public Sprite sprite;
    public Sprite spriteHover;
    public Sprite spriteSelect;

    //old script
    void FixedUpdate()
    {
        if (mouseHover)
        {
          Debug.Log("hhh1 mouseHover speed is" + speedSet + " because I am moving:" + move);
            counter += Time.deltaTime;
            //waiting to hit threshold to trigger walking
            if (counter < Delay && !move)
            {
                Debug.Log("hhh1");
                counter += Time.deltaTime;
                spriterenderer.sprite = spriteHover;
            }

            //walking triggered
            else if (counter >= Delay && !toggler)
            {
                Debug.Log("hhh2");
                toggler = !toggler;
                move = !move;
                speedSet = speed;
                spriterenderer.sprite = spriteSelect;
                //   Debug.Log(" speedSet = speed" + speedSet);

            }
            //already moving?
            else if (counter < DelayStop && move)

            {
                Debug.Log("hhh3");
                //    Debug.Log("stopping counter < DelayStop && move");
                counter += Time.deltaTime;
                spriterenderer.sprite = spriteSelect;

            }
            else if (counter >= DelayStop && !toggler)
            {
                Debug.Log("hhh4");
                toggler = !toggler;
                move = !move;
                spriterenderer.sprite = sprite;
                speedSet = 0;
               
            }
        }
        if (speedSet > 0)
        {
            LetsGo();
        }
    }


    

    // mouse Enter event
    public void OnMouseEnter()
    {
        Debug.Log("inmouseneter floorceiling hhh" + toggler);
        spriterenderer.sprite = spriteHover;
        mouseHover = true;
         
    }
    public void OnMouseExit()
    {
        if (!toggler)
        {
            spriterenderer.sprite = sprite;
        }
        mouseHover = false;
        toggler = false;
        counter = 0;
    }
    public void LetsGo()
    {
   //Debug.Log("in letsgo speed is  " + speedSet + mouseHover + move);

            player.MovePosition(transform.position + Camera.main.transform.forward * speedSet * Time.deltaTime);
       
     }
    public void stopTheCamera()
    {
        speedSet = 0;
          // Debug.Log("in letsgo speed is wwww  " + speedSet + mouseHover + move);
     player.MovePosition(transform.position + Camera.main.transform.forward * 0 * Time.deltaTime);
        toggler = false;
       
        mouseHover = false;
       
        counter = 0;
    }
}

    

