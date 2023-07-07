using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MultiButton : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("Put gameobject with ITriggerable script here")]
    [SerializeField] private List<GameObject> objectsTriggerable;
    [SerializeField] private List<Button> buttons; // количество требуемых активированных интеракторов
    private List<ITriggerable> triggerables = new List<ITriggerable>();
    private bool isEnabled;

    void Start()
    {
        foreach (GameObject obj in objectsTriggerable)
        {
            triggerables.Add(obj.GetComponent<ITriggerable>());
        }
        foreach (Button button in buttons)
        {
            button.buttonChanged = Triggered;
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
    private bool CheckButtons()
    {
        int count = 0;
        foreach (Button button in buttons)
        {
            if (button.isEnabled)
            {
                count++;
            }
        }
        return count == buttons.Count;
    }
    public void Triggered()
    {
        if (CheckButtons())
        {
            EnableAll();
            isEnabled = true;
            Debug.Log("Enable");
        }
        else if(isEnabled)
        {
            DisableAll();
            isEnabled = false;
            Debug.Log("Disabled");
        }
    }

}
