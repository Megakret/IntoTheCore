using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSubtitle : MonoBehaviour
{
    private bool Activated = false;
    public Subtitle subtitle;
    public string text;
    public int showTime;
    private void OnTriggerEnter(Collider other)
    {
        if (Activated)
        {
            return;
        }
        Activated = true;
        subtitle.WriteSubtitle(text, showTime);
    }
}
