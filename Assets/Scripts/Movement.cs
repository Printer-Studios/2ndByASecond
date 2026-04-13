using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int currentLane, trackPosition;
    public float speed;
    public bool hasPowerUp;
    public Animator playerAnimator;
    private LevelManager levelManager;

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
        if (canChangeLane(currentLane, change))
        {
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
}
