using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeToFaceID : MonoBehaviour
{
    float counter = 0;
    float waitTime = 7;
    // Start is called before the first frame update
    public void loadScene(string faceIDScreen)
    {
        SceneManager.LoadScene(faceIDScreen);
    }
    public void loadScene2(string homepage)
    {
        float timer = 0;
        bool timerReached = false;
        if (!timerReached)
            timer += Time.deltaTime;

        if (!timerReached && timer > 5)
        {

            //Set to false so that We don't run this again
            timerReached = true;
            SceneManager.LoadScene(homepage);
        }
    }

}
