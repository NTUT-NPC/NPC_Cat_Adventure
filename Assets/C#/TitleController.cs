using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleController : MonoBehaviour
{
    public Text title;
    
    void Dialogue(string[] arr)
    {
        string xmlTitle = arr[0];
        
        title.text = "";

        Color targetColor = xmlTitle switch
        {
            "【通知】" => Color.yellow,
            "【成就】" or "【BOSS 出現】" => Color.red,
            _ => Color.white
        };
        
        var speed = xmlTitle.Length * 0.05F; // adjust speed

        Sequence sequence = DOTween.Sequence();
        sequence.Append(title.DOText(xmlTitle, speed));
        sequence.Join(title.DOColor(targetColor, speed));
    }
}
