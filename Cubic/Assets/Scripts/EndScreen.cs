using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndScreen : MonoBehaviour
{
    public GUISkin skin;

    void OnGUI()
    {
        GUI.skin = skin;

        GUIStyle menuButton = new GUIStyle("button");
        menuButton.fontSize = 30;

        GUIStyle quitButton = new GUIStyle("button");
        quitButton.fontSize = 30;

        GUI.Label(new Rect(Screen.width/2-320, Screen.height/2-350, 750, 500), "Congratulations!\n       You win!");

        if (GUI.Button(new Rect(Screen.width/2-50, Screen.height/2-50, 150, 75), "Menu", menuButton))
        {
            SceneManager.LoadScene(0);
        }
        if (GUI.Button(new Rect(Screen.width/2-50, Screen.height/2+50, 150, 75), "Quit", quitButton))
        {
            Application.Quit();
        }

    }
}
