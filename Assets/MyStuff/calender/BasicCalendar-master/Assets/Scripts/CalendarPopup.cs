using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Globalization;

public class CalendarPopup : MonoBehaviour
{

    public GameObject[] dayLabels;         //Holds 42 labels
    public string[] months;             //Holds the months
    public Text headerLabel;         //The label used to show the Month
    public GameObject dayLabel;
    public GameObject calendar;

    [SerializeField]
    private int monthCounter = DateTime.Now.Month - 1;
    [SerializeField]
    private int yearCounter = 0;

    [SerializeField]
    private DateTime iMonth;
    [SerializeField]
    private DateTime curDisplay;
    public int numberOfToday;

    void Start()
    {
        CreateLabels();
        //Debug.Log("Monthcounter = " + monthCounter);
        CreateMonths();
        CreateCalendar();
        numberOfToday = (DateTime.Now.Day);
        //Debug.Log(numberOfToday);
    }

    /*Adds al the months to the Months Array and sets the current month
    in the header label*/
    void CreateMonths()
    {
        months = new string[12];
        iMonth = new DateTime(2000, 1, 1);

        for (int i = 0; i < 12; ++i)
        {
            iMonth = new DateTime(DateTime.Now.Year, i + 1, 1);
            months[i] = iMonth.ToString("MMMM");
        }
        iMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // The magical Line :)
        headerLabel.text = months[DateTime.Now.Month - 1] + " " + DateTime.Now.Year;
    }

    /*Sets the days to their correct labels*/
    void CreateCalendar()
    {
        curDisplay = iMonth;
        //Debug.Log(iMonth);
        while (curDisplay.Month == iMonth.Month)
        {
            dayLabels[curDisplay.Day - 1].SetActive(true);
            dayLabels[curDisplay.Day - 1].GetComponentInChildren<Text>().text = curDisplay.Day.ToString();
            curDisplay = curDisplay.AddDays(1);
            //Debug.Log(curDisplay);
        }
    }

    /// <summary>
    /// Instantiates the day labels and then deactivates them.
    /// </summary>
    void CreateLabels()
    {
        dayLabels = new GameObject[42];
        for(int i = 0; i < 42; i++)
        {
            //Debug.Log(i);
            dayLabels[i] = Instantiate(dayLabel, calendar.transform);
            dayLabels[i].SetActive(false);
        }

    }


    /*when right arrow clicked go to next month */
    public void NextMonth()
    {
        monthCounter++;
        if (monthCounter > 11)
        {
            monthCounter = 0;
            yearCounter++;
        }

        headerLabel.text = months[monthCounter] + " " + (DateTime.Now.Year + yearCounter);
        ClearLabels();
        iMonth = iMonth.AddMonths(1);
        CreateCalendar();
    }

    /*when left arrow clicked go to previous month */
    public void PreviousMonth()
    {
        monthCounter--;
        if (monthCounter < 0)
        {
            monthCounter = 11;
            yearCounter--;
        }

        headerLabel.text = months[monthCounter] + " " + (DateTime.Now.Year + yearCounter);
        ClearLabels();
        iMonth = iMonth.AddMonths(-1);
        CreateCalendar();
    }

    /*clears all the day labels*/
    void ClearLabels()
    {
        for (int x = 0; x < dayLabels.Length; x++)
        {
            dayLabels[x].GetComponentInChildren<Text>().text = null;
        }
    }
}
