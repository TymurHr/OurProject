using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private const int _maxEnemyHp = 100;
    private int _enemyHP;
    [SerializeField] private EnemyHPBar _hpBarController;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxMoveDistance;
    [SerializeField] private float _minMoveDistance;

    [SerializeField] List<ParticleSystem> _hitParticles;
    private int _lastHit = 0;
    private float _currentMoveDistance = 0f;

    private Vector3 _startPosition;
    private int _moveDirection = 1;

    private float _nextRotation = 0f;

    [SerializeField] private CreatureInventory _inventory;

    private EnemySteite _currenSteite = EnemySteite.Idle;
    [SerializeField] private float _LookSpeed = 5f;
    [SerializeField] private float _searchTime = 1f;
    private float _nextScan = 0f;
    private float _searchRadius = 10f;
    [SerializeField] private LayerMask _playerLayer;
    private PlayerController _TargetPlayer;
    [SerializeField] private NavMeshAgent _Agent;


    [SerializeField] private int Damage = 5;
    [SerializeField] private float SchotKD = 3f;
    private float CarentKD = 0f;
    [SerializeField] private WEaponCatalog _weaponCatalog;
    [SerializeField] private Transform WeaponPoint;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        CalculateNextPoint();
        _enemyHP = _maxEnemyHp;
        UpdateDisplay();
    }
    private void CreitWeapon()
    {
        var Weapon = _weaponCatalog.GetWEapon(_inventory.wEapons[0]);

    }

    private void FixedUpdate()
    {
        _nextScan += Time.deltaTime;
        if (_nextScan >= _searchTime)
        {
            ScanForPlayer();
            _nextScan = 0;
        }
        switch (_currenSteite)
        {
            case EnemySteite.Idle:
                SetAnimaischenBlent(0f);
                //логика потрулюваня
                GoToRandomPoint();
                break;

            case EnemySteite.Chang:
                SetAnimaischenBlent(1f);
                ChangPlayer();
                break;

            case EnemySteite.Attack:
                SetAnimaischenBlent(0f);
                break;
        }
    }
    private void ChangPlayer()
    {
        _Agent.SetDestination(_TargetPlayer.transform.position);
    }
    private void ScanForPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, -_searchRadius, _playerLayer);
        if (colliders.Length > 0)
        {
            _TargetPlayer = colliders[0].GetComponent<PlayerController>();
            _currenSteite = EnemySteite.Chang;
        }

        else
        {
            _TargetPlayer = null;
            _currenSteite = EnemySteite.Idle;
        }
    }

    private void UpdateDisplay()
    {
        _hpBarController.UpdateHpbar(_maxEnemyHp, _enemyHP);
    }

    private void GoToRandomPoint()
    {
        _Agent.SetDestination(_startPosition + transform.forward * _currentMoveDistance * _moveDirection);

        if (_nextScan >= _searchTime)
        {
            _moveDirection *= -1;
            CalculateNextPoint();
            transform.Rotate(0,_nextRotation, 0);
        }
    }

    private void CalculateNextPoint()
    {
        _startPosition = transform.position;
        _currentMoveDistance = Random.Range(_minMoveDistance, _maxMoveDistance);
        _nextRotation = Random.Range(-50f, 50f);
    }

    public void TakeDamage(int damage, Vector3 position)
    {
        if (_enemyHP <= 0)
        {
            return;
        }
        _enemyHP -= damage;
        UpdateDisplay();
        PlayHit(position);
    }

    private void PlayHit(Vector3 position)
    {
        if (_lastHit >= _hitParticles.Count)
        {
            _lastHit = 0;
        }
        if (_hitParticles[_lastHit].isEmitting)
        {
            _hitParticles[_lastHit].Stop();
        }
        _hitParticles[_lastHit].transform.position = position;
        _hitParticles[_lastHit].Play();
        _lastHit++;
    }
    private void SetAnimaischenBlent(float blendValy)
    {
        _animator.SetFloat("Speed", blendValy);
    }

}

public enum EnemySteite
{
    Idle = 0,

    Chang = 1,

    Attack = 2

}
