using UnityEngine;
using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;


public class ChangePass : MonoBehaviour
{
    public InputField OldPass;
    public InputField NewPass;
    public Text Otext;
    public Text Ntext;
    public Text ChangePassOut;
    private string potato1;
    private string potato2;

    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        Otext.text = PlayerPrefs.GetString("OldPass");
        Ntext.text = PlayerPrefs.GetString("NewPass");
    }
    public void ChangePassword()
    {
        PlayerPrefs.SetString("OldPass", OldPass.text);
        PlayerPrefs.SetString("NewPass", NewPass.text);
        potato1 = PlayerPrefs.GetString("OldPass");
        potato2 = PlayerPrefs.GetString("NewPass");


        List<SaveObject> potato = SaveManager.ReadFromJson<SaveObject>("potato.json");
        if (Login.currentUser.getPassword() == potato1)
        {
            SaveObject newUser = Login.currentUser;
            newUser.Changepw(potato2);
            potato.RemoveAt(Login.currentIndex);
            potato.Insert(Login.currentIndex, newUser);
            SaveManager.SaveToJson<SaveObject>(potato, "potato.json");

            ChangePassOut.text = "Password Changed";
        }
        else
        {
            ChangePassOut.text = "Password Incorrect";
        }
    }
}
