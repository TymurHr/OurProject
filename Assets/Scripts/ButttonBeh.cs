using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButttonBeh : MonoBehaviour
{
    [SerializeField] private Button _btn;
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private ButtonActions _thisAction;
    private EventBus _bus;

    private void OnEnable()
    {
        SetText();

        _bus = GameManager.Instance.ACTIONBUS;
        
        _btn.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        _btn.onClick.RemoveListener(OnClicked);
    }

    private void OnClicked()
    {
        _bus.TriggerButton(_thisAction);
    }

    private void SetText()
    {
        _textField.text = _thisAction.ToString();
    }


}
