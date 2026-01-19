using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownUI : MonoBehaviour
{
    [Header("UI")]
    public Image countdownImage;

    [Header("Sprites (Order: 3, 2, 1)")]
    public Sprite[] countdownSprites;

    [Header("Timing")]
    public float timeBetweenNumbers = 1f;
    
    [Header ("NPCs")]
    public GameObject[] npcs;
    
    public GameObject players;
    private GameObject player; 

    private void Start()
    {
        player = players.transform.GetChild(PlayerPrefs.GetInt("PlayerSprite")).gameObject;
        player.GetComponent<PlayerMovement>().enabled = false;
        for (int i = 0; i < npcs.Length; i++)
        {
            npcs[i].GetComponent<NPCmovement>().enabled = false;
        }
        if (countdownImage == null || countdownSprites.Length == 0)
        {
            Debug.LogError("CountdownUI is missing references.");
            return;
        }
        AudioManager.instance.StopBackground();
        StartCoroutine(CountdownRoutine());
        AudioManager.instance.PlayerOneShot(FMODEvents.instance.Countdown321, this.transform.position);
        AudioManager.instance.StopMusic();
    }

    private IEnumerator CountdownRoutine()
    {
        for (int i = 0; i < countdownSprites.Length; i++)
        {
            countdownImage.sprite = countdownSprites[i];
            countdownImage.enabled = true;
            yield return new WaitForSeconds(timeBetweenNumbers);
        }

        // Hide after countdown finishes
        AudioManager.instance.StartMusic("carrera");
        countdownImage.enabled = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        Debug.Log(player.GetComponent<PlayerMovement>().enabled);
        for (int i = 0; i < npcs.Length; i++)
        {
            npcs[i].GetComponent<NPCmovement>().enabled = true;
        }
    }
}