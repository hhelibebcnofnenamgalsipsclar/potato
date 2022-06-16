using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Linq;
using HtmlAgilityPack;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HtmlWeb Calworkweb = new HtmlWeb();
        //declares new HTML document with name document
        HtmlDocument Calworkdocument = new HtmlDocument();
        //loads the document with HTML code from Calwork section of cash assistance
        Calworkdocument = Calworkweb.Load("https://dpss.lacounty.gov/en/food.html");
        var head = Calworkdocument.DocumentNode.SelectNodes("//*[@id=\"jcr:content-root-contentbanner\"]/div/h1").First().InnerText;
        var des = Calworkdocument.DocumentNode.SelectNodes("//*[@id=\"jcr:content-root-contentbanner\"]/div/p").First().InnerText;
        var req = Calworkdocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("rte__content js-more-content")).ToList();

        List<string> potato = new List<string>();
        foreach (var items in req)
        {
            potato.Add(items.InnerText);
            Debug.Log(items);
        }
    }

}
