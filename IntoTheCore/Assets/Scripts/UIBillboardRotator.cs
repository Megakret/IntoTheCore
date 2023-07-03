using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillboardRotator : MonoCache
{
    Camera plrCamera;
    private void Start()
    {
        plrCamera = Camera.main;
    }
    public override void OnUpdate()
    {
        gameObject.transform.LookAt(plrCamera.transform);
    }
}
