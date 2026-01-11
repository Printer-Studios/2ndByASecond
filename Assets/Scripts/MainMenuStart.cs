using UnityEngine;

public class MainMenuStart : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
        AudioManager.instance.StartBackground();
        AudioManager.instance.StartMusic("menu");
    }
}
