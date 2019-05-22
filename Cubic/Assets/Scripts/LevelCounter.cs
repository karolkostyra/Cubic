using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCounter : MonoBehaviour
{

    void Start()
    {
        Text countLevel = GameObject.Find("Display Level/Canvas/Level").GetComponent<Text>();
        countLevel.text = "Level " + SceneManager.GetActiveScene().buildIndex;
    }
    

    void Update()
    {
        Destroy(gameObject, 2);
    }
}
