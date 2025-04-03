using UnityEngine;

public class ActivateMenu : MonoBehaviour
{
    public void TogglePanel(GameObject obj) {
        obj.SetActive(!obj.activeInHierarchy);
    }
}
