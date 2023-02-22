using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class ManualXRControl : MonoBehaviour
{
    [Tooltip("Wait time in seconds before we start and stop XR.")]
    public float waitTime = 10.0f;

    void Start()
    {
        StartCoroutine(StartXR());
    }

    IEnumerator StartXR()
    {
        Debug.Log($"Waiting {waitTime}s till we start XR...");
        yield return new WaitForSecondsRealtime(waitTime);

        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();


        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
        }
        else
        {
            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.activeLoader.Start();

            Debug.Log($"Waiting {waitTime}s to stop XR...");
            yield return new WaitForSecondsRealtime(waitTime);

            StopXR();
        }
    }

    void StopXR()
    {
        Debug.Log("Stopping XR...");

        if (XRGeneralSettings.Instance.Manager.activeLoader != null)
        {
            XRGeneralSettings.Instance.Manager.activeLoader.Stop();
            XRGeneralSettings.Instance.Manager.activeLoader.Deinitialize();
            Debug.Log("XR stopped completely.");
        }
    }
}


