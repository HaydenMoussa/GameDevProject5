using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene("Level3");   
    }
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}