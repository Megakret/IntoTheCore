using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    ConstantForce constantGravity;
    Rigidbody rb;
    [SerializeField] private float maxThrowSpeed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        constantGravity = GetComponent<ConstantForce>();
    }
    public void HoldObject(Vector3 holdPoint, float ForceMultiplier)
    {
        Vector3 forceVector = holdPoint - transform.position;
        rb.velocity = forceVector * ForceMultiplier;
        constantGravity.enabled = false;
    }
    public void UnHoldObject()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxThrowSpeed);
        constantGravity.enabled = true;
    }
}
