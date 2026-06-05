using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private EventBus BATYABUS;
    [SerializeField] private PlayerMoveController _moveController;

    [SerializeField] private PlayerShooting _shotController;

    private CreatureStats _playerStats;

    private void OnEnable()
    {
        BATYABUS = GameManager.Instance.ACTIONBUS;
        BATYABUS.OnMovePerformed += OnMoveCallback;
        BATYABUS.OnJumpPerformed += OnJumpCallback;
        BATYABUS.OnLookPerformed += OnLookCallback;
        BATYABUS.OnAttackPerformed += OnAttackCallback;
        int coins = _playerStats._creatureCoins;
    }

    private void OnDisable()
    {
        BATYABUS.OnMovePerformed -= OnMoveCallback;
        BATYABUS.OnJumpPerformed -= OnJumpCallback;
        BATYABUS.OnLookPerformed -= OnLookCallback;
        BATYABUS.OnAttackPerformed -= OnAttackCallback;
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

    private void OnAttackCallback()
    {
/// if pause not pressed
/// if player not stuned
        _shotController.ShotCommand();  
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
