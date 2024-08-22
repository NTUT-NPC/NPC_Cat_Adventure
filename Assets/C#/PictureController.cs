using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Globalization;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using DG.Tweening;

public class PictureController : MonoBehaviour
{
    public Image background_Image;
    public Transform background_Transform;
    public Image mask;
    public Image item;
    public Image HP_Boss;
    public Image HPBar_Boss;
    public Image HP_My;
    public Image HPBar_My;
    public Text gameOverText;
    public Transform gameOver_Transform;
    float HPScale_Boss = 1F;
    float HPScale_My = 1F;

    Color customColor = new Color(0.98f, 0.948f, 0.744f, 1.0f);


    void Start()
    {
        HPScale_Boss = 1F;
        HPBar_Boss.fillAmount = HPScale_Boss;
        HP_Boss.DOFade(0, 0f);
        HPBar_Boss.DOFade(0, 0f);
        HPScale_My = 1F;
        HPBar_My.fillAmount = HPScale_My;
        HP_My.DOFade(0, 0f);
        HPBar_My.DOFade(0, 0f);
    }

    IEnumerator Background(string[] arr)
    {
        string picture = arr[2];

        if (arr[1] == "Before End")
        {
            yield return new WaitForSeconds(0.8f);
            background_Transform.DOScale(background_Transform.localScale * 5, 1f);
            mask.DOFade(1, 1f);
        }
        else if (arr[1] == "End")
        {   
            background_Transform.DOScale(background_Transform.localScale / 5, 0f);
            mask.DOFade(0, 2f);
        }
        else if (arr[1] == "Game Over")
        {
            gameOverText.DOFade(1, 0f);
            gameOver_Transform.DOMoveY(770, 1f, true);
            gameOver_Transform.DOScale(gameOver_Transform.localScale * 3, 1f);
        }
        else if (arr[1] != "Skip Animation")
        {
            background_Image.DOColor(Color.black, 0.5f);
            yield return new WaitForSeconds(0.5f);
        }

        if (!(arr[1] == "BeforeEnd" || arr[1] == "End"))
        {
            background_Image.sprite = Resources.Load<Sprite>("Background/" + picture);
            background_Image.DOColor(Color.white, 0.5f);
        }
        else if(arr[1] == "End")
        {
            background_Image.sprite = Resources.Load<Sprite>("Background/" + picture);
            background_Image.DOColor(Color.white, 0f);
        }
        
    }

    void Dialogue(string[] arr)
    {
        string title = arr[0];
        string content = arr[1];
        string picture = arr[2];

        if (title == "【通知】" && picture != "")
        {   
            item.sprite = Resources.Load<Sprite>("Item/" + picture);
        }
        else
        {
            item.sprite = Resources.Load<Sprite>("透明");
        }
    }
}