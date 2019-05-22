using System.Collections;
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


    public float startTime;
    private string currentTime;


    void Start()
    {
        currentLevel = 1;
        endOfTime.enabled = false;
    }

    void Update()
    {
        startTime -= Time.deltaTime;
        currentTime = string.Format("{0:0.0}", startTime);


        if(startTime <= 0)
        {
            startTime = 0;
            StartCoroutine(Timer());

            if (Input.GetKeyDown("return"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }
    }

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(timerRect, currentTime, skin.GetStyle("Timer"));
    }


    public static void CompleteLevel()
    {
        if(currentLevel < 7)
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
