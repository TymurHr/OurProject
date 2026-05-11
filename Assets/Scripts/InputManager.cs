using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class InputManager : MonoBehaviour
{
    private EventBus BUS;

    private void Start()
    {
        BUS = GameManager.Instance.ACTIONBUS;
    }

    public void ReadMoveInput(CallbackContext context)
    {
        Vector2 input = new Vector2();

        if (context.performed)
        {
            input = context.ReadValue<Vector2>();
        }
        // if (context.canceled)
        // {
        //     input = new Vector2(0,0);
        // }

        BUS.TriggerMove(input);
    }

    public void ReadJumpInput(CallbackContext context)
    {
        if (context.started)
        {
            BUS.TriggerJump();
        }
    }
}
