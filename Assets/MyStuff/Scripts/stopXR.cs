using System.Collections;

using UnityEngine;
using UnityEngine.XR.Management;


public class stopXR : MonoBehaviour
{

    void StopXR()
    {
        var xrManager = XRGeneralSettings.Instance.Manager;
        if (!xrManager.isInitializationComplete)
            return; // Safety check
        xrManager.StopSubsystems();
        xrManager.DeinitializeLoader();
    }
}
