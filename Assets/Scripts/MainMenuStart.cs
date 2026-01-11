using UnityEngine;

public class MainMenuStart : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
        AudioManager.instance.StopMusic();
        PlayerPrefs.DeleteAll();
        AudioManager.instance.StartBackground();
        AudioManager.instance.StartMusic("menu");
    }
}
