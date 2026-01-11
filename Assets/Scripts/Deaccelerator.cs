using UnityEngine;

public class Deaccelerator : MonoBehaviour
{
    public float deacceleratorMultiplicator;
    public float deacceleratorMultValue;
    public Animator frenar;
    public GameObject players;

    void Start()
    {
        frenar = players.transform.GetChild(PlayerPrefs.GetInt("PlayerSprite")).gameObject.GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Car"))
        {
            other.gameObject.GetComponent<NPCmovement>().acceleration = deacceleratorMultiplicator;
            other.gameObject.GetComponent<NPCmovement>().timeToChangeAcceleration = 2f;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlayerOneShot(FMODEvents.instance.Banana, this.transform.position);
            frenar.SetBool("Frenar", true);
            other.gameObject.GetComponent<PlayerMovement>().speed *= deacceleratorMultValue;
        }
    }
}
