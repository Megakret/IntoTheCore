using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    public static List<MonoCache> scripts = new List<MonoCache>();
    public static bool EnabledUpdate;
    public void Start()
    {
        EnabledUpdate = true;
    }
    public void Update()
    {
        for (int i = 0; i < scripts.Count; i++)
        {
            if (EnabledUpdate || !scripts[i].CanPause)
            {
                scripts[i].OnUpdate();
            }
            
        }
    }
    public static void PauseGame()
    {
        EnabledUpdate = false;
    }
    public static void ResumeGame()
    {
        EnabledUpdate = true;
    }
}
