using UnityEngine;


public class GameMenu : MonoBehaviour
{
    public bool forPlayerMovement = false;
    public bool forPlayerController = false;
    public GameObject Canvas;
    bool gameIsPaused = false;


    void Start()
    {
        Canvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
                Resume();
            else
                Pause();
        }
    }


    void Resume()
    {
        Time.timeScale = 1f;
        Canvas.gameObject.SetActive(false);

        if (forPlayerMovement)
            PlayerMovement.canMove = true;
        if (forPlayerController)
            PlayerController.canMove = true;

        //Cursor.visible = false;
        gameIsPaused = false;
    }

    void Pause()
    {
        Time.timeScale = 0f;
        Canvas.gameObject.SetActive(true);

        if (forPlayerMovement)
            PlayerMovement.canMove = false;
        if (forPlayerController)
            PlayerController.canMove = false;

        //Cursor.visible = false;
        gameIsPaused = true;
    }
}