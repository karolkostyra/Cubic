using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GUISkin skin;


    void OnGUI()
    {
        GUI.skin = skin;

        GUIStyle playButton = new GUIStyle("button");
        playButton.fontSize = 30;

        GUIStyle quitButton = new GUIStyle("button");
        quitButton.fontSize = 30;

        GUI.Label(new Rect(Screen.width/2-100, Screen.height/2-300, 450, 450), "Cubic");
        

        if(GUI.Button(new Rect(Screen.width/2-50, Screen.height/2-50, 150, 75), "Play", playButton))
        {
            SceneManager.LoadScene(1);
        }
        if (GUI.Button(new Rect(Screen.width/2-50, Screen.height/2+50, 150, 75), "Quit", quitButton))
        {
            Application.Quit();
        }
    }
}
