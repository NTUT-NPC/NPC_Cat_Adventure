using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class Save : MonoBehaviour
{   

    void Dialogue(string[] arr)
    {
        
        string title = arr[0];
        string content = arr[1];
        
        if (title == "�i�q���j")
        {
            TextAsset xmlFile = Resources.Load<TextAsset>("Save");
            XmlDocument document = new XmlDocument();
            document.LoadXml(xmlFile.text); // XmlŪ����󪺤�k;

            XmlNode node = document.SelectSingleNode("root");
            XmlElement item = document.CreateElement("Item");//�Ыطs���l�`�I
            item.SetAttribute("name", content);//�Ыطs�l�`�I�ݩʦW�M�ݩʭ�
            node.AppendChild(item);//�N�l�`�I���ӳЫض��ǡA�K�[��xml
            document.AppendChild(node);
        }
    }
}
