using UnityEngine;
using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;



public class Login : MonoBehaviour
{
    public static SaveObject currentUser = null;
    public static int currentIndex;
    public Text Username1;
    public Text Password1;
    public Text LoginReturn;
    // public Button registerButton;
    // public Text RegisterOutput;
    public InputField Password;
    public InputField Username;
    private string potato1;
    private string potato2;
    private bool checker = false;
    private void Start()
    {
        Username1.text = PlayerPrefs.GetString("name");
        Password1.text = PlayerPrefs.GetString("password");
    }
    // Start is called before the first frame update
    public void LoginChecker()
    {
        PlayerPrefs.SetString("name", Username.text);
        PlayerPrefs.SetString("password", Password.text);
        potato1 = PlayerPrefs.GetString("name");
        potato2 = PlayerPrefs.GetString("password");
        List<SaveObject> potato = SaveManager.ReadFromJson<SaveObject>("potato.json");
        for (int i = 0; i < potato.Count; i++)
        {
            if (potato1.Equals(potato[i].getUsername()))
            {
                if (potato2.Equals(potato[i].getPassword())) //username and password correct
                {
                    SceneManager.LoadScene("homepage");
                    currentUser = potato[i];
                    currentIndex = i;
                    break;
                }

                else //username exists but password incorrect
                {
                    LoginReturn.text = "Incorrect Password";
                }

            }

            else //user does not exist
            {
                LoginReturn.text = "No Username Found";
            }
        }
    }


}
