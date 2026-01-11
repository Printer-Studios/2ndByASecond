using UnityEngine;

public class PlayerSpriteShowPodium : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.GetComponent<SpriteRenderer>().sprite = sprites[PlayerPrefs.GetInt("PlayerSprite")];
    }
}
