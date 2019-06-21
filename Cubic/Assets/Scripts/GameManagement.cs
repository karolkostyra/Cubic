using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagement : MonoBehaviour
{
    public int currentScore;
    public int highScore;
    public int currentLevel;
    public int unlockedLevel;
    

    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }


    public void CompleteLevel()
    {
        int numberOfLevels = SceneManager.sceneCountInBuildSettings - 2;
        if (currentLevel < numberOfLevels)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
        }
    }
}
