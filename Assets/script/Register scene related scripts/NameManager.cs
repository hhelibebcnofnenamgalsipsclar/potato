using UnityEngine;
using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;


public class NameManager : MonoBehaviour
{
    string filename = "potato.json";
    public Text Username;
    public Text Password;
    public Text RegisterOutput;
    public InputField PasswordInput;
    public InputField UsernameInput;
    public string potato1;
    public string potato2;
    private bool checker = false;

    List<SaveObject> entries = new List<SaveObject>();

    private void Start()
    {
        Username.text = PlayerPrefs.GetString("name");
        Password.text = PlayerPrefs.GetString("password");
        entries = SaveManager.ReadFromJson<SaveObject>(filename);
    }

    public void ClickSave()
    {
        checker = true;
        PlayerPrefs.SetString("name", UsernameInput.text);
        PlayerPrefs.SetString("password", PasswordInput.text);
        potato1 = PlayerPrefs.GetString("name");
        potato2 = PlayerPrefs.GetString("password");
        if (potato2.Length >= 5 && potato2.Length <= 15)
        {
            for (int index = 0; index < entries.Count; index++)
            {
                if (potato1.Equals(entries[index].getUsername()))
                {
                    RegisterOutput.text = "Username is taken";
                    checker = false;
                    break;
                }

            }

            if (checker)
            {
                entries.Add(new SaveObject(potato1, potato2, null, true, 0, 0, true));
                RegisterOutput.text = "thank you registering " + potato1 + " please go to login screen";
                SaveManager.SaveToJson<SaveObject>(entries, filename);
            }
        }
        else
        {
            RegisterOutput.text = "The length of password must be within 5-15 characters!";
        }
    }

}

