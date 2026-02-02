using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int currentLane, trackPosition;
    public float speed;
    public bool HasPower, EndPower;
    public Animator playerAnimator;
    private LevelManager levelManager;
    public float boostSpeed, boostTimer, cooldown;

    public enum Powers
    {
        Boost,
        Stop
    }
    public Powers CarPower;

    private void Start()
    {
        if (levelManager == null)
        {
            levelManager = FindObjectOfType<LevelManager>();
        }
        
        transform.position = new Vector2(currentLane * levelManager.laneSeparation, levelManager.startPoint.transform.position.y);
    }

    public void Update()
    {
        Move();
    }

    public bool canChangeLane(int currentLane, int change) // Change == +1 or -1
    {
        if (currentLane + change >= 0 && currentLane + change <= levelManager.numberLanes)
        {
            return true;
        }
        return false;
    }
    
    public void ChangeLane(int change)
    {
        Debug.Log("ahhvans");
        if (canChangeLane(currentLane, change))
        {
            Debug.Log("ahh");
            currentLane = currentLane + change;
            transform.position = new Vector2(currentLane * levelManager.laneSeparation, transform.position.y);
        }
    }

    public void ChangeSpeed(float change)
    {
        speed += change;
    }

    public void Move()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + speed * Time.deltaTime);
    }

    public void Power()
    {
        
        switch (CarPower)
        {
            case Powers.Boost:
                if (HasPower)
                {
                    //AudioManager.instance.PlayerOneShot(FMODEvents.instance.Nitro, this.transform.position);
                    //playerAnimator.SetBool("Accelerar", true);
                    speed += boostSpeed;
                    HasPower = false;
                    boostTimer = 0;
                    //boostSprite.GetComponent<RawImage>().color = new Color(1, 1, 1, 0.2f);
                }
                if (!HasPower && !EndPower)
                {
                    boostTimer += Time.deltaTime;
                    if (boostTimer >= cooldown)
                    {
                        boostTimer = 0;
                        speed -= boostSpeed/2;
                        EndPower = true;
                    }
                }
                break;
            case Powers.Stop:

                break;
        }
    }
}
