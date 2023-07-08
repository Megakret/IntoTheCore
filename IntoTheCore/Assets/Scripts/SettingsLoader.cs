using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class SettingsLoader : MonoBehaviour
{
    public Camera cam;
    private void Start()
    {
        var camData = cam.GetUniversalAdditionalCameraData();
        camData.renderPostProcessing = SettingsUI.PostProcessingEnabled;

    }

}
