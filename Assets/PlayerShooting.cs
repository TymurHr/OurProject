using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;

    [SerializeField] private float _range;

    [SerializeField] private int _damage = 5;

    public void ShotCommand()
    {
        Ray ray =  new Ray(_shotPoint.position, _shotPoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, _range))
        {
            var enemy = hit.collider.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
            }
            
        }
    }
}
