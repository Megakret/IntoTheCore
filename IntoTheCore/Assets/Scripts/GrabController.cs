using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoCache
{
    [SerializeField] Transform camTransform;
    
    [SerializeField] float grabDistance = 5f;
    [SerializeField] float helpRayDistance; // длина луча для проверки на препятствие перед коробкой
    [SerializeField] LayerMask HelpLayerMask; // слои для вспомогательного луча, который находит препятствие между игроком и объектом
    [Header("Grabbing")]
    [SerializeField] LayerMask WhatIsGrabbable;
    [SerializeField] float ForceMultiplier;
    [SerializeField] float maxThrowSpeed;
    

    private Transform grabbedTransform; //взятый объект
    private float savedDistance;
    private Rigidbody grabbedRb;
    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            grabbedTransform = RaycastGet(); //получение объекта, который мы хотим взять
            if (grabbedTransform)
            {
                grabbedRb = grabbedTransform.GetComponent<Rigidbody>();
                grabbedRb.useGravity = false;
                savedDistance = (transform.position - grabbedTransform.position).magnitude;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)) //отпускание объекта
        {
            if (grabbedRb)
            {
                grabbedRb.useGravity = true;
                grabbedRb.velocity = Vector3.ClampMagnitude(grabbedRb.velocity, maxThrowSpeed);
            }
            
            grabbedTransform = null;
            grabbedRb = null;
        }
    }
    private Transform RaycastGet()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, camTransform.forward, out hit, grabDistance, WhatIsGrabbable)) // рейкаст из центра камеры
        {
            GameObject obj = hit.collider.gameObject;
            return obj.transform;
            
        }
        return null; // Если объекта, который мы можем взять нет на пути, то мы ничего не берем.
    }

    private void FixedUpdate() // Удержание объекта перед камерой
    {
        if(grabbedTransform == null)
        {
            return;
        }

        Vector3 holdPoint = camTransform.position + camTransform.forward * savedDistance; // точка куда будет перемещаться объект
        Vector3 forceVector = holdPoint - grabbedTransform.position; 
        grabbedRb.velocity = forceVector * ForceMultiplier;
        
          
    }
}
