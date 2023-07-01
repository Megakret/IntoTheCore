using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoCache
{
    [SerializeField] Transform camTransform;
    
    [SerializeField] float grabDistance = 5f;
    [SerializeField] float helpRayDistance; // ����� ���� ��� �������� �� ����������� ����� ��������
    [SerializeField] LayerMask HelpLayerMask; // ���� ��� ���������������� ����, ������� ������� ����������� ����� ������� � ��������
    [Header("Grabbing")]
    [SerializeField] LayerMask WhatIsGrabbable;
    [SerializeField] float ForceMultiplier;
    [SerializeField] float maxThrowSpeed;
    

    private Transform grabbedTransform; //������ ������
    private float savedDistance;
    private Rigidbody grabbedRb;
    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            grabbedTransform = RaycastGet(); //��������� �������, ������� �� ����� �����
            if (grabbedTransform)
            {
                grabbedRb = grabbedTransform.GetComponent<Rigidbody>();
                grabbedRb.useGravity = false;
                savedDistance = (transform.position - grabbedTransform.position).magnitude;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)) //���������� �������
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
        if (Physics.Raycast(transform.position, camTransform.forward, out hit, grabDistance, WhatIsGrabbable)) // ������� �� ������ ������
        {
            GameObject obj = hit.collider.gameObject;
            return obj.transform;
            
        }
        return null; // ���� �������, ������� �� ����� ����� ��� �� ����, �� �� ������ �� �����.
    }

    private void FixedUpdate() // ��������� ������� ����� �������
    {
        if(grabbedTransform == null)
        {
            return;
        }

        Vector3 holdPoint = camTransform.position + camTransform.forward * savedDistance; // ����� ���� ����� ������������ ������
        Vector3 forceVector = holdPoint - grabbedTransform.position; 
        grabbedRb.velocity = forceVector * ForceMultiplier;
        
          
    }
}
