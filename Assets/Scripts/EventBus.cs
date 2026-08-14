using System;
using UnityEngine;

public class EventBus 
{
    public event Action<ButtonActions> OnButtonPressed;


    //input events
    public event Action<Vector2> OnMovePerformed;
    public event Action<Vector2> OnLookPerformed;
    public event Action OnJumpPerformed;
    public event Action<bool> OnAttackPerformed;
    public event Action<bool> OnShiftPerformed;
    public event Action<float> OnRollPerformed;

    public void TrigerRoll(float num)
    {
        OnRollPerformed?.Invoke(num);
    }

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
    public void TriggerAttack(bool t)
    {
        OnAttackPerformed?.Invoke(t);
    }

    public void TriggerShift(bool t)
    {
        OnShiftPerformed?.Invoke(t);
    }

    public void TriggerLook(Vector2 moveVector)
    {
        OnLookPerformed?.Invoke(moveVector);
    }
}
