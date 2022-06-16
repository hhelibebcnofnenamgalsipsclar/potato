using UnityEngine;
using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class ProgramDisplayer : MonoBehaviour
{
    // Start is called before the first frame update

    private Text potato1;
    public GameObject canvas1;

    void Start()
    {
        List<WebObject> potato2 = new List<WebObject>();
        potato2 = SaveManager.ReadFromJson<WebObject>("webpotato.json");
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        int vert = 400;
        foreach (var items in potato2)
        {
            vert -= 50;
            GameObject ParentGameObj = new GameObject();
            ParentGameObj.name = items.getHeader();
            ParentGameObj.transform.parent = canvas1.transform;
            ParentGameObj.AddComponent<Text>();
            potato1 = ParentGameObj.GetComponent<Text>();
            potato1.text = items.getHeader();
            potato1.font = arial;
            potato1.GetComponent<Text>().color = Color.black;
            RectTransform rectTransform;
            rectTransform = potato1.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, vert, 0);
            rectTransform.sizeDelta = new Vector2(600, 200);
        }
    }
}




