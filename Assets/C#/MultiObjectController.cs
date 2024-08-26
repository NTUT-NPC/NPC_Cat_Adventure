using System;
using System.Xml;
using UnityEngine;

public class MultiObjectController : MonoBehaviour
{
    bool nextStandby;
    string dramaPath;
    int dialogueProgress;

    // Start is called before the first frame update
    void Start()
    {
        nextStandby = false;
        dramaPath = "Chapter0"; //testChapter0
        dialogueProgress = 0;
        Next();
    }

    void JumpLinePath(int x)
    {   
        dialogueProgress += x;
    }

    void ChangePath(string path)
    {   
        dramaPath = dramaPath + path;
        dialogueProgress = 0;
        Next();
    }

    void ChangePath(string[] arr)
    {
        dramaPath = arr[0];
        if (arr[1] == "")
        {
            dialogueProgress = 0;
        }
        else
        {
            dialogueProgress = Int32.Parse(arr[1]);
        }
        
        Next();
    }

    int Next()
    {
        TextAsset xmlFile = Resources.Load<TextAsset>(PlayerPrefs.GetString("Drama"));
        XmlDocument document = new XmlDocument();
        document.LoadXml(xmlFile.text); // Xml讀取文件的方法
        nextStandby = false;

        XmlNodeList paragraph = document.SelectSingleNode("drama/"+ dramaPath).ChildNodes;
        if(dialogueProgress >= paragraph.Count)
        {
            return 0;
        }
        XmlElement element = (XmlElement)paragraph[dialogueProgress];
        Debug.Log(dialogueProgress);

        if(element.Name != "Changepath")
        {
            dialogueProgress += 1;
        }
        Debug.Log(element.Name);
        Debug.Log(element.GetAttribute("name"));
        Debug.Log(element.InnerText);
        Debug.Log(element.GetAttribute("pic"));
        
        string[] arr = {element.GetAttribute("name"), element.InnerText, element.GetAttribute("pic") };
        BroadcastMessage(element.Name, arr);
        
        if (element.Name == "Background" || 
            element.Name == "Option1" || element.Name == "Option2" ||
            element.Name == "Option3" || element.Name == "Option4" || 
            element.Name == "HPminusBoss" || element.Name == "HPminusMy" || 
            element.Name == "Achievement" || element.Name == "Shield" || 
            element.Name == "CheckHP")
        {
            nextStandby = true;
            SendMessage("GetPressed", "");
        }
        return 0;
    }

    void NextStandby()
    {
        nextStandby = true;
    }
    
    void GetPressed(string obj)
    {
        if (nextStandby)
        {
            Next();
        }
    }
}
