using System.Collections.Generic;
using UnityEngine;

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

    private void OnEnable()
    {
        CalculateNextPoint();
        _enemyHP = _maxEnemyHp;
        UpdateDisplay();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void UpdateDisplay()
    {
        _hpBarController.UpdateHpbar(_maxEnemyHp, _enemyHP);
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * (_moveSpeed * _moveDirection * Time.fixedDeltaTime ));
        float distance = Vector3.Distance(_startPosition, transform.position);

        if(distance >= _currentMoveDistance)
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
        _nextRotation = Random.Range(-180f, 180f);
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


}
