using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour, ITriggerable
{
    public void Enable()
    {
        gameObject.SetActive(false);
    }
    public void Disable()
    {
        gameObject.SetActive(true);
    }
}
