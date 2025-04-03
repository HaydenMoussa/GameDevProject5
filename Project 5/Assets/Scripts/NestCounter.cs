using UnityEngine;
using UnityEngine.UI;

public class NestCounter : MonoBehaviour
{
    public int requiredSeals = 1;
    public Button progressButton;
    public SceneController sceneController;
    
    private int sealsInNest = 0;
    
    private void Start()
    {
        if (sceneController == null)
        {
            sceneController = GetComponent<SceneController>();
        }
        
        UpdateButtonState();
    }
    
    public void AddSeal()
    {
        sealsInNest++;
        UpdateButtonState();
    }
    
    private void UpdateButtonState()
    {
        bool enoughSeals = sealsInNest >= requiredSeals;
        
        if (progressButton != null)
        {
            progressButton.interactable = enoughSeals;
        }
    }
    
    public int GetSealsInNest()
    {
        return sealsInNest;
    }
}