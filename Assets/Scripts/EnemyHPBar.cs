using UnityEngine.UI;
using UnityEngine;

public class EnemyHPBar : MonoBehaviour
{
    [SerializeField] private Image _hpBarImg;

    [SerializeField] private Transform _canvas;

    private Camera _mainCamera;

    private void OnEnable()
    {
        _mainCamera = Camera.main;
    }

    public void UpdateHpbar(int maxValue, int currentValue)
    {
        float curentDisplayValue = (float)currentValue/maxValue;
        _hpBarImg.fillAmount = curentDisplayValue;
    }

    private void LateUpdate()
    {
        if (_mainCamera == null) return;
        _canvas.forward =  _mainCamera.transform.forward;
    }
}
