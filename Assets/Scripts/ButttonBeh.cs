using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class ButttonBeh : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Button _btn;
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private ButtonActions _thisAction;
    [SerializeField] private Image _img;
    [SerializeField] private Vector3 _punchScale = new Vector3(1.2f, 1.2f, 1.2f);
    [SerializeField] private float _punchTime = 0.7f;

    private Vector3 _defaultScale;
    private EventBus _bus;

    private Sequence _clickSequence;


    private void OnEnable()
    {
        SetText();

        _bus = GameManager.Instance.ACTIONBUS;
        
        _btn.onClick.AddListener(OnClicked);

        _defaultScale = transform.localScale;

        

    }

    private void OnDisable()
    {
        _btn.onClick.RemoveListener(OnClicked);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }

    private void OnClicked()
    {
        _btn.interactable = false;

        _clickSequence = DOTween.Sequence()
                            // .SetLink(gameObject)
                            .Append(transform.DOPunchScale(_punchScale, _punchTime))
                            .Append(transform.DORotate(new Vector3(0, 0,720f), _punchTime))
                            .OnComplete(() =>
                                {
                                    _bus.TriggerButton(_thisAction);
                                }
                            );
    }

    private void SetText()
    {
        _textField.text = _thisAction.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(_punchScale, _punchTime);
        // transform.DORotate(new Vector3(0, 0,30f), _punchTime/2);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(_defaultScale, _punchTime);
        // transform.DORotate(new Vector3(0, 0,0), _punchTime/2);
    }


}
