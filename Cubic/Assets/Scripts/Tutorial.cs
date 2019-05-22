using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    private GameObject playerObject;
    private Vector3 playerPosition;

    public Text instructionText;

    public float showOnDistance;


    void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    void Update()
    {
        playerPosition = playerObject.transform.position;
        if (Vector3.Distance(transform.position, playerPosition) < showOnDistance)
            instructionText.enabled = true;
        else
            instructionText.enabled = false;
    }
}
