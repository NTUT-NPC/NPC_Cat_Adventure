using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleController : MonoBehaviour
{
    public Text title;
    
    void Dialogue(string[] arr)
    {
        string xmlTitle = arr[0];
        
        title.text = xmlTitle;

        if (xmlTitle == "【旁白】" || xmlTitle == "【BOSS】")
        {
            title.text = "";
        }
        if (xmlTitle == "【通知】")
        {
            title.DOColor(Color.yellow, 1);
        }
        else if (xmlTitle == "【成就】" || xmlTitle == "【BOSS 出現】")
        {
            title.DOColor(Color.red, 0);
        }
        else
        {
            title.DOColor(Color.white, 0);
        }
    }
}
