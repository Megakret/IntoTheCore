using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReverseAbility : MonoCache
{
    [SerializeField] private float reverseCd;
    private PlayerController playerController;
    private bool canReverse = true;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) & playerController.IsGrounded() & canReverse)
        {
            Events.GravityReverse?.Invoke();
            Debug.Log("REVERSE");
            StartCoroutine(CdCounter());
        }
    }
    IEnumerator CdCounter()
    {
        canReverse = false;
        yield return new WaitForSeconds(reverseCd);
        canReverse = true;
    }
}
