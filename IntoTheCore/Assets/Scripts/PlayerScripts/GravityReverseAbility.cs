using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityReverseAbility : MonoCache
{
    [SerializeField] private float reverseCd;
    private PlayerController playerController;
    private bool canReverse = true;
    private bool isReversed = false;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) & playerController.IsGrounded() & canReverse)
        {
            Events.GravityReverse?.Invoke();
            isReversed = !isReversed;
            playerController.ReverseGravity();
            Debug.Log("REVERSE");
            transform.Rotate(0,0,180);

            
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
