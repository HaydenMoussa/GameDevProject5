using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public NestCounter nestCounter;

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadSecondScene()
    {
        if (CanProgress())
        {
            SceneManager.LoadScene("Level2");
        }
    }
    
    public void LoadLevelTwo()
    {
        if (CanProgress())
        {
            Invoke("LoadSecondScene", 2);
        }
    }

    public void LoadThirdScene()
    {
        SceneManager.LoadScene("Level3");
    }
    
    public void LoadLevelThree()
    {
        if (CanProgress())
        {
            Invoke("LoadThirdScene", 2);
        }
    }

    public void LoadMainMenu()
    {
        Invoke("ResetGame", 2);
    }
    
    public void ResetGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    private bool CanProgress()
    {
        if (nestCounter == null)
        {
            return true;
        }
        
        return nestCounter.GetSealsInNest() >= nestCounter.requiredSeals;
    }
}