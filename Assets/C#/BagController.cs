using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Globalization;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using DG.Tweening;

public class BagController : MonoBehaviour
{
    public Button bagButton;
    public GameObject bag;
    public Button[] itemButtons;
    public Text[] itemTexts;
    public Image[] itemImages;
    private int bagnum;

    // Start is called before the first frame update
    void Start()
    {
        bag.SetActive(false);
        bagnum = 0;
        for(int i = 0; i < itemButtons.Length; i++){
            itemButtons[i].interactable = false;
            itemTexts[i].text = "";
            itemImages[i].sprite = Resources.Load<Sprite>("透明");
        }
    }
    void Dialogue(string[] arr)
    {
        string title = arr[0];
        string content = arr[1];
        string picture = arr[2];

        if (title == "【通知】" && picture != "")
        {   
            itemButtons[bagnum].interactable = true;
            itemTexts[bagnum].text = picture;
            itemImages[bagnum++].sprite = Resources.Load<Sprite>("Item/" + picture);
        }
    }
    public void PressBagButton()
    {
        bag.SetActive(!bag.activeSelf);
    }
}
