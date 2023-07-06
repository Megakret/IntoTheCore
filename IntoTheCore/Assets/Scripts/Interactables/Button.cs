using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Button : MonoBehaviour
{
    [Tooltip("Put gameobject with ITriggerable script here")]
    [SerializeField] private List<GameObject> objectsTriggerable;
    public Action<Button> buttonEnabled;
    public Action<Button> buttonDisabled;
    private List<ITriggerable> triggerables = new List<ITriggerable>();
    private void Start()
    {
        foreach (GameObject obj in objectsTriggerable)
        {
            triggerables.Add(obj.GetComponent<ITriggerable>());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ButtonHolder"))
        {
            EnableAll();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ButtonHolder"))
        {
            DisableAll();
        }
    }
    private void EnableAll()
    {
        foreach (ITriggerable triggerable in triggerables)
        {
            triggerable.Enable();
        }
    }
    private void DisableAll()
    {
        foreach (ITriggerable triggerable in triggerables)
        {
            triggerable.Disable();
        }
    }
}
