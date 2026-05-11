using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Vector3 _moveVector;

    [SerializeField] private float _PlayerSpeed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private Rigidbody _playerRB;

    public void GetMoveInput(Vector2 move)
    {
        float coordX = move.x ;
        float coordZ = move.y ;
        //transform.right = (1,0,0)
        _moveVector = transform.right * coordX
                    + transform.forward * coordZ;

        _moveVector *= _PlayerSpeed * Time.fixedDeltaTime;
    }

    public void GetJUmpCOMAND()
    {
        
    }

    private void FixedUpdate()
    {
        _playerRB.MovePosition(_moveVector + _playerRB.position);
    }
}
