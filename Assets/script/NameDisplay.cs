using UnityEngine;
using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class NameDisplay : MonoBehaviour
{
    public Text name1;

    void Start()
    {
        name1.text = "Welcome, " + Login.currentUser.getUsername();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
