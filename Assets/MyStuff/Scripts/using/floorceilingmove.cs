 //basic stop start move item when the target is already sitting within the object

using UnityEngine;
using TMPro;
public class floorceilingmove : MonoBehaviour
{
    public bool loop = false;
    public bool mouseHover = false;
    private bool move = false;
    private bool toggler = false;
    private float counter = 0;
    private float speed;
    private float speedSet;
    private string status;
    public float Delay;
   public float DelayStop;
    private bool turnOn = false;
    public Rigidbody player;
    private float deltaSpeed;

    public SpriteRenderer spriterenderer;
    public Sprite sprite;
    public Sprite spriteHover;
    public Sprite spriteSelect;
    public TMP_Text speedvalue;

   private bool changeSpeed;

 //   public showHideHUDMove showHideHUDMove;

    //old script
    void FixedUpdate()
    {
        if (mouseHover)
        {
           
            //  Debug.Log("hhh1 mouseHover speed is" + speedSet + " because I am moving:" + move);
            counter += Time.deltaTime;
            //waiting to hit threshold to trigger walking
            if (counter < Delay && !move)
            {
        //        Debug.Log("hhh1");
                counter += Time.deltaTime;
                spriterenderer.sprite = spriteHover;
            }

            //////////////////////
            ///new code
            ///
            else if (counter >= Delay && !toggler && changeSpeed)
            {

                       Debug.Log("change speed section");
                toggler = !toggler;
                move = !move;
                speedSet = speedSet + deltaSpeed;
                //PlayerPrefs.SetInt("walkSpeed", ((int)speedSet));
                spriterenderer.sprite = spriteSelect;
                //   Debug.Log(" speedSet = speed" + speedSet);
                speedvalue.text = speedSet.ToString();
            }
            else if (counter >= Delay && !toggler && !changeSpeed)
            {

                //        Debug.Log("hhh2");
                toggler = !toggler;
                move = !move;
                speedSet = speed;
                //PlayerPrefs.SetInt("walkSpeed", ((int)speedSet));
                spriterenderer.sprite = spriteSelect;
                //   Debug.Log(" speedSet = speed" + speedSet);
                speedvalue.text = speedSet.ToString();
            }
            //already moving?
            else if (counter < DelayStop && move && !changeSpeed)

            {
                //       Debug.Log("hhh3");
                //    Debug.Log("stopping counter < DelayStop && move");
                counter += Time.deltaTime;
                spriterenderer.sprite = spriteSelect;

            }
            else if (counter >= DelayStop && !toggler && !changeSpeed)
            {
                //       Debug.Log("hhh4");
                toggler = !toggler;
                move = !move;
                spriterenderer.sprite = sprite;
                speedSet = 0;
                PlayerPrefs.SetInt("walkSpeed", ((int)speedSet));
            }
        }
        if (speedSet > 0)
        {
            spriterenderer.sprite = spriteSelect;
            LetsGo();
        }
    }





    /////////////
    ////
    /// old code
    ///
    //walking triggered
    //        else if (counter >= Delay && !toggler)
    //        {

    //            //        Debug.Log("hhh2");
    //            toggler = !toggler;
    //            move = !move;
    //            speedSet = speed;
    //            //PlayerPrefs.SetInt("walkSpeed", ((int)speedSet));
    //            spriterenderer.sprite = spriteSelect;
    //            //   Debug.Log(" speedSet = speed" + speedSet);
    //            speedvalue.text = speedSet.ToString();
    //        }
    //        //already moving?
    //        else if (counter < DelayStop && move)

    //        {
    //     //       Debug.Log("hhh3");
    //            //    Debug.Log("stopping counter < DelayStop && move");
    //            counter += Time.deltaTime;
    //            spriterenderer.sprite = spriteSelect;

    //        }
    //        else if (counter >= DelayStop && !toggler)
    //        {
    //     //       Debug.Log("hhh4");
    //            toggler = !toggler;
    //            move = !move;
    //            spriterenderer.sprite = sprite;
    //            speedSet = 0;
    //            PlayerPrefs.SetInt("walkSpeed", ((int)speedSet));
    //        }
    //    }
    //    if (speedSet > 0)
    //    {
    //        spriterenderer.sprite = spriteSelect;
    //        LetsGo();
    //    }
    //}




    // mouse Enter event
    public void OnMouseEnterStartWalk(float speed1)
    {
        //  Debug.Log("inmouseneter floorceiling hhh" + toggler);
        spriterenderer.sprite = spriteHover;
        mouseHover = true;
        
        Debug.Log("changeSpeed111" + changeSpeed);
        changeSpeed = false;
        speed = speed1;

    }
    public void OnMouseEnterChangeSpeed(float deltaSpeed1)
    {
        //  Debug.Log("inmouseneter floorceiling hhh" + toggler);
        spriterenderer.sprite = spriteHover;
        mouseHover = true;
        changeSpeed = true;
        Debug.Log("changeSpeed222" + changeSpeed);
        deltaSpeed = deltaSpeed1;

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

    

