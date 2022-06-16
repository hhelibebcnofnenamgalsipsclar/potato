using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Linq;
using HtmlAgilityPack; 
using System.IO;
using UnityEngine.UI;

public class webscraper : MonoBehaviour
{
    // Start is called before the first frame update
    public Text x;
    void Start()
    {
        string c = null;

        HtmlWeb web = new HtmlWeb();
        //declares new HTML document with name document
        HtmlDocument document = new HtmlDocument();
        //loads the document with HTML code from wikipedia
        document = web.Load("https://en.wikipedia.org/wiki/Main_Page");
        //gets the news from the selected nodes
        var y = document.DocumentNode.SelectNodes("//*[@id=\"mp-itn\"]/ul/li[1]").First().InnerText;
        var d = document.DocumentNode.SelectNodes("//*[@id=\"mp-itn\"]/ul/li[2]").First().InnerText;
        var b = document.DocumentNode.SelectNodes("//*[@id=\"mp-itn\"]/ul/li[3]").First().InnerText;
        //if 4th article exists
        try
        {
            c = document.DocumentNode.SelectNodes("//*[@id=\"mp-itn\"]/ul/li[4]").First().InnerText;
        }
        catch
        {
            return;
        }

        //gets recent deaths from wikipedia
        string recentDeaths = document.DocumentNode.SelectNodes("//*[@id=\"mp-itn\"]/div[2]/div[2]/div/ul/li[1]").First().InnerText + ", " + document.DocumentNode.SelectNodes("//*[@id=\"mp-itn\"]/div[2]/div[2]/div/ul/li[2]").First().InnerText + ", " + document.DocumentNode.SelectNodes("//*[@id=\"mp-itn\"]/div[2]/div[2]/div/ul/li[1]").First().InnerText + ", " + document.DocumentNode.SelectNodes("//*[@id=\"mp-itn\"]/div[2]/div[2]/div/ul/li[3]").First().InnerText + ", " + document.DocumentNode.SelectNodes("//*[@id=\"mp-itn\"]/div[2]/div[2]/div/ul/li[4]").First().InnerText + ", " + document.DocumentNode.SelectNodes("//*[@id=\"mp-itn\"]/div[2]/div[2]/div/ul/li[5]").First().InnerText;



        //caesar's failed mess________________________________________________________________________________________________________________________________________________
        var Listhtml = document.DocumentNode.Descendants("div").Where(node => node.GetAttributeValue("id", "").Equals("mp-itn")).ToList();
        var ListItems = Listhtml[0].Descendants("ul").ToList();
        var node = ListItems[0];
        string result = node.WriteTo();
        result = result.Substring(result.IndexOf("<ul>"), result.IndexOf("</ul>") + 4);
        List<string> listOfLi = new List<string>();
        while (result.IndexOf("<li>") != -1)
        {
            string a = result.Substring(result.IndexOf("<li>"), result.IndexOf("</Li>") + 5);
            // Debug.Log(a);
            listOfLi.Add(a);
            result = result.Substring(result.IndexOf("</Li>") + 6);
        }


        //text updater
        x.text = y + "\n" + "\n" + d + "\n" + "\n" + b + "\n" + "\n" + c + "\n" + "\n" + "<b>Recent Deaths:</b>" + recentDeaths;



        // for testing only



    }







}
//*[@id="card-buttonpar-button"]/small