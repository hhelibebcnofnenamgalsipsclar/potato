using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logout : MonoBehaviour
{
    public void logoff()
    {
        Login.currentUser = null;
        SceneManager.LoadScene("Registeration");
    }

}

