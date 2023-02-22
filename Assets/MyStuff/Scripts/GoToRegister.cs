using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class GoToRegister : MonoBehaviour
{
    //remote
    string posturl = "http://masterchange.today/php_scripts/register2.php";
    //local
    //  readonly string posturl = "http://localhost/php_scripts/register2.php";

    public InputField nameField;
    public InputField passwordField;
    public InputField dob;
    private string dobfromgame;
    private DateTime dobresult;
    public InputField fname;
    public InputField lname;
    public InputField email;
    public Toggle receiveEmail;
    public Toggle TsandCs;
    public Button acceptSubmissionButton;
    public Text errorMessage;
    private bool doesExistUserInfo;
    private int credsgiven;
    private int IntroScreen;
    private int SwitchtoVR;
    private int SkipLearningScreenInt;
    private int JCP;
    private int rirosEarnt;
    private int rirosBought;
    private int rirosSpent;
    private int rirosBalance;
    private int emailvalid;
    private int hospitalScene;
    private string returnToScene;
    
    public void Start()
    {
        loggedin();
        nameField.text = "fdhfhaddfah" + Time.realtimeSinceStartup;
        passwordField.text = "fagfadshgadfh";
        dob.text = "15/5/15";
        credsgiven = PlayerPrefs.GetInt("creditsGiven");
        rirosEarnt = PlayerPrefs.GetInt("rirosEarnt");
        rirosBought = PlayerPrefs.GetInt("rirosBought");
        rirosSpent = PlayerPrefs.GetInt("rirosSpent");
        Debug.Log("riros from PP = " + rirosEarnt);
        IntroScreen = PlayerPrefs.GetInt("IntroScreen");
        SwitchtoVR = PlayerPrefs.GetInt("SwitchtoVR");
        SkipLearningScreenInt = PlayerPrefs.GetInt("SkipLearningScreenInt");
        JCP = PlayerPrefs.GetInt("JCP");
        hospitalScene = PlayerPrefs.GetInt("hospitalScene");
        returnToScene = PlayerPrefs.GetString("returnToScene");
    }

    private void loggedin()
    {
        if (PlayerPrefs.HasKey("dbuserid"))
       
        { 
            SceneManager.LoadScene("dashboard");
        }
    }

    public void CallRegisterCoroutine()
    {
        StartCoroutine(Register());
        onChangeEmail();

    }


    public void onChangeEmail()
    {
        Debug.Log("opt in value" + receiveEmail.isOn);
    }

    IEnumerator Register()
    {
        Debug.Log("Register");

        WWWForm form = new WWWForm();
        form.AddField("c_username", nameField.text);
        form.AddField("c_password", passwordField.text);
        form.AddField("c_dob", dob.text);
        form.AddField("c_fname", fname.text);
        form.AddField("c_lname", lname.text);
        form.AddField("c_email", email.text);

        form.AddField("creditgiven", credsgiven);
        rirosEarnt = rirosEarnt + 5000;
        form.AddField("rirosEarnt", rirosEarnt);
        Debug.Log("rirosEarnt" + rirosEarnt);
        form.AddField("rirosBought", rirosBought);
        Debug.Log("rirosBought" + rirosBought);
        form.AddField("rirosSpent", rirosSpent);
        Debug.Log("rirosSpent" + rirosSpent);

        form.AddField("introscreen", IntroScreen);
        form.AddField("switchtoVr", SwitchtoVR);
        form.AddField("SkipLearning", SkipLearningScreenInt);
        form.AddField("JC", JCP);
        form.AddField("hospscene", hospitalScene);
        form.AddField("returnscene", returnToScene);


        if (receiveEmail.isOn)
        {
            form.AddField("c_optin", "1");
        }
        else
        {
            form.AddField("c_optin", "0");
        }


        UnityWebRequest www = UnityWebRequest.Post(posturl, form); // The file location for where my .php file is.
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            errorMessage.text = www.error;

        }
        else
        {
            string userString = www.downloadHandler.text;
            userString = userString.Trim('[', ']');
           
            Debug.Log(www.downloadHandler.text);
            Debug.Log("userID" + userString);
            File.WriteAllText(Application.persistentDataPath + "/userinfo.json", userString);
            //PlayerPrefs.SetInt("beeninworld", 0);

            // PlayerPrefs.SetInt("userid", int.Parse(loadedPlayerData.userid));
            Debug.Log("Form Upload Complete!");
            Debug.Log("the setting for userid in prefs is/: ");
            retrieveDataFromJson();
            SceneManager.LoadScene("dashboard");
        }
    }





    public void Validation()
    {
        emailvalid = email.text.IndexOf('@');
        Debug.Log("email value" + emailvalid);
        
        acceptSubmissionButton.interactable = nameField.text.Length >= 6 && passwordField.text.Length >= 8 && IsDateTime(dob.text) && emailvalid >=1;
    
    
    }

    public static bool IsDateTime(string txtDate)
    {
        System.DateTime tempDate;
        return System.DateTime.TryParse(txtDate, out tempDate);

    }
    //writing to playerprefs
    private void retrieveDataFromJson()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/userinfo.json");
        UserData loadedUserdata = JsonUtility.FromJson<UserData>(json);
        //set the variables for the form
        int userid = loadedUserdata.User_id;
        string Username = loadedUserdata.Username;
        string Fname = loadedUserdata.Fname;
       
        PlayerPrefs.SetInt("dbuserid", userid);
        PlayerPrefs.SetString("username", Username);
        PlayerPrefs.SetString("fname", Fname);
        // PlayerPrefs.SetInt("rirosEarnt", rirosEarnt);
        // Debug.Log("rirosEarnt 222" + rirosEarnt);

        //  Debug.Log("rirosSpent 222" + rirosSpent);

        // Debug.Log("rirosBought 222" + rirosBought);

        rirosBalance = rirosBought + rirosEarnt - rirosSpent;
        PlayerPrefs.SetInt("rirosBalance", rirosBalance);
        //Debug.Log("rirosBalance" + rirosBalance);

        // Debug.Log("userid" + userid);

    }
    private class UserData
    {
        public int User_id;
        public string Username;
        public string Fname;
        public int riros;

    }


}