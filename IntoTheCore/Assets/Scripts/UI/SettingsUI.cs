using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUI : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject AmbientCheckmark;
    public GameObject PostProcessingCheckmark;

    public static bool PostProcessingEnabled = true;
    public static bool AmbientEnabled = true;
    public void ChangePostProcessing()
    {
        PostProcessingEnabled = !PostProcessingEnabled;
        PostProcessingCheckmark.SetActive(PostProcessingEnabled);
    }

    public void ChangeAmbient()
    {
        AmbientEnabled = !AmbientEnabled;
        AmbientCheckmark.SetActive(AmbientEnabled);
    }
    public void CloseUI()
    {
        gameObject.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }
    private void OnEnable()
    {
        AmbientCheckmark.SetActive(AmbientEnabled);
        PostProcessingCheckmark.SetActive(PostProcessingEnabled);
    }
}
