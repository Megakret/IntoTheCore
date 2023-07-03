using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoCache
{
    [SerializeField] private KeyCode InteractKey;
    private Lever currentLever;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            currentLever = other.gameObject.GetComponent<Lever>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            currentLever = null;
        }
    }
    public override void OnUpdate()
    {
        if(currentLever != null && Input.GetKeyDown(InteractKey))
        {
            currentLever.Interacted();
        }
    }
}
