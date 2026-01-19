using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour
{
    public List<GameObject> cars = new List<GameObject>();
    private bool raceFinished = false;
    public GameObject winPanel, losePanel;
    public GameObject goalSergio;

    public GameObject Confeti;
    public GameObject Moneda;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject root = other.transform.root.gameObject;

        if (root.CompareTag("Player") || root.CompareTag("Car"))
        {
            if (!cars.Contains(root))
            {
                cars.Add(root);
            }

            if (root.CompareTag("Player") && !raceFinished)
            {
                raceFinished = true;
                goalSergio.SetActive(false);

                int playerPosition = cars.IndexOf(root) + 1;

                Debug.Log("Player finished at position: " + playerPosition);
                
                if (playerPosition == 2)
                {
                    PlayerPrefs.SetInt("Win", PlayerPrefs.GetInt("Win", 0) + 1);
                    Confeti.SetActive(true);
                    Moneda.SetActive(true);
                    Debug.Log("WIN! Player finished 2nd!");
                    winPanel.SetActive(true);
                    AudioManager.instance.StopMusic();
                    AudioManager.instance.StartMusic("victoria");
                }
                else
                {
                    Debug.Log("LOSE! Player finished " + playerPosition + "th");
                    losePanel.SetActive(true);
                    AudioManager.instance.StopMusic();
                    AudioManager.instance.StartMusic("derrota");
                }

                root.transform.GetChild(PlayerPrefs.GetInt("PlayerSprite")).GetComponent<PlayerMovement>().enabled = false;
            }
        }
    }
}