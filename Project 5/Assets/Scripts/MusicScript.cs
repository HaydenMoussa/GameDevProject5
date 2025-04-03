using Unity.VisualScripting;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public static MusicScript instance;

    private void Awake()
    {
        if (instance == null){
            DontDestroyOnLoad(this.gameObject);
            instance=this;
        }
        else{
            Destroy(gameObject);
        }
    }
}
