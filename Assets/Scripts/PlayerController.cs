using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private EventBus BATYABUS;
    [SerializeField] PlayerMoveController _moveController;

    private CreatureStats _playerStats;

    private void OnEnable()
    {
        BATYABUS = GameManager.Instance.ACTIONBUS;
        BATYABUS.OnMovePerformed += OnMoveCallback;
        BATYABUS.OnJumpPerformed += OnJumpCallback;
        BATYABUS.OnLookPerformed += OnLookCallback;

        int coins = _playerStats._creatureCoins;
    }

    private void OnDisable()
    {
        BATYABUS.OnMovePerformed -= OnMoveCallback;
        BATYABUS.OnJumpPerformed -= OnJumpCallback;
        BATYABUS.OnLookPerformed -= OnLookCallback;

  
    }



    private void OnMoveCallback(Vector2 inputVector)
    {
/// if pause not pressed
/// if player not stuned
        _moveController.GetMoveInput(inputVector);
    }

    private void OnLookCallback(Vector2 inputVector)
    {
/// if pause not pressed
/// if player not stuned
        _moveController.GetLookInput(inputVector);
    }

    private void OnJumpCallback()
    {
/// if pause not pressed
/// if player not stuned
        _moveController.GetJUmpCOMAND();  
    }
}

[Serializable]
public struct CreatureStats
{
    public int _creatureHP;
    public int _creatureCoins;
    public float _creatureSpeed;
    public Vector3 _currentPosition;
    public CreatureInventory _inventory;
}

[Serializable]
public struct CreatureInventory
{
    public string _rightHandEquip;
    public string _leftHandEquip;


}
