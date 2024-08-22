using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Globalization;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using DG.Tweening;

public class BagHPController : MonoBehaviour
{
    public Button bagButton;
    public GameObject bag;
    public Button[] itemButtons;
    public Text[] itemTexts;
    public Image[] itemImages;
    public Image HP_Boss;
    public Image HPBar_Boss;
    public Image HP_My;
    public Image HPBar_My;
    public GameObject shield;
    private int bagnum = 0;
    float HPScale_Boss = 1F;
    float HPScale_My = 1F;
    bool BossStart;
    List<string> itemList;

    // Start is called before the first frame update
    void Start()
    {
        bag.SetActive(false);
        shield.SetActive(false);
        bagnum = 0;
        for(int i = 0; i < itemButtons.Length; i++){
            itemButtons[i].interactable = false;
            itemTexts[i].text = "";
            itemImages[i].sprite = Resources.Load<Sprite>("透明");
        }
        
        HPScale_Boss = 1F;
        HPBar_Boss.fillAmount = HPScale_Boss;
        HP_Boss.DOFade(0, 0f);
        HPBar_Boss.DOFade(0, 0f);

        HPScale_My = 1F;
        HPBar_My.fillAmount = HPScale_My;
        HP_My.DOFade(0, 0f);
        HPBar_My.DOFade(0, 0f);
        
        BossStart = false;
        itemList = new List<string>();
    }
    void Dialogue(string[] arr)
    {
        string title = arr[0];
        string content = arr[1];
        string picture = arr[2];

        if (title == "【通知】" && picture != "")
        {   
            if (!itemList.Contains(picture))
            {
                itemButtons[bagnum].interactable = true;
                itemTexts[bagnum].text = picture;
                itemImages[bagnum++].sprite = Resources.Load<Sprite>("Item/" + picture);
                itemList.Add(picture);
            }
        }
        else if (title == "【BOSS 出現】")
        {
            HP_Boss.DOFade(1, 0f);
            HPBar_Boss.DOFade(1, 0f);
            HP_My.DOFade(1, 0f);
            HPBar_My.DOFade(1, 0f);

            BossStart = true;
        }
    }
    void ChooseItem(string[] arr)
    {
        if (HPScale_Boss <= 0 || bagnum == 0)
        {
            HP_Boss.DOFade(0, 0f);
            HPBar_Boss.DOFade(0, 0f);
            arr[0] = arr[1];
            arr[1] = "0";
            SendMessage("ChangePath", arr);
        }
    }
    void HPminusBoss(string[] arr)
    {
        HPScale_Boss -= Convert.ToSingle(arr[1]);
        HPBar_Boss.DOFillAmount(HPScale_Boss, 3f);
    }
    void HPminusMy(string[] arr)
    {
        HPScale_My -= Convert.ToSingle(arr[1]);
        HPBar_My.DOFillAmount(HPScale_My, 3f);
    }
    void Shield(string[] arr)
    {
        shield.SetActive(true);
    }
    public void PressBagButton()
    {
        bag.SetActive(!bag.activeSelf);
    }
    public void PressitemButton(int index)
    {
        if(BossStart){
            bag.SetActive(false);
            itemImages[index].DOFade(0.5f, 0);
            SendMessage("ChangePath", "/Option[@name='" + itemTexts[index].text + "']");
        }
    }
}
