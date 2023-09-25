using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteUserId : MonoBehaviour
{
    // Start is called before the first frame update
   public void logoff()

    {
        PlayerPrefs.DeleteAll();

    }
}
