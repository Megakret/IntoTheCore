using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float maxThrowSpeed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void HoldObject(Vector3 holdPoint, float ForceMultiplier)
    {
        Vector3 forceVector = holdPoint - transform.position;
        rb.velocity = forceVector * ForceMultiplier;
    }
    public void UnHoldObject()
    {
        rb.useGravity = true;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxThrowSpeed);
    }
}
