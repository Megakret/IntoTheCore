using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Subtitle : MonoBehaviour
{
    [SerializeField] TMP_Text _Text;
    [SerializeField] GameObject subtitleBack;
    public void WriteSubtitle(string text, int time)
    {
        _Text.text = text;
        subtitleBack.SetActive(true);
        StartCoroutine(TextStay(time));
    }
    IEnumerator TextStay(int time)
    {

        yield return new WaitForSeconds(time);
        subtitleBack.SetActive(false);
    }
}
