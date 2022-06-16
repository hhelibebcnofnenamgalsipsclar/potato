using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class OneTimeAct : MonoBehaviour
{
    public GameObject TutorialPanel;

    // Start is called before the first frame update

    void Start()
    {
        SaveObject newUser = Login.currentUser;
        List<SaveObject> potato = SaveManager.ReadFromJson<SaveObject>("potato.json"); //login info
        Debug.Log("x");
        if (Login.currentUser.getboolFirst() == true)
        {
            // set tutorial panel active
            Debug.Log("x");
            TutorialPanel.SetActive(true);
            newUser.changeFirst(false);
            potato.RemoveAt(Login.currentIndex);
            potato.Insert(Login.currentIndex, newUser);
            SaveManager.SaveToJson<SaveObject>(potato, "potato.json");
        }
    }


    // Update is called once per frame

}
