using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private List<Sprite> sprites;

    [Header("Cars")]
    [SerializeField] private GameObject[] cars;

    void Start()
    {
        // Get saved player sprite index (default to 0)
        int playerSpriteIndex = PlayerPrefs.GetInt("PlayerSprite", 0);

        // Make a safe copy so we don't permanently modify the Inspector list
        List<Sprite> availableSprites = new List<Sprite>(sprites);

        // Validate index before removing
        if (playerSpriteIndex >= 0 && playerSpriteIndex < availableSprites.Count)
        {
            availableSprites.RemoveAt(playerSpriteIndex);
        }
        else
        {
            Debug.LogError(
                $"PlayerSprite index {playerSpriteIndex} is out of range. " +
                $"Sprites count: {availableSprites.Count}"
            );
        }

        // Assign sprites to cars safely
        int count = Mathf.Min(availableSprites.Count, cars.Length);

        for (int i = 0; i < count; i++)
        {
            SpriteRenderer sr = cars[i].GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.sprite = availableSprites[i];
            }
            else
            {
                Debug.LogWarning($"Car at index {i} has no SpriteRenderer.");
            }
        }
    }
}

