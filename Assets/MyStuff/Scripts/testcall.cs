using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcall : MonoBehaviour
{
    private testdestination testdestination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public void senditbaby()
    {
        testdestination = FindObjectOfType<testdestination>();
        testdestination.writeitbaby();

    }
}
