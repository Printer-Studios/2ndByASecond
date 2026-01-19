using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ActivateCars : MonoBehaviour
{
    public LevelManager levelManager;

    private void Awake()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    void Start()
    {
        transform.GetChild(PlayerPrefs.GetInt("PlayerSprite")).gameObject.SetActive(true);
        transform.GetChild(PlayerPrefs.GetInt("PlayerSprite")).gameObject.GetComponent<NEWPlayerMovement>().enabled = true;
        
        for (int i = 0; i < levelManager.numNPCs; i++)
        {
            int aleaNPC;
            do
            {
                aleaNPC = Random.Range(0, transform.childCount);
            } while (aleaNPC == PlayerPrefs.GetInt("PlayerSprite") || transform.GetChild(aleaNPC).gameObject.activeSelf);
            Debug.Log(transform.GetChild(aleaNPC).gameObject);
            transform.GetChild(aleaNPC).gameObject.SetActive(true);
            transform.GetChild(aleaNPC).gameObject.GetComponent<Movement>().enabled = true;
        }
    }
}
