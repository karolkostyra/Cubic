﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagement : MonoBehaviour
{
    public static int currentScore;
    public static int highScore;

    public static int currentLevel;// = SceneManager.GetActiveScene().buildIndex;
    public static int unlockedLevel;

    public GUISkin skin;
    public Rect timerRect;
    public Text endOfTime;
    public Color defaultColorTimer;
    public Color warningColorTimer;

    public float startTime;
    private string currentTime;
    private float timeWarning;


    void Start()
    {
        currentLevel = 1;
        endOfTime.enabled = false;
        timeWarning = startTime / 3;
    }

    void Update()
    {
        startTime -= Time.deltaTime;
        currentTime = string.Format("{0:0.0}", startTime);

        if (startTime <= 0)
        {
            startTime = 0;
            StartCoroutine(Timer());

            if (Input.GetKeyDown("return"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }

        if (startTime < timeWarning)
            skin.GetStyle("Timer").normal.textColor = warningColorTimer;
        else
            skin.GetStyle("Timer").normal.textColor = defaultColorTimer;
    }

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(timerRect, currentTime, skin.GetStyle("Timer"));
    }


    public static void CompleteLevel()
    {
        int numberOfLevels = SceneManager.sceneCountInBuildSettings - 2;
        if (currentLevel < numberOfLevels)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(8);
        }
    }


    IEnumerator Timer()
    {
        endOfTime.enabled = true;
        Time.timeScale = 0;
        yield return new WaitForSeconds(3f);
    }
}
