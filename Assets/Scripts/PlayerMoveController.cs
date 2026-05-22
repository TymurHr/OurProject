using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    private Vector3 _moveVector;

    [SerializeField] private float _PlayerSpeed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private Rigidbody _playerRB;
    private bool _isGrounded;
    private const  string _groundLayer = "Ground";

    [SerializeField] private float _lookSpeed = 3f;
    private float _currentLookSpeed = 0f;
    [SerializeField] private float _lookThreshhold = 0.5f;

    public void GetMoveInput(Vector2 move)
    {
        float coordX = move.x ;
        float coordZ = move.y ;
        //transform.right = (1,0,0)
        _moveVector = transform.right * coordX
                    + transform.forward * coordZ;

        _moveVector *= _PlayerSpeed * Time.fixedDeltaTime;
    }

    public void GetLookInput(Vector2 look)
    {
        float xInput = look.x;
        Debug.Log(xInput);
        
        if (xInput > _lookThreshhold)
        {
            _currentLookSpeed = _lookSpeed;
        }
        else if (xInput < -_lookThreshhold)
        {
            _currentLookSpeed = -_lookSpeed;
        }
        else
        {
            _currentLookSpeed = 0f;
        }
    }

    public void GetJUmpCOMAND()
    {
        if(!_isGrounded)
        {
            return;
        }
        _isGrounded = false;
        Vector3 jumpDirection = new Vector3(0, _jumpForce, 0);
        _playerRB.AddForce(jumpDirection, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(_groundLayer))
        {
            _isGrounded = true;
        }
    }

    private void FixedUpdate()
    {
        _playerRB.MovePosition(_moveVector + _playerRB.position);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * _currentLookSpeed);
    }
}
