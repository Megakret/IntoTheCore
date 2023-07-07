using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GravityChangerObj : MonoBehaviour
{
    ConstantForce gravityForce;
    [SerializeField] float forceValue = -10f;
    private void Start()
    {
        gravityForce = GetComponent<ConstantForce>();
    }
    void OnEnable()
    {
        Events.GravityReverse += gravityReverse;
    }
    private void OnDisable()
    {
        Events.GravityReverse -= gravityReverse;
    }
    public void gravityReverse()
    {
        forceValue *= -1;
        gravityForce.force = new Vector3(0, forceValue ,0);
    }
}
