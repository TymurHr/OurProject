using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    private const string _walkParameter = "Speed";
    private const string _armedParameter = "IsArmed";

    private EventBus _bus;
    private float _currentSpeed;

    private void OnEnable()
    {
        _bus = GameManager.Instance.ACTIONBUS;
        _bus.OnMovePerformed += CatchPLayerSpeed;
        _anim.SetBool(_armedParameter, true);
    }

    private void OnDisable()
    {
        _bus.OnMovePerformed -= CatchPLayerSpeed;
    }

    private void CatchPLayerSpeed(Vector2 move)
    {
        if (move.sqrMagnitude > 0.03f)
        {
            _currentSpeed = 1f;
        }
        else
        {
            _currentSpeed = 0;
        }
    }

    private void LateUpdate()
    {
        _anim.SetFloat(_walkParameter, _currentSpeed);
    }
}
