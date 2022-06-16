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


public static class WebSaver
{

    public static void SaveChecker(List<WebObject> list1, string path, WebObject webObj)
    {
        try
        {
            string filename = Application.persistentDataPath + "/webpotato.json";
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            else
            {
                Debug.Log("File does not exist.");
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        SaveManager.SaveToJson<WebObject>(list1, path);
        // foreach (var item in list2)
        // {
        //     if (item.getHeader().Equals(webObj))
        //     {
        //         if (Enumerable.SequenceEqual(list1, list2))
        //         {
        //             Debug.Log("WebObject already exists");
        //         }
        //         else
        //         {
        //             SaveManager.SaveToJson<WebObject>(list1, path);
        //         }
        //     }
        //     else
        //     {

        //     }


        // }

    }
}
