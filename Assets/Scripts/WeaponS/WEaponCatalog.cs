using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu (fileName = "WeaponCatalog", menuName = "create weapon CATALOG")]
public class WEaponCatalog : ScriptableObject
{
    [SerializeField] private List<WeaponSO> _weapons;
    // [field:SerializeField] private Dictionary<WEaponType, WeaponSO> _weaponsDIC; 
  



    public WeaponSO GetWEapon(WEaponType type)
    {   
        var obj = _weapons[0];

        foreach(var weapon in _weapons)
        {
            if (weapon.Type == type)
            {
                obj = weapon;
            }

        }

        return obj;
    }

}
