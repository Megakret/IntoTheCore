using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIScript : MonoBehaviour
{
    GameObject SettingsCanvas;
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }
    public void AppearSettings()
    {
        gameObject.SetActive(false);
        SettingsCanvas.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
