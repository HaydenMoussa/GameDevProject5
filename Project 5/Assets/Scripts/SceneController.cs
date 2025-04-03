using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadSecondScene()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadLevelTwo()
    {
        Invoke("LoadSecondScene", 2);
    }

    public void LoadThirdScene(){
        SceneManager.LoadScene("Level3");
    }
    public void LoadLevelThree()
    {
        Invoke("LoadThirdScene", 2);
    }

    public void LoadMainMenu()
    {
        Invoke("ResetGame", 2);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}