using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gazequiz : MonoBehaviour

{
    public bool mousehover = false;
    public float Counter = 0;
    // public string Markername;
 //   public Text MyText = null;
    public GameObject intro;
    public GameObject quiz;
    public GameObject answer;
    public GameObject wrong;
    public GameObject right;

    private string stage;
   

    void Update()
    {
        //Debug.Log("counter level" + Counter);
        if (mousehover)
        {

            Counter += Time.deltaTime;



            if (Counter >= 3)

            {
                mousehover = false;
                Counter = 0;
                //put the action required here
                if (stage == "quiz")
                {
                    intro.SetActive(false);
                    quiz.SetActive(true);
                    answer.SetActive(false);
                }
                else if (stage == "answer")
                {
                    intro.SetActive(false);
                    quiz.SetActive(false);
                    answer.SetActive(true);
                    wrong.SetActive(false);
                    right.SetActive(true);
                }
                else if (stage == "wronganswer")
                {
                    intro.SetActive(false);
                    quiz.SetActive(false);
                    answer.SetActive(true);
                    wrong.SetActive(true);
                    right.SetActive(false);
                }

            }
        }
    }

    // mouse Enter event
    public void launchQuiz()
    {
        Debug.Log("setting look");
        // Markername = ObjectName;
        mousehover = true;
        stage = "quiz";

    }
    public void getcorrectanswer()
    {
        Debug.Log("setting look");
        // Markername = ObjectName;
        mousehover = true;
        stage = "answer";

    }
    public void getincorrectanswer()
    {
        Debug.Log("setting look");
        // Markername = ObjectName;
        mousehover = true;
        stage = "wronganswer";

    }

    // mouse Exit Event
    public void MouseExit()
    {
        Debug.Log("cancelling look");
        //  Markername = "";
        mousehover = false;
        Counter = 0;
    }



}
