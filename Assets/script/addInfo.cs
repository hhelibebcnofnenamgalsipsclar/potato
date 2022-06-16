using UnityEngine;
using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class addInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Pass;
    public InputField password;
    public InputField SSID;
    public Text SSIDtext;
    public InputField phone;
    public Text phoneText;
    private string pass;
    private string ssid;
    private string phonetxt;
    private string potato1;
    private string potato2;
    private int potato3;
    private string potato4;

    private bool potato5 = false;
    private bool potato6 = false;

    public Text OutText;


    void Start()
    {
        SSIDtext.text = PlayerPrefs.GetString("SSID");
        Pass.text = PlayerPrefs.GetString("pass");
        phoneText.text = PlayerPrefs.GetString("phone");
    }

    public void AddInfo()
    {
        PlayerPrefs.SetString("SSID", SSIDtext.text);
        PlayerPrefs.SetString("pass", Pass.text);
        PlayerPrefs.SetString("phone", phoneText.text);
        potato1 = PlayerPrefs.GetString("SSID");
        potato2 = PlayerPrefs.GetString("pass");
        potato4 = PlayerPrefs.GetString("phone");
        Int32.TryParse(potato4, out potato3);


        List<SaveObject> potato = SaveManager.ReadFromJson<SaveObject>("potato.json");

        if (Login.currentUser.getPassword() == potato2)
        {
            OutText.text = "";
            SaveObject newUser = Login.currentUser;
            if (Login.currentUser.getSSIDbool() == true && potato1.Length == 9)
            {
                newUser.addSSID(potato1);
                newUser.setSSIDbool(false);
                potato.RemoveAt(Login.currentIndex);
                potato.Insert(Login.currentIndex, newUser);
                SaveManager.SaveToJson<SaveObject>(potato, "potato.json");
                potato5 = true;

            }

            if (potato4.Length != 0)
            {
                newUser.changePhone(potato3);
                potato6 = true;
            }
            if (potato5 == true)
            {
                OutText.text += "SSID added";
            }
            if (potato6 == true)
            {
                OutText.text += " Phone changed";
            }
            if (potato5 == false && potato6 == false)
            {
                OutText.text = "nothing changed";
            }
        }
        else
        {
            OutText.text = "Password incorrect, SSID, or phone number not correct";

        }
    }

}
