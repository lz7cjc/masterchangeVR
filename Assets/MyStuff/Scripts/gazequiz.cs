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

    private justSetGetRiros justSetGetRiros;
    private string stage;
    private allquizquestions allquizquestions;
    private justSetGetRirosDynamic justSetGetRirosDynamic;
    private quizanswers quizanswers;

    private void Start()
    {
        intro.SetActive(true);
        quiz.SetActive(false);
        answer.SetActive(false);
        allquizquestions = FindObjectOfType<allquizquestions>();
        allquizquestions.CallRegisterCoroutine();
    }
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
                    intro.SetActive(true);
                    quiz.SetActive(false);
                    answer.SetActive(false);
                    allquizquestions = FindObjectOfType<allquizquestions>();
                    allquizquestions.CallRegisterCoroutine();
                }

                if (stage == "displayAnswers")
                {
                    intro.SetActive(false);
                    quiz.SetActive(true);
                    answer.SetActive(false);
                    justSetGetRirosDynamic = FindObjectOfType<justSetGetRirosDynamic>();
                    int quizPrice = PlayerPrefs.GetInt("quizPrice");
                    justSetGetRirosDynamic.toPayOut("Spent", quizPrice);
                    quizanswers = FindObjectOfType<quizanswers>();
                    quizanswers.CallRegisterCoroutine();

                }
                if (stage == "quiz")
                {
                    intro.SetActive(true);
                    quiz.SetActive(false);
                    answer.SetActive(false);
                }
                else if (stage == "answer")
                {
                    intro.SetActive(false);
                    quiz.SetActive(false);
                    answer.SetActive(true);
                    wrong.SetActive(false);
                    right.SetActive(true);
                    int quizPrize = PlayerPrefs.GetInt("quizPrize");
                    Debug.Log("quiz prize before calling function£££" + quizPrize);
                    justSetGetRirosDynamic = FindObjectOfType<justSetGetRirosDynamic>();
                    justSetGetRirosDynamic.toPayOut("Earnt", quizPrize);

                    //send questionid to the database
                    // set the answerCorrect to true
                    //send the user id 
                }
                else if (stage == "wronganswer")
                {
                    intro.SetActive(false);
                    quiz.SetActive(false);
                    answer.SetActive(true);
                    wrong.SetActive(true);
                    right.SetActive(false);
                    //send questionid to the database
                    // set the answerCorrect to false
                    //send the user id 
                }

            }
        }
    }

    // mouse Enter event
    public void getQuiz()
    {
        Debug.Log("setting look");
        // Markername = ObjectName;
        mousehover = true;
        stage = "quiz";

    }

    public void displayAnswers()
    {
        Debug.Log("setting look");
        // Markername = ObjectName;
        mousehover = true;
        stage = "displayAnswers";

        
    }
    public void getanswer(int answerID)
    {
        Debug.Log("setting look");
        // Markername = ObjectName;
        mousehover = true;
        if (answerID == PlayerPrefs.GetInt("correctAnswer"))
        {
            stage = "answer";
          }
       else
        {
            stage = "wronganswer";
        }

    }
    //public void getincorrectanswer()
    //{
    //    Debug.Log("setting look");
    //    // Markername = ObjectName;
    //    mousehover = true;
    //    stage = "wronganswer";

    //}

    // mouse Exit Event
    public void MouseExit()
    {
        Debug.Log("cancelling look");
        //  Markername = "";
        mousehover = false;
        Counter = 0;
    }



}
