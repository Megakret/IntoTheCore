using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUI : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject AmbientCheckmark;
    public GameObject PostProcessingCheckmark;

    public static bool PostProcessingEnabled;
    public static bool AmbientEnabled;
    public void ChangePostProcessing()
    {
        PostProcessingEnabled = !PostProcessingEnabled;
    }

    public void ChangeAmbient()
    {
        AmbientEnabled = !AmbientEnabled;
    }
    public void CloseUI()
    {
        gameObject.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }
}
