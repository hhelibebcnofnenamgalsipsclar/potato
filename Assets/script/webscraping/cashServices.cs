using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Linq;
using HtmlAgilityPack;
using System.IO;
using UnityEngine.UI;
using System;
using TMPro;

public class cashServices : MonoBehaviour
{
    // Start is called before the first frame update
    public Text outtext;
    public Text test;
    string filename = "webpotato.json";
    void Start()
    {


        HtmlWeb Calworkweb = new HtmlWeb();
        //declares new HTML document with name document
        HtmlDocument Calworkdocument = new HtmlDocument();
        //loads the document with HTML code from Calwork section of cash assistance
        Calworkdocument = Calworkweb.Load("https://dpss.lacounty.gov/en/cash/calworks.html");
        var head = Calworkdocument.DocumentNode.SelectNodes("//*[@id=\"jcr:content-root-contentbanner\"]/div/h1").First().InnerText;
        var des = Calworkdocument.DocumentNode.SelectNodes("//*[@id=\"jcr:content-root-contentbanner\"]/div/p").First().InnerText;
        var req = Calworkdocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("rte__content js-more-content")).ToList();
        List<string> cat = new List<string>();
        cat.Add("Direct cash aid");
        cat.Add("Job");
        cat.Add("Children/Minor");

        List<string> potato = new List<string>();
        foreach (var items in req)
        {
            potato.Add(items.InnerText);
            outtext.text += items.InnerText + "\n";
        }
        List<WebObject> entries = new List<WebObject>();
        entries = SaveManager.ReadFromJson<WebObject>(filename);
        entries.Add(new WebObject(head, des, cat, potato, "potato"));
        SaveManager.SaveToJson<WebObject>(entries, filename);



        // general relief in cash assistance
        HtmlWeb GR = new HtmlWeb();
        HtmlDocument GRDoc = new HtmlDocument();
        GRDoc = GR.Load("https://dpss.lacounty.gov/en/cash/gr.html");
        var head1 = GRDoc.DocumentNode.SelectNodes("//*[@id=\"jcr:content-root-contentbanner\"]/div/h1").First().InnerText;
        var des1 = GRDoc.DocumentNode.SelectNodes("//*[@id=\"jcr:content-root-contentbanner\"]/div/p").First().InnerText;
        var req1 = GRDoc.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("id", "").Equals("card-buttonpar-text")).ToList();
        List<string> potato1 = new List<string>();
        List<string> cat1 = new List<string>();
        cat1.Add("Direct cash aid");
        cat1.Add("Children/Minor");
        foreach (var items in req1)
        {
            potato1.Add(items.InnerText);
        }
        // List<WebObject> entries1 = new List<WebObject>();
        // entries1 = SaveManager.ReadFromJson<WebObject>(filename);
        // entries1.Add(new WebObject(head1, des1, cat1, potato1, null));
        // SaveManager.SaveToJson<WebObject>(entries1, filename);



        //refugee cash assistance
        HtmlWeb RCA = new HtmlWeb();
        HtmlDocument RCADoc = new HtmlDocument();
        RCADoc = RCA.Load("https://dpss.lacounty.gov/en/cash/rca.html");
        var head2 = RCADoc.DocumentNode.SelectNodes("//*[@id=\"jcr:content-root-contentbanner\"]/div/h1").First().InnerText;
        var des2 = RCADoc.DocumentNode.SelectNodes("//*[@id=\"jcr:content-root-contentbanner\"]/div/p").First().InnerText;
        var req2 = RCADoc.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("rte__content js-more-content")).ToList();
        List<string> potato2 = new List<string>();
        List<string> cat2 = new List<string>();
        cat2.Add("Direct cash aid");
        cat2.Add("Food");
        cat2.Add("Refugee/Migrant");
        cat2.Add("Health");

        foreach (var items in req2)
        {
            potato2.Add(items.InnerText);
        }
        // List<WebObject> entries2 = new List<WebObject>();
        // entries2 = SaveManager.ReadFromJson<WebObject>(filename);
        // entries2.Add(new WebObject(head, des, cat, potato, "potato"));
        // entries2.Add(new WebObject(head1, des1, cat1, potato1, null));
        // entries2.Add(new WebObject(head2, des2, cat2, potato2, null));
        // SaveManager.SaveToJson<WebObject>(entries2, filename);

    }

    // Update is called once per frame
}
