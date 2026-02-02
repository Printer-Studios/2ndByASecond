using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class NEWPlayerMovement : Movement
{
    public float increaseSpeed;
    private Vector2 moveInput;
    private float lastX;

    void Update()
    {
        base.Update();

        if (moveInput.y > 0.5f) // UP
        {
            speed += increaseSpeed * Time.deltaTime;
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        if (input.x > 0.5f && lastX <= 0.5f) // RIGHT
            ChangeLane(1);

        if (input.x < -0.5f && lastX >= -0.5f) // LEFT
            ChangeLane(-1);

        lastX = input.x;
        moveInput = input;
    }

}
