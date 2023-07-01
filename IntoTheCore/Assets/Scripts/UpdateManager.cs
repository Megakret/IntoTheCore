using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    public static List<MonoCache> scripts = new List<MonoCache>();
    public void Update()
    {
        for (int i = 0; i < scripts.Count; i++)
        {
            scripts[i].OnUpdate();
        }
    }
}
