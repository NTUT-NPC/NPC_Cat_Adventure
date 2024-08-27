using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogueController : MonoBehaviour
{   
    public Text dialogue;
    public Text narrator;

    IEnumerator Dialogue(string[] arr)
    {   
        string xmlTitle = arr[0];
        string xmlContent = arr[1];
        string xmlPicture = arr[2];

        float speed = xmlContent.Length * 0.01F; // adjust speed

        xmlContent = xmlContent.Replace(" ", "\u00A0");

        dialogue.text = narrator.text = "";

        Text targetText = (xmlTitle == "【旁白】" || xmlTitle == "【BOSS】") ? narrator : dialogue;
        targetText.DOText(xmlContent, speed).SetUpdate(true);

        yield return new WaitForSeconds(speed + 0.1f);

        SendMessageUpwards("NextStandby");
    }
}
