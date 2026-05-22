using System;
using UnityEngine;

public class EventBus 
{
    public event Action<ButtonActions> OnButtonPressed;


    //input events
    public event Action<Vector2> OnMovePerformed;
    public event Action<Vector2> OnLookPerformed;
    public event Action OnJumpPerformed;


    public void TriggerButton(ButtonActions action)
    {
        OnButtonPressed?.Invoke(action);
    }


    public void TriggerMove(Vector2 moveVector)
    {
        OnMovePerformed?.Invoke(moveVector);
    }

    public void TriggerJump()
    {
        OnJumpPerformed?.Invoke();
    }

    public void TriggerLook(Vector2 moveVector)
    {
        OnLookPerformed?.Invoke(moveVector);
    }
}
