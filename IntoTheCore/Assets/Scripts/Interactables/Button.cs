using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Button : MonoBehaviour
{
    [Tooltip("Put gameobject with ITriggerable script here")]
    [SerializeField] private List<GameObject> objectsTriggerable;
    public Action buttonChanged;
    public bool isEnabled { get; private set; }
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
            isEnabled = true;
            buttonChanged?.Invoke();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ButtonHolder"))
        {

            DisableAll();
            isEnabled = false;
            buttonChanged?.Invoke();
        }
    }
    private void EnableAll()
    {
        if (triggerables.Count == 0)
        {
            return;
        }
        foreach (ITriggerable triggerable in triggerables)
        {
            triggerable.Enable();
        }
    }
    private void DisableAll()
    {
        if (triggerables.Count == 0)
        {
            return;
        }
        foreach (ITriggerable triggerable in triggerables)
        {
            triggerable.Disable();
        }
    }
}
