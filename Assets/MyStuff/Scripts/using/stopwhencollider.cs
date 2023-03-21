using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopwhencollider : MonoBehaviour
{
    // Start is called before the first frame update
    private floorceilingmove floorceilingmove;

    private void OnTriggerEnter(Collider other)
    {
        floorceilingmove = FindObjectOfType<floorceilingmove>();
        floorceilingmove.stopTheCamera();

    }
    
}
