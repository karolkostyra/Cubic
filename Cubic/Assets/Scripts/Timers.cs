using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Timers : MonoBehaviour
{
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


    IEnumerator Timer()
    {
        endOfTime.enabled = true;
        Time.timeScale = 0;
        yield return new WaitForSeconds(3f);
    }
}
