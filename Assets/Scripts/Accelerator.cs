using System;
using UnityEngine;

public class Accelerator : MonoBehaviour
{
    public float acceleratorMultiplicator;
    public int acceleratorValue;
    public Animator acelerar;
    public GameObject players;
    public float timer = 0;

    void Start()
    {
        acelerar = players.transform.GetChild(PlayerPrefs.GetInt("PlayerSprite")).gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Car"))
        {
            other.gameObject.GetComponent<NPCmovement>().acceleration = acceleratorMultiplicator;
            other.gameObject.GetComponent<NPCmovement>().timeToChangeAcceleration = 2f;
        }
    }
    void Update()
    {
        timer = timer + Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (timer >= 0.5)
            {
                AudioManager.instance.PlayerOneShot(FMODEvents.instance.Nitro, this.transform.position);
                timer = 0;
            }
            
            acelerar.SetBool("Accelerar", true);
            other.gameObject.GetComponent<PlayerMovement>().speed += acceleratorValue * Time.deltaTime;
        }
    }
}
