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
  

    //old script
    void FixedUpdate()
    {
        if (mouseHover)
        {
          Debug.Log("hhh1 mouseHover speed is" + speedSet + " because I am moving:" + move);
            counter += Time.deltaTime;
            if (counter < Delay && !move)
            {
                Debug.Log("hhh2 counter < Delay && !move");
                counter += Time.deltaTime;
            }
            else if (counter >= Delay && !toggler)
            {
                Debug.Log("hhh3 counter >= Delay && !toggler");
                toggler = !toggler;
                move = !move;
                speedSet = speed;
             //   Debug.Log(" speedSet = speed" + speedSet);

            }
            else if (counter < DelayStop && move)

            {
                Debug.Log("hhh4 counter < DelayStop && move");
                //    Debug.Log("stopping counter < DelayStop && move");
                counter += Time.deltaTime;
            }
            else if (counter >= DelayStop && !toggler)
            {
                Debug.Log("hhh5 stop: counter >= DelayStop && !toggler");
                toggler = !toggler;
                move = !move;

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

            mouseHover = true;
    }
    public void OnMouseExit()
    {
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
        counter = 0;
    }
}

    

