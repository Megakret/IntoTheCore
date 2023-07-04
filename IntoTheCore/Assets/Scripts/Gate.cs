using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour, ITriggerable
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Enable()
    {
        animator.SetTrigger("Open");
    }
    public void Disable()
    {
        animator.SetTrigger("Close");
    }
}
