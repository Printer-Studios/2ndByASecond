using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class NEWPlayerMovement : Movement
{
    public float increaseSpeed;
    public InputActionReference upAction;
    public InputActionReference leftAction;
    public InputActionReference rightAction;
    public InputActionReference boostAction;

    void Update()
    {
        base.Update();
        if (upAction.action.IsPressed())
        {
            speed += increaseSpeed * Time.deltaTime;
        }
        if (leftAction.action.WasPressedThisFrame())
        {
            ChangeLane(-1);
        }
        if (rightAction.action.WasPressedThisFrame())
        {
            ChangeLane(1);
        }
        if (boostAction.action.WasPressedThisFrame())
        {
            //
        }
    }
}
