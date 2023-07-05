using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [Tooltip("Put gameobject with ITriggerable script here")]
    [SerializeField] private List<GameObject> objectsTriggerable;
    private List<ITriggerable> triggerables = new List<ITriggerable>();
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject helpCanvas; // Канвас, отображающий кнопку взаимодействия
    [SerializeField] private float interactCd;
    private bool isActive = false;
    private bool canActivate = true;

    private void Start()
    {
        foreach (GameObject obj in objectsTriggerable)
        {
            triggerables.Add(obj.GetComponent<ITriggerable>());
        }
    }

    public void Interacted()
    {
        if (!canActivate)
        {
            return;
        }

        isActive = !isActive;
        if (isActive)
        {
            EnableAll();
            animator.SetTrigger("PullDown");
        }
        else
        {
            DisableAll();
            animator.SetTrigger("PullUp");
        }
        StartCoroutine(Cooldown());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            helpCanvas.SetActive(true);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            helpCanvas.SetActive(false);
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
    IEnumerator Cooldown()
    {
        canActivate = false;
        yield return new WaitForSeconds(interactCd);
        canActivate = true;
    }

}
