using UnityEngine;

public class MainMenuStart : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.StopMusic();
        PlayerPrefs.DeleteAll();
        AudioManager.instance.StartBackground();
        AudioManager.instance.StartMusic("menu");
    }
}
