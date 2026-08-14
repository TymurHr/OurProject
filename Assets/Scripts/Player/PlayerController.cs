using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private EventBus BATYABUS;
    [SerializeField] private PlayerMoveController _moveController;

    [SerializeField] private PlayerShooting _shotController;

    //[SerializeField] private CreatureStats _playerStats;

    [SerializeField] private InwentaryControler _Inwentorycontroler;

    [SerializeField] private Transform CameraPivot;
    [SerializeField] private float _cameraRptaitenSpeed = 3f;
    private float _currentCameraRotateSpeed = 0f;

    [SerializeField] private int _PlayerHP = 100;
    private bool isDed = false;
    public bool IsDed => isDed; 
    private void OnEnable( )
    {
        BATYABUS = GameManager.Instance.ACTIONBUS;
        BATYABUS.OnMovePerformed += OnMoveCallback;
        BATYABUS.OnJumpPerformed += OnJumpCallback;
        BATYABUS.OnLookPerformed += OnLookCallback;
        BATYABUS.OnAttackPerformed += OnAttackCallback;
        BATYABUS.OnShiftPerformed += OnShiftCallback;
        BATYABUS.OnRollPerformed += OnRollCallback;
        //int coins = _playerStats._creatureCoins;

        var catalo = GameManager.Instance.GetWEaponCatalog;
        _Inwentorycontroler.SetUpInventery(catalo);
        _shotController.Init(_Inwentorycontroler);

    }

    private void OnDisable()
    {
        BATYABUS.OnMovePerformed -= OnMoveCallback;
        BATYABUS.OnJumpPerformed -= OnJumpCallback;
        BATYABUS.OnLookPerformed -= OnLookCallback;
        BATYABUS.OnAttackPerformed -= OnAttackCallback;
        BATYABUS.OnShiftPerformed -= OnShiftCallback;
        BATYABUS.OnRollPerformed -= OnRollCallback;
    }



    private void OnMoveCallback(Vector2 inputVector)
    {
        /// if pause not pressed
        /// if player not stuned
        if (isDed)
        {
            return;
        }
        _moveController.GetMoveInput(inputVector);
    }

    private void OnShiftCallback(bool t)
    {
        /// if pause not pressed
        /// if player not stuned
        if (isDed)
        {
            return;
        }
        _moveController.GetRunInput(t);
    }

    private void OnLookCallback(Vector2 inputVector)
    {
        /// if pause not pressed
        /// if player not stuned

        _currentCameraRotateSpeed = _cameraRptaitenSpeed * inputVector.y;
        _moveController.GetLookInput(inputVector);
    }
    private void Update()
    {
        if (isDed)
        {
            return;
        }
        CameraPivot.Rotate(Vector3.right, _currentCameraRotateSpeed * Time.deltaTime);
    }
     
    private void OnJumpCallback()
    {
        /// if pause not pressed
        /// if player not stuned
        if (isDed)
        {
            return;
        }
        _moveController.GetJUmpCOMAND();
    }

    private void OnAttackCallback(bool t)
    {
        /// if pause not pressed
        /// if player not stuned
        if (isDed)
        {
            return;
        }
        _shotController.ShotCommand(t);
    }
    private void OnRollCallback(float t)
    {
        if (isDed)
        {
            return;
        }
        _Inwentorycontroler.SwitchWeapon(t);
        _shotController.GetWeaponInHand();
    }
    public void TakeDamage(int dmg)
    {
        if( _PlayerHP > 0)
        {
            _PlayerHP -= dmg;

            if(_PlayerHP <= 0)
            {
                isDed = true;
            }
        }

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
    public List<WEaponType> wEapons;
}

[Serializable]
public struct InventerySlot
{
    public List<WEaponType> wEapons;
    public int amunition;
}

[Serializable]
public struct ItemStats
{
    public int _ammoInMagazine;
    public int _totalAmmo;

    public WEaponType _model;
}
