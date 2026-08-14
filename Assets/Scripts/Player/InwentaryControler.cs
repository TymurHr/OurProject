using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class InwentaryControler : MonoBehaviour
{
    [SerializeField] private CreatureInventory inventory;
    private WEaponCatalog catalog;
    [SerializeField] private Transform weaponPosition;

    private List<GameObject> _instantiatedWeapons = new List<GameObject>();

    private int _carentIEquip = 0;

    public WEaponType GetEquipedWeapon()
    {
        return inventory.wEapons[_carentIEquip];
    }
    public void SwitchWeapon(float delta)
    {
        _carentIEquip += (int)delta;
        if (_carentIEquip > inventory.wEapons.Count - 1) 
        {
            _carentIEquip = 0;
        }
        if (_carentIEquip < 0)
        {
            _carentIEquip = inventory.wEapons.Count - 1;
        }
        SetActiveWeapon();
    }
    public void SetUpInventery(WEaponCatalog wEaponCatalog)
    {
        catalog = wEaponCatalog;
        foreach(var weapon in inventory.wEapons)
        {
            var weaponObj = catalog.GetWEapon(weapon);
            var instantiedWeapon = Instantiate(weaponObj.Model,weaponPosition.position,weaponPosition.rotation,weaponPosition);
            instantiedWeapon.SetActive(false);
           _instantiatedWeapons.Add(instantiedWeapon);
        }
        SetActiveWeapon();
    }
    private void SetActiveWeapon()
    {
        foreach (var weapon in _instantiatedWeapons)
        {
            weapon.SetActive(false);
        }
        _instantiatedWeapons[_carentIEquip].SetActive(true);
    }
    public WeaponSO getWeaponSO()
    {
        return catalog.GetWEapon(inventory.wEapons[_carentIEquip]);
    }
}
