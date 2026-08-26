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

    [SerializeField] private float minRotationX = -30f;
    [SerializeField] private float maxRotationX = 30f;
    private float _currentRotationX = 0f;
    private float _currentRotationY = 0f;
    [SerializeField] private float _cameraRetornSpeedY = 3f;
    private float _currentCameraSpeedY =0f;
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
        if (isDed)
        {
            return;
        }
        /// if pause not pressed
        /// if player not stuned
        _currentCameraSpeedY = _cameraRptaitenSpeed * inputVector.x;
        _currentCameraRotateSpeed = _cameraRptaitenSpeed * inputVector.y;
        _moveController.GetLookInput(inputVector);
    }
    private void Update()
    {
        if (isDed)
        {
            return;
        }
        _currentRotationX += _currentCameraRotateSpeed * Time.deltaTime;
        _currentRotationX= Mathf.Clamp(CameraPivot.rotation.x, minRotationX,maxRotationX);
        // CameraPivot.Rotate(Vector3.right, _currentCameraRotateSpeed * Time.deltaTime);
        _currentRotationY += _currentCameraSpeedY * Time.deltaTime;
        _currentRotationY = Mathf.Lerp(_currentRotationY, 0f , _cameraRetornSpeedY * Time.deltaTime);
       CameraPivot.localRotation = Quaternion.Euler(-_currentRotationX,_currentRotationY,0f);
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
