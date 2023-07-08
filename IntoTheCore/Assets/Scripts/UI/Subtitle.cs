using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Subtitle : MonoBehaviour
{
    [SerializeField] TMP_Text _Text;
    public void WriteSubtitle(string text, int time)
    {
        _Text.text = text;
        gameObject.SetActive(true);
        StartCoroutine(TextStay(time));
    }
    IEnumerator TextStay(int time)
    {

        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
