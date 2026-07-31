using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu (fileName = "Weapon", menuName = "create weapon")]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private float _shootCd;
    [SerializeField] private GameObject _model;
    [SerializeField] private WEaponType _type;

    public int Damage => _damage;
    public float Cooldown => _shootCd;
    public GameObject Model => _model;
    public WEaponType Type => _type;

}

public enum WEaponType
{
    AK47 = 0,
    DRABASH  = 1,
    GLOCHARA = 2,
    RPG = 3,
}
