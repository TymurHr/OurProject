using System;
using System.Collections.Generic;
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

        BATYABUS.OnShiftPerformed += OnShiftCallback;
        int coins = _playerStats._creatureCoins;
        
        var catalo = GameManager.Instance.GetWEaponCatalog;
        
        _shotController.GetWeaponInHand(catalo);
    }

    private void OnDisable()
    {
        BATYABUS.OnMovePerformed -= OnMoveCallback;
        BATYABUS.OnJumpPerformed -= OnJumpCallback;
        BATYABUS.OnLookPerformed -= OnLookCallback;
        BATYABUS.OnAttackPerformed -= OnAttackCallback;
        BATYABUS.OnShiftPerformed -= OnShiftCallback;
    }



    private void OnMoveCallback(Vector2 inputVector)
    {
/// if pause not pressed
/// if player not stuned
        _moveController.GetMoveInput(inputVector);
    }

    private void OnShiftCallback(bool t)
    {
/// if pause not pressed
/// if player not stuned
        _moveController.GetRunInput(t);
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

    private void OnAttackCallback(bool t)
    {
/// if pause not pressed
/// if player not stuned
        _shotController.ShotCommand(t);  
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
    public List<ItemStats> _itemsInInventory;
    public List<ItemStats> _itemsEquiped;

}


[Serializable]
public struct ItemStats
{
    public int _ammoInMagazine;
    public int _totalAmmo;

    public WEaponType _model;
}
