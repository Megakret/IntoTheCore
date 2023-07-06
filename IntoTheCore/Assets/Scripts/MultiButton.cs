using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MultiButton : MonoBehaviour, ITriggerable
{
    // Start is called before the first frame update
    [Tooltip("Put gameobject with ITriggerable script here")]
    [SerializeField] private List<GameObject> objectsTriggerable;
    [SerializeField] private int maxInteractors; // количество требуемых активированных интеракторов
    private List<ITriggerable> triggerables = new List<ITriggerable>();
    private int buttonsActivated; //количество активированных интеракторов на данный момент

    void Start()
    {
        foreach (GameObject obj in objectsTriggerable)
        {
            triggerables.Add(obj.GetComponent<ITriggerable>());
        }
    }
    private void OnDisable()
    {
        triggerables.Clear();
    }
    // Update is called once per frame
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

    public void Enable()
    {
        buttonsActivated++;
        if (buttonsActivated == maxInteractors)
        {
            EnableAll();
        }
    }

    public void Disable()
    {
        buttonsActivated--;
        if (buttonsActivated < maxInteractors)
        {
            DisableAll();
        }
    }
}
