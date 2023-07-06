using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoCache : MonoBehaviour
{
    public bool CanPause = true;
    private void OnEnable()
    {
        UpdateManager.scripts.Add(this);
    }
    private void OnDisable()
    {
        UpdateManager.scripts.Remove(this);
    }
    private void OnDestroy()
    {
        UpdateManager.scripts.Remove(this);
    }
    public virtual void OnUpdate()
    {

    }

}
