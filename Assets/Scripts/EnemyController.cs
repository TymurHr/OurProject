using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _enemyHP;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxMoveDistance;
    [SerializeField] private float _minMoveDistance;
    private float _currentMoveDistance = 0f;

    private Vector3 _startPosition;
    private int _moveDirection = 1;

    private float _nextRotation = 0f;

    private void OnEnable()
    {
        CalculateNextPoint();
        
    }

    private void FixedUpdate()
    {
        Move();
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

    public void TakeDamage(int damage)
    {
        _enemyHP -= damage;

        Debug.Log(_enemyHP);
    }


}
