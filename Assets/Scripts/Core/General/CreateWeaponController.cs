using System.Collections.Generic;
using UnityEngine;

public class CreateWeaponController : Weapon
{
    [SerializeField] public List<GameObject> _weaponInPool;
    [SerializeField] private Transform _transformWeapon;
    [SerializeField] private WeaponController _weaponController;

    public List<GameObject> _createdWeapon = new List<GameObject>();
    
    public override void CreateWeapon(int i)
    {
        if (_weaponInPool[i] != null)
        {
            var weapon = Instantiate(_weaponInPool[i], _transformWeapon.position, transform.rotation);
            _createdWeapon.Add(weapon);
            _weaponController.DeactivateWeapon();
        }
        else if (_weaponInPool[i] = null)
        {
            return;
        };
    }
}
