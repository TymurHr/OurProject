using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private EventBus BATYABUS;
    [SerializeField] PlayerMoveController _moveController;

    private void OnEnable()
    {
        BATYABUS = GameManager.Instance.ACTIONBUS;
        BATYABUS.OnMovePerformed += OnMoveCallback;
        BATYABUS.OnJumpPerformed += OnJumpCallback;
        BATYABUS.OnLookPerformed += OnLookCallback;
    }

    private void OnDisable()
    {
        BATYABUS.OnMovePerformed -= OnMoveCallback;
        BATYABUS.OnJumpPerformed -= OnJumpCallback;
        BATYABUS.OnLookPerformed -= OnLookCallback;
    }



    private void OnMoveCallback(Vector2 inputVector)
    {
/// if pause not pressed
/// if player not stuned
        _moveController.GetMoveInput(inputVector);
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
}
