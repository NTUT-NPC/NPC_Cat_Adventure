using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class CharacterController : MonoBehaviour
{
    public Image character1;
    public Image character2;
    void Dialogue(string[] arr)
    {
        string title = arr[0];
        string content = arr[1];
        string picture = arr[2];
        string path = "Character/" + picture;
        if(picture == "clean")
        {
            character2.sprite = Resources.Load<Sprite>("�z��");
        }
        if (picture == "cleanAll")
        {
            character1.sprite = Resources.Load<Sprite>("�z��");
            character2.sprite = Resources.Load<Sprite>("�z��");
        }
        else if (title == "�i�q���j")
        {
            if (character2.sprite.name != "�z��")
            {
                character2.DOColor(Color.grey, 1).SetUpdate(true);
            }
            if (character1.sprite.name != "�z��")
            {
                character1.DOColor(Color.white, 1).SetUpdate(true);
            }
        }
        else if (title == "�i�ǥաj" || title == "�i�p N�j" || title == "�i�ڡj")
        {       
            if (!(picture == "" || picture == "clean"))
            {
                character1.sprite = Resources.Load<Sprite>(path);
            }
            if (character1.sprite.name != "�z��")
            {
                character1.DOColor(Color.white, 1).SetUpdate(true);
            }
            if (character2.sprite.name != "�z��")
            {
                character2.DOColor(Color.grey, 1);
            }
        }
        else
        {
            if (!(picture == "" || picture == "clean"))
            {   
                character2.sprite = Resources.Load<Sprite>(path);
            }
            if (character2.sprite.name != "�z��")
            {
                character2.DOColor(Color.white, 1).SetUpdate(true); 
            }
            if (character1.sprite.name != "�z��")
            {
                character1.DOColor(Color.grey, 1);
            }
        }
        //else if (title == "�iBOSS�j")
        //{
        //    if (!(picture == "" || picture == "clean"))
        //    {
        //        character1.sprite = Resources.Load<Sprite>(path);
        //    }
        //    if (character1.sprite.name != "�z��")
        //    {
        //        character1.DOColor(Color.white, 1).SetUpdate(true);
        //    }
        //    if (character2.sprite.name != "�z��")
        //   {
        //        character2.DOColor(Color.white, 1);
        //   }
        //}
    }
}