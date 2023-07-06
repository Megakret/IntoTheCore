using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuShake : MonoBehaviour
{
    Animator animator;
    [SerializeField] float ShakeCd;
    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(ShakeRoutine());
    }
    IEnumerator ShakeRoutine()
    {
        while (gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(ShakeCd);
            int shakeNum = Random.Range(1,4);
            animator.SetTrigger(shakeNum.ToString());
        }
        yield break;
        
    }
}
