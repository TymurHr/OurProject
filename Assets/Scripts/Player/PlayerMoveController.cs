using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    //Movement
    private Vector3 _moveVector;

    [SerializeField] private float _playerWalkSpeed;
    [SerializeField] private float _playerRunSpeed;
    private float _currentSpeed;
    private float _inputX;
    private float _inputZ;
    

    /// <summary>
    /// Jumping
    /// </summary>
    [SerializeField] private float _jumpForce;

    [SerializeField] private Rigidbody _playerRB;
    private bool _isGrounded;
    private const  string _groundLayer = "Ground";


    //LOOK
    [SerializeField] private float _lookSpeed = 3f;
    private float _currentLookSpeed = 0f;
    [SerializeField] private float _lookThreshhold = 0.5f;


    private void OnEnable()
    {
        _currentSpeed = _playerWalkSpeed;        
    }
    public void GetMoveInput(Vector2 move)
    {
        _inputX = move.x ;
        _inputZ = move.y ;
    }

    

    public void GetLookInput(Vector2 look)
    {
        float xInput = look.x;
        
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

    public void GetRunInput(bool t)
    {
        if (t)
        {
            _currentSpeed = _playerRunSpeed;
        }
        else
        {
            _currentSpeed = _playerWalkSpeed;
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
        Move();
    }

    private void Move()
    {
        _moveVector = transform.right * _inputX
                    + transform.forward * _inputZ;

        _moveVector *= _currentSpeed * Time.fixedDeltaTime;
        // transform.Translate(_moveVector + transform.position);
        _playerRB.MovePosition(_moveVector + _playerRB.position);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * _currentLookSpeed);
    }
}
