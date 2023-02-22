using System.Collections;

using UnityEngine;
using UnityEngine.XR.Management;


public class startXR : MonoBehaviour
{
    public bool xrStart;
    public void Start()
    {
        if (xrStart)
        {
            StartCoroutine(StartXR());
        }
        else
        {
            StopXR();
        }
    }

    public IEnumerator StartXR()
    {
        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.Log("Starting XR... not null");
        }
        else
        {
            Debug.Log("Starting XR... null");
        }
            Debug.Log("Starting XR..." + XRGeneralSettings.Instance.Manager.activeLoader);
        XRGeneralSettings.Instance.Manager.StartSubsystems();
        //if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        //{
        //    Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
        //}
        //else
        //{
            
        //}
    }

    void StopXR()
    {
        Debug.Log("Stopping XR...");

        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR stopped completely.");
    }
}


    //Coroutine VRStart()
    //{
    //    return StartCoroutine(startVRRoutine());
    //    IEnumerator startVRRoutine()
    //    {
    //        // Add error handlers for both Instance and Manager
    //        var xrManager = XRGeneralSettings.Instance.Manager;
    //        if (!xrManager.isInitializationComplete)
    //            yield return xrManager.InitializeLoader();
    //        if (xrManager.activeLoader != null)
    //            xrManager.StartSubsystems();
    //        // Add else with error handling
    //    }
    //}
