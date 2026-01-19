using UnityEngine;
using UnityEngine.UI;

public class setKnob : MonoBehaviour
{
    public GameObject players;
    private GameObject player;
    void Start()
    {
        player = players.transform.GetChild(PlayerPrefs.GetInt("PlayerSprite")).gameObject;
    }

    void Update()
    {
        GetComponent<Image>().sprite = player.gameObject.GetComponent<SpriteRenderer>().sprite;
    }
}
