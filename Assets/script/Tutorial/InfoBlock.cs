using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


public class InfoBlock : MonoBehaviour
{
    public GameObject InfoPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (Login.currentUser.getSSID().Length > 0)
        {
            InfoPanel.SetActive(false);
        }
    }
    void update()
    {
        if (Login.currentUser.getSSID().Length > 0)
        {
            InfoPanel.SetActive(false);
        }
    }



}
