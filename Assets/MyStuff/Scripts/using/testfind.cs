using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testfind : MonoBehaviour
{
    private GameObject hudTop;

    void Start()
    {
        Transform hudTransform = GameObject.Find("HUDPrimary")?.transform;
        if (hudTransform != null)
        {
            hudTop = hudTransform.gameObject;
            Debug.Log("found hudtop" + hudTop.name);
        }
        else
        {
            Debug.LogError("HUDPrimary object not found in the scene!");
        }
    }

}
