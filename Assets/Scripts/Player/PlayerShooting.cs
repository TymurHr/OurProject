using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;

    [SerializeField] private Transform _weaponRoot;

    [SerializeField] private float _range;

    [SerializeField] private WEaponType _requestWEapon;

    private InwentaryControler _controler;


    private int _damage;
    private float _defaultShootCD;


    private float _currentShootCD = 0;
    private bool _isShootingAllowed = false;

    public void Init(InwentaryControler controler)
    {

        _controler = controler;
        GetWeaponInHand();
    }

    public void ShotCommand(bool t)
    {
        _isShootingAllowed = t;
    }

    public void GetWeaponInHand()
    {
        var wpn = _controler.getWeaponSO();
        _damage = wpn.Damage;
        _defaultShootCD = wpn.Cooldown;
    }

    private void Update()
    {
        _currentShootCD += Time.deltaTime;

        if (_isShootingAllowed  && _currentShootCD >= _defaultShootCD)
        {
            ShotRay();
            
            _currentShootCD = 0;
        }
    }

    private void ShotRay()
    {
        Ray ray =  new Ray(_shotPoint.position, _shotPoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, _range))
        {
            var enemy = hit.collider.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(_damage, hit.point);
            }
            
        }
    }
}
