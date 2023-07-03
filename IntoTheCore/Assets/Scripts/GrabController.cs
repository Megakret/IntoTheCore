using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoCache
{
    [SerializeField] Transform camTransform;
    
    [SerializeField] float grabDistance = 5f;
    [Header("Grabbing")]
    [SerializeField] float ForceMultiplier;
   

    private Transform grabbedTransform; //������ ������
    private float savedDistance;
    private GrabbableObject grabbed;
    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            grabbedTransform = RaycastGet(); //��������� �������, ������� �� ����� �����
            if (grabbedTransform)
            {
                savedDistance = (transform.position - grabbedTransform.position).magnitude;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)) //���������� �������
        {
            grabbedTransform = null;
            if(grabbed != null)
            {
                grabbed.UnHoldObject();
                grabbed = null;
            }
            
            

        }
    }
    private Transform RaycastGet()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, camTransform.forward, out hit, grabDistance)) // ������� �� ������ ������
        {
            
            GameObject obj = hit.collider.gameObject;
            if (obj.TryGetComponent(out grabbed))
            {
                return obj.transform;
            }
            
            
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
        grabbed.HoldObject(holdPoint, ForceMultiplier);
        
          
    }
}
