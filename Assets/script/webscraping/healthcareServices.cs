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

public class teenServices : MonoBehaviour
{
    // Start is called before the first frame update
    public Text outtext;

    void Start()
    {

        string filename = "webpotato.json";
        HtmlWeb teenweb = new HtmlWeb();
        HtmlDocument teendocument = new HtmlDocument();
        teendocument = teenweb.Load("https://dpss.lacounty.gov/en/health/teens.html");
        var head = teendocument.DocumentNode.SelectNodes("//*[@id=\"jcr:content-root-contentbanner\"]/div/h1").First().InnerText;
        var des = teendocument.DocumentNode.SelectNodes("//*[@id=\"jcr:content-root-contentbanner\"]/div/p/text()").First().InnerText;
        var req = teendocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("id", "").Equals("root-leftColumn-card")).ToList();
        List<string> potato = new List<string>();
        List<string> cat = new List<string>();
        cat.Add("Health");
        cat.Add("Direct Cash Aid");
        cat.Add("Children/Minor");

        foreach (var items in req)
        {
            potato.Add(items.InnerText);
        }
        var entries = SaveManager.ReadFromJson<WebObject>(filename);
        entries.Add(new WebObject(head, des, cat, potato, null));
        SaveManager.SaveToJson<WebObject>(entries, filename);



        HtmlWeb agedblinddisabled = new HtmlWeb();
        HtmlDocument agedblinddisableddocument = new HtmlDocument();
        agedblinddisableddocument = agedblinddisabled.Load("https://dpss.lacounty.gov/en/health/senior-disabled/fpl.html");
        var head1 = agedblinddisableddocument.DocumentNode.SelectNodes("//*[@id=\"jcr:content-root-contentbanner\"]/div/h1").First().InnerText;
        var des1 = "Aged, Blind and Disabled Federal Poverty Level (FPL) Program serves persons 65 years and older or are blind or are disabled.";
        var req1 = agedblinddisableddocument.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("rte__content js-more-content")).ToList();
        List<string> potato1 = new List<string>();
        List<string> cat1 = new List<string>();
        cat1.Add("Direct Cash Aid");
        cat1.Add("Health");
        cat.Add("Children/Minor");

        foreach (var items in req1)
        {
            potato1.Add(items.InnerText);
        }
        var entries1 = SaveManager.ReadFromJson<WebObject>(filename);
        entries1.Add(new WebObject(head1, des1, cat1, potato1, null));
        SaveManager.SaveToJson<WebObject>(entries1, filename);


        HtmlWeb HCBS = new HtmlWeb();
        HtmlDocument HCBSDoc = new HtmlDocument();
        HCBSDoc = HCBS.Load("https://dpss.lacounty.gov/en/health/senior-disabled/hcbs.html");
        var head2 = HCBSDoc.DocumentNode.SelectNodes("//*[@id=\"jcr:content-root-contentbanner\"]/div/h1").First().InnerText;
        var des2 = HCBSDoc.DocumentNode.SelectNodes("//*[@id=\"root-responsivegrid-card\"]/div[1]/p").First().InnerText;
        var req2 = HCBSDoc.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("id", "").Equals("rte__content js-more-content")).ToList();
        List<string> potato2 = new List<string>();
        List<string> cat2 = new List<string>();
        cat1.Add("Direct Cash Aid");
        cat1.Add("Health");

        foreach (var items in req2)
        {
            potato2.Add(items.InnerText);
        }
        var entries2 = SaveManager.ReadFromJson<WebObject>(filename);
        entries2.Add(new WebObject(head2, des2, cat2, potato2, null));
        SaveManager.SaveToJson<WebObject>(entries2, filename);

        HtmlWeb MSP = new HtmlWeb();
        HtmlDocument MSPDoc = new HtmlDocument();
        MSPDoc = MSP.Load("https://dpss.lacounty.gov/en/health/savings.html");
        var head3 = MSPDoc.DocumentNode.SelectNodes("//*[@id=\"jcr:content-root-contentbanner\"]/div/h1").First().InnerText;
        var des3 = MSPDoc.DocumentNode.SelectNodes("//*[@id=\"jcr:content-root-contentbanner\"]/div/p").First().InnerText;
        var req3 = MSPDoc.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("rte__content js-more-content")).ToList();
        List<string> potato3 = new List<string>();
        List<string> cat3 = new List<string>();
        cat1.Add("Direct Cash Aid");
        cat1.Add("Health");

        foreach (var items in req3)
        {
            potato3.Add(items.InnerText);
        }
        var entries3 = SaveManager.ReadFromJson<WebObject>(filename);
        entries3.Add(new WebObject(head3, des3, cat3, potato3, null));
        SaveManager.SaveToJson<WebObject>(entries3, filename);


    }
}
